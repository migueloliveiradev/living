using System.Reflection;

namespace Living.Domain.Features.Users.Constants;

public static class UserClaims
{
    public static readonly IReadOnlyDictionary<string, string[]> AllAggroup = LoadAllAggroup().AsReadOnly();
    public static readonly IReadOnlyList<string> All = AllAggroup.SelectMany(x => x.Value).ToList().AsReadOnly();
    public static class Post
    {
        public const string CREATE = "POST.CREATE";
    }

    private static Dictionary<string, string[]> LoadAllAggroup()
    {
        var subModules = typeof(UserClaimsTokens).GetNestedTypes(BindingFlags.Static | BindingFlags.Public);

        return subModules
            .SelectMany(subModule => subModule.GetNestedTypes(BindingFlags.Static | BindingFlags.Public))
            .ToDictionary(
                subType => subType.Name.ToUpperInvariant(),
                subType => subType.GetFields()
                    .Select(field => (field.GetRawConstantValue() as string)!)
                    .ToArray(), StringComparer.Ordinal);
    }
}
