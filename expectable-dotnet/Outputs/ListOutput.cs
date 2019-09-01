using System;
using System.Collections.Generic;
using System.Text;

namespace Expectable.Outputs
{
    public class ListOutput : IOutput
    {
        private readonly List<string> _values;

        public ListOutput(List<string> values)
        {
            _values = values;
        }

        public List<string> ToList()
        {
            return _values;
        }

        public override string ToString()
        {
            return string.Join('|', _values);
        }
    }
}
