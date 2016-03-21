using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domino
{
    /// <summary>
    /// Dominos chain class
    /// </summary>
    class DominoChain
    {
        private List<Domino> dominos;

        public DominoChain(List<string> dominos)
        {
            this.dominos = ConvertFromStrings(dominos);
        }

        public DominoChain(List<Domino> dominos)
        {
            if (dominos == null)
                throw new ArgumentNullException("dominos");
            if (dominos.Count == 0)
                throw new ArgumentException("Can't create empty chain. List of dominos is empty");

            this.dominos = dominos;
        }

        private List<Domino> ConvertFromStrings(List<string> list)
        {
            if (list == null)
                throw new ArgumentNullException("list");
            if (list.Count == 0)
                throw new ArgumentException("Can't create empty chain. List of strings is empty");

            var result = new List<Domino>();
            try
            {
                foreach (var item in list)
                {
                    var domino = new Domino(item);
                    result.Add(domino);
                }
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("One of strings have a wrong format", ex);
            }
            return result;
        }

        /// <summary>
        /// Buids uninterupted chain for current dominos chain
        /// </summary>
        /// <returns>Uninterupted dominos chain</returns>
        public DominoChain BuildUninterruptedChain()
        {
            var input = new List<Domino>(dominos);
            var result = new List<Domino>();

            // Selecting first domino
            var current = input[0];
            input.RemoveAt(0);

            var leftNumber = current.LeftNumber;
            var rightNumber = current.RightNumber;

            result.Add(current);

            // Growing chain from the left and the right 
            while (input.Count > 0)
            {
                // Adding next domino to the right side of the chain
                var i = input.FirstOrDefault(d => d.LeftNumber == rightNumber);
                if (i != null)
                {
                    input.Remove(i);
                    result.Add(i);
                    rightNumber = i.RightNumber;
                    continue;
                }

                // Adding next domino to the right side of the chain with swaping
                i = input.FirstOrDefault(d => d.RightNumber == rightNumber);
                if (i != null)
                {
                    input.Remove(i);
                    rightNumber = i.LeftNumber;
                    result.Add(i.SwapLetters());
                    continue;
                }

                // Adding next domino to the left side of the chain with swaping
                i = input.FirstOrDefault(d => d.LeftNumber == leftNumber);
                if (i != null)
                {
                    input.Remove(i);
                    leftNumber = i.RightNumber;
                    result.Insert(0, i.SwapLetters());
                    continue;
                }

                // Adding next domino to the left side of the chain
                i = input.FirstOrDefault(d => d.RightNumber == leftNumber);
                if (i != null)
                {
                    input.Remove(i);
                    leftNumber = i.LeftNumber;
                    result.Insert(0, i);
                    continue;
                }

                throw new Exception("Unable to create uninterrupted chain");
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
