using Living.Domain.Base;
using System.Reflection;
using System.Reflection.Emit;

namespace Living.WebAPI.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class NotificationProducesResponseTypeAttribute : ProducesResponseTypeAttribute
{
    public NotificationProducesResponseTypeAttribute(Type type, int statusCode) : base(type, statusCode)
    {
        var assembly = Assembly.Load("Living.Domain");
        var types = assembly.GetTypes().Where(t => t.GetProperties().Any(p => p.PropertyType == typeof(Notification)));

        var notifications = types.SelectMany(t =>
            t.GetProperties()
            .Where(p => p.PropertyType == typeof(Notification))
            .Select(p => p.GetValue(null))
            .Cast<Notification>())
            .GroupBy(p => p.Key, StringComparer.Ordinal)
            .ToDictionary(n => n.Key, n => n.Select(p => p.Code), StringComparer.Ordinal);

        var dictionaryType = CreateDynamicDictionaryType(notifications);

        Type = dictionaryType;
    }

    internal static Type CreateDynamicDictionaryType(Dictionary<string, IEnumerable<string>> notifications)
    {
        var assemblyName = new AssemblyName("DynamicNotifications");
        var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndCollect);
        var moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");

        var typeBuilder = moduleBuilder.DefineType("NotificationDictionary", TypeAttributes.Public);

        foreach (var kvp in notifications)
        {
            var subTypeBuilder = moduleBuilder.DefineType(kvp.Key.ToUpperInvariant(), TypeAttributes.Public);

            foreach (var value in kvp.Value)
            {
                var propertyBuilder = subTypeBuilder.DefineProperty(value.ToUpperInvariant(), PropertyAttributes.HasDefault, typeof(string), Type.EmptyTypes);

                var getMethodBuilder = subTypeBuilder.DefineMethod($"get_{value.ToUpperInvariant()}", MethodAttributes.Public, typeof(string), Type.EmptyTypes);

                var ilGenerator = getMethodBuilder.GetILGenerator();
                ilGenerator.Emit(OpCodes.Ldarg_0);


                propertyBuilder.SetGetMethod(getMethodBuilder);
            }

            var subType = subTypeBuilder.CreateType();

            var listType = typeof(List<>).MakeGenericType(subType);
            var listProperty = typeBuilder.DefineProperty(kvp.Key.ToUpperInvariant(), PropertyAttributes.None, listType, Type.EmptyTypes);

            var getListMethodBuilder = typeBuilder.DefineMethod($"get_{kvp.Key.ToUpperInvariant()}", MethodAttributes.Public, listType, Type.EmptyTypes);

            var ilGenGetList = getListMethodBuilder.GetILGenerator();
            ilGenGetList.Emit(OpCodes.Ldarg_0);


            listProperty.SetGetMethod(getListMethodBuilder);
        }

        return typeBuilder.CreateType();
    }
}
