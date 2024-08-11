using System.Reflection;
using System.Runtime.CompilerServices;

namespace Living.Shared.Extensions;
public static class PropertyInfoExtensions
{
    public static bool IsOnlyGet(this PropertyInfo property)
    {
        if (property.DeclaringType is null || property.DeclaringType.FullName is null)
            return false;

        var getMethod = property.GetMethod;

        if (getMethod is null)
            return false;

        var setMethod = property.SetMethod;

        return setMethod is null;
    }

    public static bool IsGetInit(this PropertyInfo property)
    {
        if (property.DeclaringType is null || property.DeclaringType.FullName is null)
            return false;

        var setMethod = property.SetMethod;

        if (setMethod is null)
            return false;

        var paramsModifiers = setMethod.ReturnParameter.GetRequiredCustomModifiers();

        return paramsModifiers.Contains(typeof(IsExternalInit));
    }
}
