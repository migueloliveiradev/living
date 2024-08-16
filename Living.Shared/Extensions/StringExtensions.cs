using Living.Shared.Helpers;

namespace Living.Shared.Extensions;
public static partial class StringExtensions
{
    public static string ToPascalCase(this string @string)
    {
        var invalidCharsRgx = RegexHelpers.InvalidChars();
        var whiteSpace = RegexHelpers.WhiteSpace();
        var startsWithLowerCaseChar = RegexHelpers.StartsWithLowerCaseChar();
        var firstCharFollowedByUpperCasesOnly = RegexHelpers.FirstCharFollowedByUpperCasesOnly();
        var lowerCaseNextToNumber = RegexHelpers.LowerCaseNextToNumber();
        var upperCaseInside = RegexHelpers.UpperCaseInside();

        var pascalCase = invalidCharsRgx.Replace(whiteSpace.Replace(@string, "_"), string.Empty)
            .Split(['_'], StringSplitOptions.RemoveEmptyEntries)
            .Select(w => startsWithLowerCaseChar.Replace(w, m => m.Value.ToUpperInvariant()))
            .Select(w => firstCharFollowedByUpperCasesOnly.Replace(w, m => m.Value.ToLowerInvariant()))
            .Select(w => lowerCaseNextToNumber.Replace(w, m => m.Value.ToUpperInvariant()))
            .Select(w => upperCaseInside.Replace(w, m => m.Value.ToLowerInvariant()));

        return string.Concat(pascalCase);
    }

    public static Guid ToGuid(this string @string)
    {
        return Guid.Parse(@string);
    }

    public static bool IsGuid(this string @string)
    {
        return Guid.TryParse(@string, out _);
    }
}