using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cl1
{
    internal class Menu
    {
        private int minStrelochka;
        private int maxStrelochka;

        public Menu(int min, int max)
        {
            minStrelochka = min;
            maxStrelochka = max;
        }
        public static int Show(int minStrelochka, int maxStrelochka)
        {
            int pos = 1;
            ConsoleKeyInfo info;
            Console.CursorVisible = false;
            do
            {
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("->");

                info = Console.ReadKey();

                Console.SetCursorPosition(0, pos);
                Console.WriteLine("  ");

                if (info.Key == ConsoleKey.UpArrow && pos != minStrelochka)
                {
                    pos--;
                }
                else if (info.Key == ConsoleKey.DownArrow && pos != maxStrelochka)
                {
                    pos++;
                }
                else if (info.Key == ConsoleKey.Escape)
                {
                    return -1;
                }
                //return post;
            }
            while (info.Key != ConsoleKey.Enter);
            return pos;
        }
    }
}
