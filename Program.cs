using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static char[] rocks = new char[20];
        static char[,] field = new char[100, 20];
        static char[] plane = new char[20];
        static int planepos = 10;
        static int rock = 0;

        static void planeposition()
        {

            if (Console.KeyAvailable)
            {
                plane[planepos] = '\0';
                ConsoleKeyInfo move = Console.ReadKey();
                if (move.KeyChar == 'a')
                {
                    planepos -= 1;
                    if (planepos < 1)
                    {
                        planepos = 1;
                    }
                }
                if (move.KeyChar == 's')
                {
                    planepos += 1;
                    if (planepos > 19)
                    {
                        planepos = 19;
                    }
                }

            }
        }

        static void Main(string[] args)
        {

            Console.WriteLine("S T A R T");

            for (int row = 10; row < 100; row++) // Generate level
            {
                int rockcheck = rock;
                Thread.Sleep(10);
                Random rndrock = new Random();
                rock = rndrock.Next(0, 20);

                for (int col = 0; col < 20; col++)
                {
                    if (rock != rockcheck)
                    {
                        field[row, rock] = '*';
                        rocks[rock] = '\0';
                    }
                    else
                    {
                        field[row, rock] = '\0';
                    }
                }
            }
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
            for (int row = 0; row < 99; row++) // Screen view " falling rocks"
            {

                Thread.Sleep(500);
                for (int i = 10; i >= 0; i--)
                {
                    Console.Write('|');
                    for (int col = 0; col < 20; col++)
                    {
                        Console.Write(field[row + i, col]);
                    }
                    Console.WriteLine('|');
                    //planeposition();
                }

                plane[planepos] = 'A';
                Thread.Sleep(50);
                Console.Write('|');
                for (int i = 0; i < 20; i++)
                {
                    Console.Write(plane[i]);
                }
                Console.WriteLine('|');
                planeposition();

                if (planepos == rock)
                {
                    //Console.WriteLine("boom");
                }
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 12);
            }
        }
    }
} 
        