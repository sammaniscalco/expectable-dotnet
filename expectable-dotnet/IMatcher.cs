
namespace Expectable
{
    public interface IMatcher
    {
        bool IsMatch(string output);
        string Pattern { get; }
    }
}
