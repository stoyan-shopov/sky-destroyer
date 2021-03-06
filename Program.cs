﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Test
{

    class Program
    {
        enum GAME_PARAMS
        {
            ROWS = 10,
            START_VIDEO_ROW = 3,
            COLUMNS = 21,
            LEVEL_ROWS = 100,
            LIVES = 3,
        };

        static char[] rocks = new char[(int)GAME_PARAMS.COLUMNS];
        static char[,] field = new char[(int)GAME_PARAMS.LEVEL_ROWS + (int)GAME_PARAMS.ROWS, (int)GAME_PARAMS.COLUMNS];
        static char[] plane = new char[(int)GAME_PARAMS.COLUMNS];
        static int planepos = (int)GAME_PARAMS.COLUMNS / 2;
        static int lives = (int)GAME_PARAMS.LIVES, score = 0, row;

        static void update_game_status()
        {
            Console.SetCursorPosition(0, (int)GAME_PARAMS.START_VIDEO_ROW + (int)GAME_PARAMS.ROWS + 1);
            Console.WriteLine("lives: " + lives + " : score: " + score);
            Console.WriteLine("current row: " + ((int)GAME_PARAMS.LEVEL_ROWS - row - 1) + "        ");
        }
        static void update_plane_position()
        {
            int x = Console.CursorLeft, y = Console.CursorTop;

            Console.SetCursorPosition(0, (int)GAME_PARAMS.START_VIDEO_ROW + (int)GAME_PARAMS.ROWS);
            plane[planepos] = 'A';
            Console.Write('|');
            for (int i = 0; i < (int)GAME_PARAMS.COLUMNS; i++)
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
                    if (planepos < 0)
                    {
                        planepos = 0;
                    }
                }
                if (move.KeyChar == 's')
                {
                    planepos += 1;
                    if (planepos == (int) GAME_PARAMS.COLUMNS)
                    {
                        planepos = (int) GAME_PARAMS.COLUMNS - 1;
                    }
                }
            }
            update_plane_position();
        }

        static void Main(string[] args)
        {

            Console.CursorVisible = false;
            Console.WriteLine("  SKY DESTROYER ULTRA");
            Console.WriteLine("   coded by SS & SS");

            Console.Write('+');
            for (int i = 0; i < (int) GAME_PARAMS.COLUMNS; i++ )
                Console.Write('-');
            Console.WriteLine('+');
            Random rndrock = new Random();

            for (row = (int)GAME_PARAMS.ROWS; row < (int)GAME_PARAMS.LEVEL_ROWS; row++) // Generate level
            {
                if (rndrock.Next(100) > 80)
                    field[row, rndrock.Next(0, (int)GAME_PARAMS.COLUMNS)] = '$';
                else if (rndrock.Next(100) > 95)
                    field[row, rndrock.Next(0, (int)GAME_PARAMS.COLUMNS)] = 's';
                else
                    field[row, rndrock.Next(0, (int)GAME_PARAMS.COLUMNS)] = '*';
            }
            for (row = 0; row < (int)GAME_PARAMS.LEVEL_ROWS; row++) // Screen view " falling rocks"
            {
                Console.SetCursorPosition(0, (int)GAME_PARAMS.START_VIDEO_ROW);
                for (int i = (int)GAME_PARAMS.ROWS; i >= 0; i--)
                {
                    Console.Write('|');
                    for (int col = 0; col < (int)GAME_PARAMS.COLUMNS; col++)
                    {
                        Thread.Sleep(1);
                        Console.Write(field[row + i, col]);
                        planeposition();
                    }
                    Console.WriteLine('|');
                }

                if (field[row, planepos] == '$')
                    score += 10;
                else if (field[row, planepos] == 's')
                    score += 100;
                else if (field[row, planepos] == '*')
                    lives--;
                score++;
                update_game_status();
                if (lives == 0)
                    break;
            }
            Console.WriteLine("GAME OVER");
            Console.WriteLine("your score is: " + score);
            Console.ReadKey(true);
        }
    }
} 
        
