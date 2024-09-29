using System.Text.RegularExpressions;

namespace BpMeter.Extensions;

public static class StringExtensions
{
    public static IEnumerable<string> SplitCamelCase(this string source)
    {
        const string pattern = @"[A-Z][a-z]*|[a-z]+|\d+";
        var matches = Regex.Matches(source, pattern);
        foreach (Match match in matches)
        {
            yield return match.Value;
        }
    }
}
