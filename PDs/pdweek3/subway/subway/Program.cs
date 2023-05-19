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
            coord.printJack(jack);
            coord.printGlados(glados);
            Console.ReadKey();

            while (true)
            {
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    coord.moveUp(maze, jack);
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    coord.moveDown(maze, jack);
                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    coord.moveLeft(maze, jack);
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    coord.moveRight(maze, jack);
                }
                if (Keyboard.IsKeyPressed(Key.Space))
                {
                    coord.generateBullet(bb, maze);
                }
                coord.bulletCollisionWithGlados(maze, bb, ref score);
                coord.printScore(ref score);
                coord.moveBullet(bb, maze);
                coord.moveGlados(glados, maze, ref gladosDirection);
                Thread.Sleep(100);
            }
        }

        
        static void readMaze(char[,] maze)
        {
            StreamReader file = new StreamReader("maze.txt");
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
