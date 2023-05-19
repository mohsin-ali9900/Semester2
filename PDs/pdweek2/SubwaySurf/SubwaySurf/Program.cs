using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using EZInput;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Data;
using System.Xml.Linq;

namespace SubwaySurf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string gladosDirection = "down";

            char[,] jack = { { '#', '#', '#' }, { '>', '>', '>' }, { '#', '#', '#' } };
            char[,] glados = { { '(', '-', ' ', '-', ')' }, { '<', '|', ' ', '|', '>' }, { ' ', '\\', '_', '/', ' ' }, { ' ', ' ', '!', ' ', ' ' } };

            coordinates coord = new coordinates();
            List<bullet> bb = new List<bullet>();
            char[,] maze = new char[34, 129];
            int score = 0;

            Console.Clear();
            readMaze(maze);

            printMaze(maze);
            printJack(coord, jack);
            printGlados(coord, glados);
            Console.ReadKey();

            while (true)
            {
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    moveUp(maze, coord, jack);
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    moveDown(maze, coord, jack);
                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    moveLeft(maze, coord, jack);
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    moveRight(maze, coord, jack);
                }
                if (Keyboard.IsKeyPressed(Key.Space))
                {
                    generateBullet(bb, coord, maze);
                }
                bulletCollisionWithGlados(maze, coord, bb, ref score);
                printScore(ref score);
                moveBullet(bb, coord, maze);
                moveGlados(glados, maze, ref gladosDirection, coord);
                Thread.Sleep(100);
            }
        }

        static void gotoxy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
        static void readMaze(char[,] maze)
        {
            StreamReader file = new StreamReader("E:\\oops\\lab1\\pdweek2\\SubwaySurf\\maze.txt");
            string record;
            int row = 0;
            while ((record = file.ReadLine()) != null)
            {
                for (int x = 0; x < 128; x++)
                {
                    maze[row, x] = record[x];
                }
                row++;
            }

            file.Close();
        }
        static void printMaze(char[,] maze)
        {

            for (int x = 0; x < 34; x++)
            {

                for (int y = 0; y < 129; y++)
                {
                    Console.Write(maze[x, y]);
                }

                Console.WriteLine();
            }
        }
        static char getCharAtxy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            char charAtPos = keyInfo.KeyChar;
            return charAtPos;
        }
        static void printJack(coordinates coord, char[,] jack)
        {
            for (int row = 0; row < 3; row++)
            {
                gotoxy(coord.JX, coord.JY + row);
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(jack[row, col]);
                }
            }
        }
        static void printGlados(coordinates coord, char[,] glados)
        {
            for (int rows = 0; rows < 4; rows++)
            {
                gotoxy(coord.GX, coord.GY + rows);
                for (int col = 0; col < 5; col++)
                {
                    Console.Write(glados[rows, col]);
                }
            }
        }
        static void erazeJack(coordinates coord)
        {
            for (int row = 0; row < 3; row++)
            {
                gotoxy(coord.JX, coord.JY + row);
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(" ");
                }
            }
        }
        static void erazeGlados(coordinates coord)
        {
            for (int row = 0; row < 4; row++)
            {
                gotoxy(coord.GX, coord.GY + row);
                for (int col = 0; col < 5; col++)
                {
                    Console.Write(" ");
                }
            }
        }
        static void moveRight(char[,] maze, coordinates coord, char[,] jack)
        {
            if (maze[coord.JY, coord.JX + 3] == ' ')
            {
                erazeJack(coord);
                coord.JX++;
                printJack(coord, jack);
            }
        }

        static void moveLeft(char[,] maze, coordinates coord, char[,] jack)
        {
            if (maze[coord.JY - 0, coord.JX - 1] == ' ')
            {
                erazeJack(coord);
                coord.JX--;
                printJack(coord, jack);
            }
        }

        static void moveUp(char[,] maze, coordinates coord, char[,] jack)
        {
            if (maze[coord.JY - 1, coord.JX - 0] == ' ')
            {
                erazeJack(coord);
                coord.JY--;
                printJack(coord, jack);
            }
        }

        static void moveDown(char[,] maze, coordinates coord, char[,] jack)
        {
            if (maze[coord.JY + 3, coord.JX + 0] == ' ')
            {
                erazeJack(coord);
                coord.JY++;
                printJack(coord, jack);
            }
        }

        static void moveGlados(char[,] glados, char[,] maze, ref string gladosDirection, coordinates coord)
        {
            if (gladosDirection == "down")
            {
                if (maze[coord.GY + 4, coord.GX] == ' ')
                {
                    erazeGlados(coord);
                    coord.GY++;
                    printGlados(coord, glados);
                }
                else
                {
                    gladosDirection = "up";
                }
            }

            if (gladosDirection == "up")
            {
                if (maze[coord.GY - 1, coord.GX] == ' ')
                {
                    erazeGlados(coord);
                    coord.GY--;
                    printGlados(coord, glados);
                }
                else
                {
                    gladosDirection = "down";
                }
            }
        }
        static void generateBullet(List<bullet> bb, coordinates coord, char[,] maze)
        {
            char next = maze[coord.JY + 5, coord.JX];
            if (next == ' ')
            {
                bullet bul = new bullet();
                bul.bulletX = coord.JX + 5;
                bul.bulletY = coord.JY;
                bul.isBulletActive = true;
                bb.Add(bul);
                gotoxy(coord.JX + 5, coord.JY + 1);
                Console.Write(".");
            }

        }
        static void printBullet(int x, int y)
        {
            gotoxy(x, y);
            Console.Write(".");
        }
        static void eraseBullet(int x, int y)
        {
            gotoxy(x, y);
            Console.Write(" ");
        }
        static void moveBullet(List<bullet> bul, coordinates coord, char[,] maze)
        {
            for (int i = 0; i < bul.Count; i++)
            {
                if (bul[i].isBulletActive == true)
                {
                    char nextlocation = maze[bul[i].bulletY + 1, bul[i].bulletX + 1];
                    if (nextlocation == ' ')
                    {
                        eraseBullet(bul[i].bulletX, bul[i].bulletY + 1);
                        bul[i].bulletX++;
                        printBullet(bul[i].bulletX, bul[i].bulletY + 1);
                    }
                    else
                    {
                        eraseBullet(bul[i].bulletX, bul[i].bulletY + 1);
                        bul[i].isBulletActive = false;
                    }
                }
            }
        }
        static void bulletCollisionWithGlados(char[,] maze, coordinates coord, List<bullet> bul, ref int score)
        {
            for (int i = 0; i < bul.Count; i++)
            {
                if (bul[i].isBulletActive == true)
                {
                    if (bul[i].bulletX + 1 == coord.GX && (bul[i].bulletY + 1 == coord.GY || bul[i].bulletY + 1 == coord.GY + 1 || bul[i].bulletY + 1 == coord.GY + 2 || bul[i].bulletY + 1 == coord.GY + 3))
                    {
                        score = score + 1;
                    }
                    printScore(ref score);
                }
            }
        }
        static void printScore(ref int score)
        {
            gotoxy(100, 35);
            Console.WriteLine("Score: {0}", score);
        }
    }


}

        /*static void printHeader()
        {
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            Console.WriteLine("@@                                                                                                              @@");
            Console.WriteLine("@@ ####### ##    ## ######  ##     ##  #####  ##    ##     ######  ##    ## ###    ## ###    ## ####### ######  @@");
            Console.WriteLine("@@ ##      ##    ## ##   ## ##     ## ##   ##  ##  ##      ##  ##  ##    ## ####   ## ####   ## ##      ##  ##  @@");
            Console.WriteLine("@@ ####### ##    ## ######  ##  #  ## #######   ####       ######  ##    ## ## ##  ## ## ##  ## #####   ######  @@");
            Console.WriteLine("@@      ## ##    ## ##   ## ## ### ## ##   ##    ##        ## ##   ##    ## ##  ## ## ##  ## ## ##      ## ##   @@");
            Console.WriteLine("@@ #######  ######  ######   ### ###  ##   ##    ##        ##   ##  ######  ##   #### ##   #### ####### ##   ## @@");
            Console.WriteLine("@@                                                                                                              @@");
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
        }*/
      