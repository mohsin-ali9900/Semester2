using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    internal class GameCell
    {
        public int X;
        public int Y;
        public GameGrid gameGrid;
        public GameObject gameObject;

        public GameCell(int x, int y, GameGrid gameGrid)
        {
            X = x;
            Y = y;
            this.gameGrid = gameGrid;
        }

        public GameCell NextCell(GameDirection direction)
        {

            if (direction == GameDirection.RIGHT)
            {
                return gameGrid.GetCell(X, Y + 1);
            }

            else if (direction == GameDirection.LEFT)
            {
                return gameGrid.GetCell(X, Y - 1);
            }

            else if (direction == GameDirection.UP)
            {
                return gameGrid.GetCell(X - 1, Y);
            }

            else if (direction == GameDirection.DOWN)
            {
                return gameGrid.GetCell(X + 1, Y);
            }

            else
            {
                return null;
            }

        }
    }
}
