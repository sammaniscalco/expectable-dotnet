
namespace Expectable.Matchers
{
    public class ContainsMatcher : IMatcher
    {
        public string Pattern { get; }

        public ContainsMatcher(string pattern)
        {
            Pattern = pattern;
        }        

        public bool IsMatch(string output)
        {
            return output.Contains(Pattern);
        }
    }
}
