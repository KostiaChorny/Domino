using System;
using System.Collections.Generic;
using System.Linq;

namespace Domino
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your chain:");

            //Input data. Example: "12 23 34 45"
            string input = Console.ReadLine();
            List<string> dominos = input.Split(' ').ToList();

            try
            {
                var chain = new DominoChain(dominos);
                var result = chain.BuildUninterruptedChain();

                Console.WriteLine("Uninterupted chain:");
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                if (e.InnerException != null)
                {
                    Console.WriteLine("-->" + e.InnerException.Message);
                }
            }

            Console.ReadKey();
        }
    }
}
