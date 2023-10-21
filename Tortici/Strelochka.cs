using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class Strelochka
    {
        private int minStrelochka;
        private int maxStrelochka;
        private int position;

        public Strelochka(int min, int max, int pos)
        {
            minStrelochka = min;
            maxStrelochka = max;
            position = pos;
        }
        public static int Show(int minStrelochka, int maxStrelochka, int position = 1)
        {
            ConsoleKeyInfo key;

            do
            {
                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");

                key = Console.ReadKey();
                Console.SetCursorPosition(0, position);
                Console.WriteLine("  ");

                if (key.Key == ConsoleKey.UpArrow)
                    if (position != minStrelochka)
                        position--;
                    else
                        position = maxStrelochka;
                else if (key.Key == ConsoleKey.DownArrow)
                    if (position != maxStrelochka)
                        position++;
                    else
                        position = minStrelochka;

            } while (key.Key != ConsoleKey.Enter);
            Console.Clear();
            return position;            
        }
    }

}
