using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp103
{
    internal class Card
    {
        internal int Value { get; }
        internal string Name { get;  }
        internal string Type { get;  }

        internal Card()
        {
            Random r = new Random();
            Value = r.Next(1, 14);
            int type = r.Next(1, 5);

            if (type == 1)
            {
                Type = "♣";
            }
            else if (type == 2)
            {
                Type = "♦";
            }
            else if (type == 3)
            {
                Type = "♥";
            }
            else if (type == 4)
            {
                Type = "♠";
            }

            if (Value == 1)
            {
                Name = "Ace";
            }
            else if (Value == 11)
            {
                Name = "Jack";
            }
            else if (Value == 12)
            {
                Name = "Queen";
            }
            else if (Value == 13)
            {
                Name = "King";
            }
            else
            {
                Name = Value.ToString();
            }
        }
    }
}
