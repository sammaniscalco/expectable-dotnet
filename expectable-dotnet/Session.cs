using System;
using System.Threading;
using System.Threading.Tasks;

namespace Expectable
{

    public class Session
    {
        private readonly IExpectable _expectable;

        //10 seconds
        private readonly int _defaultTimeout = 10000;
        private int _timeout;

        public Session(IExpectable expectable)
        {
            _timeout = _defaultTimeout;
            _expectable = expectable;
        }

        /// <summary>
        /// Sends characters to the session.
        /// </summary>
        /// <remarks>
        /// To send enter you have to add '\n' at the end.
        /// </remarks>
        /// <example>
        /// Send("cmd.exe\n");
        /// </example>
        /// <param name="command">String to be sent to session</param>
        public void Send(string command)
        {
            _expectable.Write(command);
        }

        public void Expect(Pattern pattern)
        {
            Expect(new Patterns { pattern });
        }

        public void Expect(Patterns patterns)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken ct = tokenSource.Token;

            string output = string.Empty;
            IOutput matchOutput = null;
            bool isFound = false;
            Pattern foundPattern = null;

            Task task = Task.Factory.StartNew(() =>
            {
                //while not timed out and not found
                while (!ct.IsCancellationRequested && !isFound)
                {
                    //read new process output
                    output += _expectable.Read();

                    //loop through expected patterns
                    foreach (Pattern pattern in patterns)
                    {
                        MatchResult result = pattern.Matcher.IsMatch(output);

                        //is this pattern a match on the output
                        if (result.IsMatch)
                        {
                            matchOutput = result.Ouput;
                            isFound = true;                            
                            foundPattern = pattern;
                            break;
                        }
                    }
                }
            }, ct);

            if (task.Wait(_timeout, ct))
            {
                if (foundPattern != null && foundPattern.Handler != null)
                {
                    //execute handler logic
                    foundPattern.Handler(matchOutput, foundPattern);

                    //if continue rerun expects
                    if (foundPattern.Continue)
                    {
                        Expect(patterns);
                    }
                }
            }
            else
            {
                tokenSource.Cancel();
                throw new TimeoutException();
            }
        }

        /// <summary>
        /// Timeout value in miliseconds for Expect function
        /// </summary>
        public int Timeout
        {
            get { return _timeout; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Value must be larger than zero");
                }
                _timeout = value;
            }
        }

        public void ResetTimeout()
        {
            Timeout = _defaultTimeout;
        }
    }
}

