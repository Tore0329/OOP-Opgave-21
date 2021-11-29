using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp103
{
    internal class Spin
    {
        internal int Value { get; }

        internal string Color { get; }

        internal string State { get; }

        internal Spin()
        {
            Random r = new Random();
            Value = r.Next(0, 37);

            if (Value == 0)
            {
                State = null;
                Color = "Green";
            }
            if (Value%2 == 0)
            {
                State = "Even";
                Color = "Red";
            }
            else
            {
                State = "Odd";
                Color = "Black";
            }
        }
    }
}
