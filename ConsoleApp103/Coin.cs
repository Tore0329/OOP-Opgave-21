using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp103
{
    internal class Coin
    {
        internal string State { get; }

        internal Coin()
        {
            Random r = new Random();
            int n = r.Next(1, 3);

            if (n == 1)
            {
                State = "Heads";
            }
            else
            {
                State = "Tails";
            }
        }
    }
}
