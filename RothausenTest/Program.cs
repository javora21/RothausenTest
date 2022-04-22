using PrimeNumbersCounter;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace RothausenTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> values = new List<string>
            {
                "1231231",
                "4564564",
                "789",
                "4",
                "4564564",
                "45432645756",
                "4564565",
                "4564566",
                "4564567",
                "4564564",
            };

            var pc = new PrimeCounter();
            Stopwatch sw= new Stopwatch();
            sw.Start();
            var res = pc.Count(values);
            sw.Stop();
            foreach (var value in res)
            {
                Console.WriteLine($"{value.Key}  ====> {value.Value}");
            }
        }
    }
}
