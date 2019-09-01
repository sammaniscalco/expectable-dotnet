
using Expectable.Outputs;

namespace Expectable.Matchers
{
    //exact matcher
    public class ExactMatcher : IMatcher
    {
        public string Pattern { get; }

        public ExactMatcher(string pattern)
        {
            Pattern = pattern;
        }

        public MatchResult IsMatch(string output)
        {
            bool isMatch = output.Equals(Pattern);

            MatchResult match = new MatchResult() {
                Ouput = new StringOutput(output),
                IsMatch = isMatch
            };
            return match;
        }
    }
}
