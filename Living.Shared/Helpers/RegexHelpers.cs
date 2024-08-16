using System.Text.RegularExpressions;

namespace Living.Shared.Helpers;
public static partial class RegexHelpers
{
    [GeneratedRegex("[^_a-zA-Z0-9]")]
    public static partial Regex InvalidChars();

    [GeneratedRegex(@"(?<=\s)")]
    public static partial Regex WhiteSpace();

    [GeneratedRegex("^[a-z]")]
    public static partial Regex StartsWithLowerCaseChar();

    [GeneratedRegex("(?<=[A-Z])[A-Z0-9]+$")]
    public static partial Regex FirstCharFollowedByUpperCasesOnly();

    [GeneratedRegex("(?<=[0-9])[a-z]")]
    public static partial Regex LowerCaseNextToNumber();

    [GeneratedRegex("(?<=[A-Z])[A-Z]+?((?=[A-Z][a-z])|(?=[0-9]))")]
    public static partial Regex UpperCaseInside();
}
