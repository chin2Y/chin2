using System;
using System.Collections.Generic;
using System.Text;

namespace BenTheGamer
{
    public class Ruby
    {
        public static void Main1(string[] args)
        {
            int red, green, blue, yellow, length = 0;
            blue = Convert.ToInt32(Console.ReadLine());
            red = Convert.ToInt32(Console.ReadLine());
            yellow = Convert.ToInt32(Console.ReadLine());
            green = Convert.ToInt32(Console.ReadLine());
            if (red == 0 && yellow == 0)
            {
                length = blue > 0 ? blue : green;
            }
            else if (red == yellow)
            {
                length = red + green + blue + yellow;
            }
            else if (red == 0)
            {
                length = blue > 0 ? blue : yellow > 0 ? green + 1 : green;
            }
            else
            {
                length = red > yellow ? blue + green + 2 * Math.Min(red, yellow) + 1 : blue + green + 2 * Math.Min(red, yellow);
            }
            

            Console.WriteLine(length);
            Console.ReadKey();
        }
    }
}
