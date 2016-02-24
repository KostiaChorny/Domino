using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your chain:");

            string input = Console.ReadLine();
            List<string> dominos = input.Split(' ').ToList();

            try
            {
                var chain = new DominoChain(dominos);
                var result = chain.BuildUninterruptedChain();

                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
