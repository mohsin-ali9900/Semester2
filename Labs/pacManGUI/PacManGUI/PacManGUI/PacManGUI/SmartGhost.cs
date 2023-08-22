using PacMan.GameGL;
using PacManGUI.GameGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManGUI
{
    internal class SmartGhost : Ghost
    {
        GamePacManPlayer player;
        public SmartGhost(Image image, GameCell cell, GamePacManPlayer pacman) : base(GameObjectType.ENEMY, image)
        {
            this.player = pacman;
            this.CurrentCell = cell;
        }

        public override GameCell move()
        {
            double[] distances = new double[4] { 00000, 00000, 00000, 00000 };
            GameDirection direction = GameDirection.Left;
            GameCell nextCell = this.CurrentCell.nextCell(direction);
            GameCell tempCell = new GameCell(nextCell.X, nextCell.Y, nextCell.gameGrid);
            tempCell.setGameObject(nextCell.CurrentGameObject);
            if (nextCell != CurrentCell)
            {
                distances[0] = distance(nextCell, player.CurrentCell);
            }
            direction = GameDirection.Right;
            nextCell = this.CurrentCell.nextCell(direction);
            if (nextCell != CurrentCell)
            {
                distances[1] = distance(nextCell, player.CurrentCell);
            }
            direction = GameDirection.Up;
            nextCell = this.CurrentCell.nextCell(direction);
            if (nextCell != CurrentCell)
            {
                distances[2] = distance(nextCell, player.CurrentCell);
            }
            direction = GameDirection.Down;
            nextCell = this.CurrentCell.nextCell(direction);
            if (nextCell != CurrentCell)
            {
                distances[3] = distance(nextCell, player.CurrentCell);
            }
            if (distances[0] < distances[1] && distances[0] < distances[2] && distances[0] < distances[3])
            {
                direction = GameDirection.Left;
            }
            else if (distances[1] < distances[0] && distances[1] < distances[2] && distances[1] < distances[3])
            {
                direction = GameDirection.Right;
            }
            else if (distances[2] < distances[1] && distances[2] < distances[0] && distances[2] < distances[3])
            {
                direction = GameDirection.Up;
            }
            else if (distances[3] < distances[1] && distances[3] < distances[2] && distances[3] < distances[3])
            {
                direction = GameDirection.Down;
            }
            GameCell tempcurrentCell = this.CurrentCell;
            GameCell NextCell = tempcurrentCell.nextCell(direction);
            GameObject nextObj = NextCell.CurrentGameObject;
            this.CurrentCell = NextCell;
            if (tempcurrentCell != NextCell)
            {
                if (PrevObj.GameObjectType == GameObjectType.REWARD)
                {
                    tempcurrentCell.setGameObject(Game.getRewardGameObject());
                }
                else
                {
                    tempcurrentCell.setGameObject(Game.getBlankGameObject());
                }
                PrevObj = nextObj;
            }
            return tempCell;
        }
        double distance(GameCell cell1, GameCell cell2)
        {
            return (Math.Sqrt(((cell1.X - cell2.X) * (cell1.X - cell2.X) + (cell1.Y - cell2.Y) * (cell1.Y - cell2.Y))));
        }
    }
}
