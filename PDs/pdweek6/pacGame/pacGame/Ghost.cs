using pacGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pacGame
{
    internal class Ghost
    {
        public int X;
        public int Y;
        public string ghostDirectipon;
        public char ghostCharacter;
        public float speed;
        public char previousItem;
        public float deltaChange;
        public Grid mazeGrid = new Grid();

        public Ghost(int x, int y, char ghostCharacter, string ghostDirection, float speed, char previousItem, float deltaChange, Grid mazeGrid)
        {
            this.X = x;
            this.Y = y;
            this.ghostDirectipon = ghostDirection;
            this.ghostCharacter = ghostCharacter;
            this.speed = speed;
            this.previousItem = previousItem;
            this.deltaChange = deltaChange;
            this.mazeGrid = mazeGrid;
        }
        public void setDirection(string ghostDirection)
        {
            this.ghostDirectipon = ghostDirection;
        }
        public string getDirection()
        {
            return ghostDirectipon;
        }
        public void GoToXY(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
        public void remove()
        {
            GoToXY(X, Y);
            Console.WriteLine(" ");
        }
        public void draw()
        {
            GoToXY(X, Y);
            Console.WriteLine("G");
        }
        public char getCharacter()
        {
            return ghostCharacter;
        }
        public void changeDelta()
        {
            deltaChange = deltaChange + speed;
        }
        public float getDelta()
        {
            return deltaChange;
        }
        public void setDeltaZero()
        {
            deltaChange = 0;
        }

        public void moveHorizontal()
        {
            string direction = getDirection();
            if (direction == "right")
            {
                if (mazeGrid.Maze[Y, X + 1].value == ' ')
                {
                    X++;
                }
                else
                {
                    setDirection("left");
                }
            }
            else if (direction == "left")
            {
                if (mazeGrid.Maze[Y, X - 1].value == ' ')
                {
                    X--;
                }
                else
                {
                    setDirection("right");
                }
            }
        }
        public void move(Grid MazeGrid)
        {
            changeDelta();
            if (Math.Floor(getDelta()) == 1)
            {
                if (ghostCharacter == 'H')
                {
                    moveHorizontal();
                }
                setDeltaZero();

            }
        }
        public void moveVertical()
        {
            string direction = getDirection();
            if (direction == "up")
            {
                if (mazeGrid.Maze[Y - 1, X].value == ' ')
                {
                    Y--;
                }
                else
                {
                    setDirection("down");
                }
            }
            else if (direction == "down")
            {
                if (mazeGrid.Maze[Y + 1, X].value == ' ')
                {
                     Y++;
                }
                else
                {
                    setDirection("up");
                }
            }
        }
    }
}
    