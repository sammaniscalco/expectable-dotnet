using System;
using System.Collections.Generic;
using System.Text;

namespace Expectable.Outputs
{
    public class StringOutput : IOutput
    {
        private readonly string _value;

        public StringOutput(string value)
        {
            _value = value;
        }

        public List<string> ToList()
        {
            return new List<string>() { _value };
        }

        public override string ToString()
        {
            return _value;
        }
    }
}
