using Expectable.Matchers;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Expectable.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuffer stringBuffer = new StringBuffer();
            Session session = new Session(stringBuffer);
            int count = 0;

            //on new thread write to string buffer
            Task.Factory.StartNew(() =>
            {
                string str = "Is this expected? Time for abc and def. Then a number 0...";
                foreach (char c in str.ToCharArray())
                {
                    stringBuffer.Write(c.ToString());
                    Thread.Sleep(200);
                }
            });

            session.Expect(new Patterns() {
                //explicit regex matcher
                { new RegexMatcher("[0-9]"), (output,sender) => {
                    Console.WriteLine($"Found pattern: {sender.Matcher.Pattern}, in output: {output}");
                    count++;
                    //once it finds a number it will stop (no continue)
                } },
                //regex -> regex matcher
                { new Regex("abc|def"), (output,sender) => {
                    Console.WriteLine($"Found pattern: {sender.Matcher.Pattern}, in output: {output}");
                    count++;
                    //continue expect flow
                    sender.Continue=true;
                } },
                //explicit contains matcher
                { new ContainsMatcher("this expected?"), (output,sender)=>{
                    Console.WriteLine($"Found pattern: {sender.Matcher.Pattern}, in output: {output}");
                    count++;
                    //continue expect flow
                    sender.Continue=true;
                } },                
                 //string -> contains matcher
                { "Is", (output,sender) => {
                    Console.WriteLine($"Found pattern: {sender.Matcher.Pattern}, in output: {output}");
                    count++;
                    //continue expect flow
                    sender.Continue=true;
                } },
                //string -> contains matcher
                { "Then a", (s,sender) => {
                    Console.WriteLine($"Found pattern: {sender.Matcher.Pattern}, in output: {s}");
                    count++;
                    //continue expect flow
                    sender.Continue=true;
                } }
            });

            Console.WriteLine();
            Console.WriteLine($"All done, final count: {count}");

            Console.ReadLine();
        }
    }
}
