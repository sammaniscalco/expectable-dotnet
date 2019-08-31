
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

        public bool IsMatch(string output)
        {
            return output.Equals(Pattern);
        }
    }
}
