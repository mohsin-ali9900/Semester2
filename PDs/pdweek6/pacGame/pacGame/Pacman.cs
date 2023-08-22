using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;
using pacGame;

namespace Problem1
{
    class Pacman
    {
        public int X;
        public int Y;
        public Grid mazeGrid = new Grid();
        public int Score;

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
        public void Draw()
        {
            Gotoxy(X, Y);
            Console.WriteLine("P");
        }
        public void Remove()
        {
            Gotoxy(X, Y);
            Console.WriteLine(" ");
        }
        
        
        public void moveLeft(Cell current, Cell next)
        {
            if (next.value == ' ')
            {
                current.X -= 1;
            }
        }
        public void moveRight(Cell current, Cell next)
        {
            if (next.value == ' ')
            {
                current.X += 1;
            }
        }
        public void moveDown(Cell current, Cell next)
        {
            if (next.value == ' ')
            {
                current.Y += 1;
            }
        }
        public void moveUp(Cell current, Cell next)
        {
            if (next.value == ' ')
            {
                current.Y -= 1;
            }
        }
        
        public void move()
        {
            Cell obj = new Cell('P', X, Y);
            Grid G = new Grid();
            Cell Right = G.GetRightCell(obj);
            Cell Left = G.GetLeftCell(obj);
            Cell Up = G.GetUpCell(obj);
            Cell Down = G.GetDownCell(obj);

            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                moveRight(obj, Right);
            }
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                moveLeft(obj, Left);
            }
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                moveUp(obj, Up);
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                moveDown(obj, Down);
            }
        }
        public void PrintScore()
        {
            Gotoxy(77, 7);
            Console.WriteLine("Score : " + Score);
        }
    }
}