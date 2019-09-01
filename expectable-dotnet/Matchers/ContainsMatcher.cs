
using Expectable.Outputs;

namespace Expectable.Matchers
{
    public class ContainsMatcher : IMatcher
    {
        public string Pattern { get; }

        public ContainsMatcher(string pattern)
        {
            Pattern = pattern;
        }        

        public MatchResult IsMatch(string output)
        {
            bool isMatch = output.Contains(Pattern);

            MatchResult match = new MatchResult()
            {
                Ouput = new StringOutput(output),
                IsMatch = isMatch
            };
            return match;
        }
    }
}
