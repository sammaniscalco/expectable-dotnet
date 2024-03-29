﻿using Expectable.Matchers;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Expectable.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            ping_expect();
            multiple_patterns();
            Console.ReadLine();
        }
        public static void ping_expect()
        {
            ExpectableProcess process = new ExpectableProcess("ping", "google.com");
            Session session = new Session(process);

            process.Start();
            session.Expect(new Patterns() {
                {"could not find",(output,sender)=>{
                    Console.WriteLine("Could Not Resolve ping host");
                } },
                { "timeout",(output,sender)=>{
                    Console.WriteLine("timeout pinging host");
                } },
                {"Ping statistics" ,(output,sender)=>{
                    Console.WriteLine("All done Pinging");
                } },
                { new Regex(@"Reply from ([0-9]{1,3}\.[0-9]{1,3}\.[[0-9]{1,3}\.[0-9]{1,3}).+time=([0-9]*ms).+TTL=([0-9]*)"),(output, sender) => {
                    List<string> matchGroups=output.ToList();
                    Console.WriteLine($"ping reply regex matchgroups-->");

                    //iterate over regex matchgroups (ip, time, ttl) 
                    for (int i=0; i<matchGroups.Count;i++)
                    {
                        Console.WriteLine($"    matchgroup: {i}, value: {matchGroups[i]}");
                    }

                    //continue expect flow
                    sender.Continue=true;
                } }
            });


            /****************************
             * Ping Output
             ****************************             
             > ping google.com

             Pinging google.com[64.233.185.101] with 32 bytes of data:
             Reply from 64.233.185.101: bytes = 32 time = 5ms TTL = 43
             Reply from 64.233.185.101: bytes = 32 time = 5ms TTL = 43
             Reply from 64.233.185.101: bytes = 32 time = 7ms TTL = 43
             Reply from 64.233.185.101: bytes = 32 time = 6ms TTL = 43

            Ping statistics for 64.233.185.101:
                Packets: Sent = 4, Received = 4, Lost = 0(0 % loss),
            Approximate round trip times in milli - seconds:
                Minimum = 5ms, Maximum = 7ms, Average = 5ms
            */

            /****************************
             * Example Expect Output
             ****************************                          
            ping reply regex matchgroups-->
                matchgroup: 0, value: 64.233.185.101
                 matchgroup: 1, value: 29ms
                 matchgroup: 2, value: 43
             ping reply regex matchgroups-->
                 matchgroup: 0, value: 64.233.185.101
                 matchgroup: 1, value: 5ms
                 matchgroup: 2, value: 43
             ping reply regex matchgroups-->
                 matchgroup: 0, value: 64.233.185.101
                 matchgroup: 1, value: 5ms
                 matchgroup: 2, value: 43
             ping reply regex matchgroups-->
                 matchgroup: 0, value: 64.233.185.101
                 matchgroup: 1, value: 8ms
                 matchgroup: 2, value: 43
             All done Pinging
             */
        }

        public static void multiple_patterns()
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

            /****************************
             * Example Expect Output
             ****************************
             
             Found pattern: Is, in output: Is
             Found pattern: this expected?, in output:  this expected?
             Found pattern: abc|def, in output: abc
             Found pattern: abc|def, in output: def
             Found pattern: Then a, in output: . Then a
             Found pattern: [0-9], in output: 0             
             */
        }
    }
}
