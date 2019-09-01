using Expectable.Outputs;
using System.Collections.Generic;
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

        public MatchResult IsMatch(string output)
        {
            List<string> matchGroups = new List<string>();

            var regexMatch = Regex.Match(output, Pattern, RegexOptions.Singleline);

            if (regexMatch.Success)
            {
                if (regexMatch.Groups.Count > 2)
                {
                    for (int g = 1; g < regexMatch.Groups.Count; g++)
                    {
                        matchGroups.Add(regexMatch.Groups[g].Value);
                    }
                }
                //get first/last capture group
                else
                {
                    matchGroups.Add(regexMatch.Groups[regexMatch.Groups.Count - 1].Value);
                }
            }

            MatchResult match = new MatchResult()
            {
                Ouput = new ListOutput(matchGroups),
                IsMatch = regexMatch.Success
            };
            return match;
        }
    }
}

