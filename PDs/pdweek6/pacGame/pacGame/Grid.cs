using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pacGame
{
    internal class Grid
    {
        public Cell[,] Maze;
        public int rowsize;
        public int colsize;
        public string path;

        public Grid()
        {

        }
        public Grid(int rowsize, int colsize, string path)
        {
            this.rowsize = rowsize;
            this.colsize = colsize;
            this.path = path;
        }

        public Cell GetLeftCell(Cell C)
        {
            C.X = C.X--;
            C.SetValue(Maze[C.X, C.Y].value);
            Cell c = new Cell(C.value, C.X, C.Y);
            return c;
        }
        public Cell GetRightCell(Cell C)
        {
            C.X = C.X++;
            C.SetValue(Maze[C.X, C.Y].value);
            Cell c = new Cell(C.value, C.X, C.Y);
            return c;
        }
        public Cell GetUpCell(Cell C)
        {
            C.Y = C.Y--;
            C.SetValue(Maze[C.X, C.Y].value);
            Cell c = new Cell(C.value, C.X, C.Y);
            return c;
        }
        public Cell GetDownCell(Cell C)
        {
            C.Y = C.Y++;
            C.SetValue(Maze[C.X, C.Y].value);
            Cell c = new Cell(C.value, C.X, C.Y);
            return c;
        }
        public Cell FindPacman()
        {
            for (int i = 0; i < rowsize; i++)
            {
                for (int j = 0; j < colsize; j++)
                {
                    if (Maze[i, j].value == 'P')
                    {
                        Cell C = new Cell(Maze[i, j].value, i, j);
                        return C;
                    }
                }
            }
            return null;
        }
        public Cell FindGhost(char ghoatCharacter)
        {
            for (int i = 0; i < rowsize; i++)
            {
                for (int j = 0; j < colsize; j++)
                {
                    if (Maze[i, j].value == ghoatCharacter)
                    {
                        Cell C = new Cell(Maze[i, j].value, i, j);
                        return C;
                    }
                }
            }
            return null;
        }
        public void readMaze()
        {
            StreamReader file = new StreamReader(path);
            string record;
            int row = 0;
            if ((record = file.ReadLine()) != null)
            {
                for (int i = 0; i < colsize - 1; i++)
                {
                    Cell c = new Cell(record[i], row, i);
                    Maze[row, i] = c;
                }
                row++;
            }
        }
        public void printMaze()
        {
            for (int i = 0; i < rowsize; i++)
            {
                for (int j = 0; j < colsize; j++)
                {
                    Console.WriteLine(Maze[i, j].value);
                }
            }
        }
    }
}

