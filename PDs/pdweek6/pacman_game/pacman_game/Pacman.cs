using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;

namespace Problem1
{
    class Pacman
    {
        public int X;
        public int Y;
        public int Score;
        public Grid mazeGrid = new Grid();

        public Pacman(int x, int y, Grid mazegrid)
        {
            this.X = x;
            this.Y = y;
            this.mazeGrid = mazegrid;
        }
        public void Gotoxy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
        public void Remove()
        {
            Gotoxy(X, Y);
            Console.WriteLine(" ");
        }
        public void Draw()
        {
            Gotoxy(X, Y);
            Console.WriteLine("P");
        }
        public void MoveRight(Cell current, Cell next)
        {
            if (next.Value == ' ')
            {
                current.X += 1;
            }
        }
        public void MoveLeft(Cell current, Cell next)
        {
            if (next.Value == ' ')
            {
                current.X -= 1;
            }
        }
        public void MoveUp(Cell current, Cell next)
        {
            if (next.Value == ' ')
            {
                current.Y -= 1;
            }
        }
        public void MoveDown(Cell current, Cell next)
        {
            if (next.Value == ' ')
            {
                current.Y += 1;
            }
        }
        public void Move()
        {
            Cell obj = new Cell('P', X, Y);
            Grid G = new Grid();
            Cell Right = G.GetRightCell(obj);
            Cell Left = G.GetLeftCell(obj);
            Cell Up = G.GetUpCell(obj);
            Cell Down = G.GetDownCell(obj);

            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                MoveRight(obj, Right);
            }
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                MoveLeft(obj, Left);
            }X
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                MoveUp(obj, Up);
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                MoveDown(obj, Down);
            }
        }
        public void PrintScore()
        {
            Gotoxy(80, 5);
            Console.WriteLine("Score: " + Score);
        }
    }
}