using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeactileMotion
{
    internal class GameObject
    {
        public char[,] Shape;
        public point StartingPoint;
        public boundary Premises;
        public string Direction;

        public GameObject()
        {
            Shape = new char[1, 3] {{ '-', '-', '-' }};
            StartingPoint = new point(0, 0);
            Premises = new boundary(new point(0, 0), new point(0, 90), new point(90, 0), new point(90, 90));
            Direction = "LeftToRight";
        }
        public GameObject(char[,] shape, point startingPoint)
        {
            this.Shape = shape;
            this.StartingPoint = startingPoint;
            Premises = new boundary(new point(0, 0), new point(0, 90), new point(90, 0), new point(90, 90));
            Direction = "LeftToRight";
        }
        public GameObject(char[,] shape, point startingPoint, boundary premises,string direction)
        {
            this.Shape = shape;
            this.StartingPoint = startingPoint;
            this.Premises = premises;
            this.Direction = direction;
        }
        public void Move()
        {
            if (Direction == "LeftToRight")
            {
                if (StartingPoint.getX() < Premises.TopRight.getX())
                {
                    StartingPoint.setX(StartingPoint.getX() + 1);
                }
            }
            else if (Direction == "RightToLeft")
            {
                if (StartingPoint.getX() > Premises.TopLeft.getX())
                {
                    StartingPoint.setX(StartingPoint.getX() - 1);
                }
            }
            else if (Direction == "petrol")
            {
                if (StartingPoint.getX() < Premises.TopRight.getX())
                {
                    StartingPoint.setX(StartingPoint.getX() + 1);
                }
                Direction = "petrol";
            }
            else if (Direction == "petrol")
            {
                if (StartingPoint.getX() > Premises.TopRight.getX())
                {
                    StartingPoint.setX(StartingPoint.getX() - 1);
                }
            }
        }
        public void erase()
        {
            for(int i = 0; i < 5; i++)
            {
                GotoXY(StartingPoint.getX(), StartingPoint.getY() + i);
                for(int j = 0; j < 3; j ++)
                {
                    Console.WriteLine("  ");
                }
                Console.WriteLine();
            }
        }
        public void draw()
        {
            for (int i = 0; i < 5; i++)
            {
                GotoXY(StartingPoint.getX(), StartingPoint.getY() + i);
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(Shape[i,j]);
                }
                Console.WriteLine();
            }
        }
        public void GotoXY(int x , int y)
        {
            Console.SetCursorPosition(x, y);
        }
    }
}
