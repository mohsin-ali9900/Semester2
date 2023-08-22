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
            Grid mazegrid = new Grid(21, 71, path);
            Pacman player = new Pacman(9, 32, mazegrid);
            Console.ReadKey();

            mazegrid.PrintMaze();
            while (true)
            {
                Thread.Sleep(90);

                player.Remove();
                player.Move();
                player.Draw();
            }
            Console.ReadKey();
        }

    }
}