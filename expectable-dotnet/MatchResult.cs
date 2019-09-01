using System;
using System.Collections.Generic;
using System.Text;

namespace Expectable
{
    public class MatchResult
    {
        public bool IsMatch { get; set; }
        public IOutput Ouput { get; set; }
    }
}
