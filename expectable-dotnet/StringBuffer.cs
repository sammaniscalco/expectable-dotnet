using Expectable;
using System;
using System.Collections.Generic;
using System.Text;

namespace Expectable
{
    public class StringBuffer : IExpectable
    {
        private StringBuilder _sb;
        private static object _lock = new object();

        public StringBuffer()
        {
            _sb = new StringBuilder();
        }

        public string Read()
        {
            int end = 0;
            //does string builder have content
            if (_sb.Length > 0)
            {
                //lock string builder incase its being written too
                lock (_lock)
                {
                    //process word by word
                    end = _sb.ToString().IndexOf(" ");
                    if (end >= 0)
                    {
                        return ReadBufferLine(end);
                    }
                    //get what else is in there
                    return ReadBufferLine(_sb.Length - 1);
                }
            }
            return string.Empty;
        }

        public void Write(string value)
        {
            lock (_lock)
            {
                _sb.Append(value);
            }
        }

        private string ReadBufferLine(int end)
        {
            string line = _sb.ToString().Substring(0, end + 1);
            _sb.Remove(0, end + 1);
            return line;
        }
    }
}
