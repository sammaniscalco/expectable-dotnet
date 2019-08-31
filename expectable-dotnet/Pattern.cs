using Expectable.Matchers;
using System;
using System.Text.RegularExpressions;

namespace Expectable
{
    public class Pattern
    {
        public IMatcher Matcher { get; }
        public Action<string, Pattern> Handler { get; }
        public bool Continue { get; set; }

        /// <summary>
        /// Pattern constructor to map string to Contains Matcher
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="handler"></param>
        public Pattern(string pattern, Action<string, Pattern> handler)
        {
            this.Matcher = new ContainsMatcher(pattern);
            this.Handler = handler;
            this.Continue = false;
        }

        /// <summary>
        /// Pattern constructor to map Regex to Regex Matcher
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="handler"></param>
        public Pattern(Regex pattern, Action<string, Pattern> handler)
        {
            this.Matcher = new RegexMatcher(pattern.ToString());
            this.Handler = handler;
            this.Continue = false;
        }

        /// <summary>
        /// Pattern constructor for IMatcher interface
        /// </summary>
        /// <param name="matcher"></param>
        /// <param name="handler"></param>
        public Pattern(IMatcher matcher, Action<string, Pattern> handler)
        {
            this.Matcher = matcher;
            this.Handler = handler;
            this.Continue = false;
        }
    }
}
