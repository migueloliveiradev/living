using Living.Shared.Helpers;
using System.Text.RegularExpressions;

namespace Living.Shared.Extensions;
public static partial class StringExtensions
{
    public static string ToPascalCase(this string @string)
    {

        Regex invalidCharsRgx = RegexHelpers.InvalidChars();
        Regex whiteSpace = RegexHelpers.WhiteSpace();
        Regex startsWithLowerCaseChar = RegexHelpers.StartsWithLowerCaseChar();
        Regex firstCharFollowedByUpperCasesOnly = RegexHelpers.FirstCharFollowedByUpperCasesOnly();
        Regex lowerCaseNextToNumber = RegexHelpers.LowerCaseNextToNumber();
        Regex upperCaseInside = RegexHelpers.UpperCaseInside();

        var pascalCase = invalidCharsRgx.Replace(whiteSpace.Replace(@string, "_"), string.Empty)
            .Split(['_'], StringSplitOptions.RemoveEmptyEntries)
            .Select(w => startsWithLowerCaseChar.Replace(w, m => m.Value.ToUpper()))
            .Select(w => firstCharFollowedByUpperCasesOnly.Replace(w, m => m.Value.ToLower()))
            .Select(w => lowerCaseNextToNumber.Replace(w, m => m.Value.ToUpper()))
            .Select(w => upperCaseInside.Replace(w, m => m.Value.ToLower()));

        return string.Concat(pascalCase);
    }
}