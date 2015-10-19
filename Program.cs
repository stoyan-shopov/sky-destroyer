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
        enum GAME_PARAMS
        {
            ROWS = 11,
            COLUMNS = 20,
        };

        static char[] rocks = new char[20];
        static char[,] field = new char[100, 20];
        static char[] plane = new char[20];
        static int planepos = 10;
        static int rock = 0;

        static void update_plane_position()
        {
            int x = Console.CursorLeft, y = Console.CursorTop;

            Console.SetCursorPosition(0, 10);
            plane[planepos] = 'A';
            Console.Write('|');
            for (int i = 0; i < 20; i++)
            {
                Console.Write(plane[i]);
            }
            Console.Write('|');
            Console.SetCursorPosition(x, y);
        }
        static void planeposition()
        {

            if (Console.KeyAvailable)
            {
                plane[planepos] = '\0';
                ConsoleKeyInfo move = Console.ReadKey(true);
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
            update_plane_position();
        }

        static void Main(string[] args)
        {

            Console.WriteLine("S T A R T");
            Console.CursorVisible = false;

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
            for (int row = 0; row < 99; row++) // Screen view " falling rocks"
            {
                Console.SetCursorPosition(0, 0);
                Thread.Sleep(500);
                for (int i = 10; i >= 0; i--)
                {
                    Console.Write('|');
                    for (int col = 0; col < 20; col++)
                    {
                        Console.Write(field[row + i, col]);
                    }
                    Console.WriteLine('|');
                    planeposition();
                }

                if (planepos == rock)
                {
                    //Console.WriteLine("boom");
                }
            }
        }
    }
} 
        
