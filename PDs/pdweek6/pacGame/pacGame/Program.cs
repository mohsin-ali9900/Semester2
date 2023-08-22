using pacGame;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "maze.txt";
            Grid MazeGrid = new Grid(21, 71, path);
            Pacman player = new Pacman(12, 24, MazeGrid);
            Console.ReadKey();
            MazeGrid.printMaze();
            while (true)
            {
                Thread.Sleep(50);
                player.Remove();
                player.move();
                player.Draw();
            }
        }

    }
}