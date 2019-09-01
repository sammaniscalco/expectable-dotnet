using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Expectable
{
    public class Patterns : List<Pattern>
    {
        public void Add(string pattern, Action<IOutput, Pattern> handler)
        {
            Add(new Pattern(pattern, handler));
        }

        public void Add(Regex pattern, Action<IOutput, Pattern> handler)
        {
            Add(new Pattern(pattern, handler));
        }

        public void Add(IMatcher matcher,  Action<IOutput, Pattern> handler)
        {
            Add(new Pattern(matcher, handler));
        }
    }

}
