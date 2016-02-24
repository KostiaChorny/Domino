using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    class DominoChain
    {
        private List<Domino> dominos;

        public DominoChain(List<string> dominos)
        {
            this.dominos = ConvertFromStrings(dominos);
        }

        public DominoChain(List<Domino> dominos)
        {
            this.dominos = dominos;
        }

        private List<Domino> ConvertFromStrings(List<string> list)
        {
            var result = new List<Domino>();
            foreach (var item in list)
            {
                var domino = new Domino(item);
                result.Add(domino);
            }
            return result;
        }

        public DominoChain BuildUninterruptedChain()
        {
            var input = new List<Domino>(dominos);
            var result = new List<Domino>();

            var current = input[0];
            input.RemoveAt(0);

            var leftNumber = current.LeftNumber;
            var rightNumber = current.RightNumber;

            result.Add(current);

            while (input.Count > 0)
            {
                var i = input.FirstOrDefault(d => d.LeftNumber == rightNumber);
                if (i != null)
                {
                    input.Remove(i);
                    result.Add(i);
                    rightNumber = i.RightNumber;
                    continue;
                }

                i = input.FirstOrDefault(d => d.RightNumber == rightNumber);
                if (i != null)
                {
                    input.Remove(i);
                    rightNumber = i.LeftNumber;
                    result.Add(i.SwapLetters());
                    continue;
                }

                i = input.FirstOrDefault(d => d.LeftNumber == leftNumber);
                if (i != null)
                {
                    input.Remove(i);
                    leftNumber = i.RightNumber;
                    result.Insert(0, i.SwapLetters());
                    continue;
                }

                i = input.FirstOrDefault(d => d.RightNumber == leftNumber);
                if (i != null)
                {
                    input.Remove(i);
                    leftNumber = i.LeftNumber;
                    result.Insert(0, i);
                    continue;
                }

                throw new Exception("That it's impossible to create uninterrupted chain");
            }

            return new DominoChain(result);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var domino in this.dominos)
            {
                builder.Append(domino);
                builder.Append(" - ");
            }

            builder.Remove(builder.Length - 3, 3);
            return builder.ToString();
        }
    }
}
