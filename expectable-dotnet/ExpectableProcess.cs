using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Expectable
{
    public class ExpectableProcess : IExpectable
    {
        private Process _process;

        public ExpectableProcess(string fileName)
            : this(fileName, string.Empty)
        { }

        public ExpectableProcess(string fileName, string arguments)
        {
            _process = new Process();
            _process.StartInfo.FileName = fileName;
            _process.StartInfo.Arguments = arguments;
        }

        public void Start()
        {
            _process.StartInfo.UseShellExecute = false;
            _process.StartInfo.RedirectStandardInput = true;
            _process.StartInfo.RedirectStandardError = true;
            _process.StartInfo.RedirectStandardOutput = true;

            _process.Start();
        }

        public string Read()
        {
            var output = _process.StandardOutput.ReadLine();
            var error = _process.StandardError.ReadLine();
            if (!string.IsNullOrEmpty(output))
            {
                return output;
            }
            else if (!string.IsNullOrEmpty(error))
            {
                return error;
            }
            return string.Empty;

        }

        public void Write(string command)
        {
            _process.StandardInput.Write(command);
        }
    }
}
