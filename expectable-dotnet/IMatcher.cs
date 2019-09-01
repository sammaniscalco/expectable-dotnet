
namespace Expectable
{
    public interface IMatcher
    {
        MatchResult IsMatch(string output);
        string Pattern { get; }
    }
}
