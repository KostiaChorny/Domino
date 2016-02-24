using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    class Domino
    {
        private string data;

        public Domino(string item)
        {
            this.data = item;
        }

        public char LeftNumber
        {
            get { return data[0]; }
        }

        public char RightNumber
        {
            get { return data[1]; }
        }

        internal Domino SwapLetters()
        {
            var str = data[1].ToString() + data[0];
            return new Domino(str);
        }

        public override string ToString()
        {
            return data;
        }
    }
}
