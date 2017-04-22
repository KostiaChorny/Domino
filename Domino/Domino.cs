using System;

namespace Domino
{
    /// <summary>
    /// Class for domino
    /// </summary>
    class Domino
    {
        private string data;

        public Domino(string item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            if (item.Length != 2)
                throw new ArgumentException("Item must be a two chars string");
            this.data = item;
        }

        /// <summary>
        /// Number on left side of domino
        /// </summary>
        public char LeftNumber
        {
            get { return data[0]; }
        }

        /// <summary>
        /// Number on right side of domino
        /// </summary>
        public char RightNumber
        {
            get { return data[1]; }
        }

        /// <summary>
        /// Swap left side to the right, and right side to the left
        /// </summary>
        /// <returns>Swapped domino</returns>
        internal Domino SwapLetters()
        {
            var str = data[1].ToString() + data[0];
            return new Domino(str);
        }

        /// <summary>
        /// Convert domino to the string representation
        /// </summary>
        /// <returns>String represetation of domino</returns>
        public override string ToString()
        {
            return data;
        }
    }
}
