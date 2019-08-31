using System.Text.RegularExpressions;

namespace Expectable.Matchers
{
    public class RegexMatcher : IMatcher
    {
        public string Pattern { get; }

        public RegexMatcher(string pattern)
        {
            Pattern = pattern;
        }

        public RegexMatcher(Regex regex)
        {
            Pattern = regex.ToString();
        }

        public bool IsMatch(string output)
        {
            var match = Regex.Match(output, Pattern, RegexOptions.Singleline);

            if (match.Success)
            {
                output = string.Empty;

                if (match.Groups.Count > 2)
                {
                    for (int g = 1; g < match.Groups.Count; g++)
                    {
                        output += $"{match.Groups[g].Value}|";
                    }
                }
                //get first/last capture group
                else
                {
                    output = match.Groups[match.Groups.Count - 1].Value;
                }
            }
            return match.Success;
        }
    }
}

