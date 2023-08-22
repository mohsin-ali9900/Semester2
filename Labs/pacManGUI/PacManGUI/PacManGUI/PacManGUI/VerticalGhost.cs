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
    internal class VerticalGhost : Ghost
    {
        public VerticalGhost(Image img, GameCell startCell) : base(img, startCell) { }

        GameDirection Vdirection = GameDirection.Up;

        public override GameCell move()
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(Vdirection);
            GameObject nextObject = nextCell.CurrentGameObject;
            GameCell tempCell = new GameCell(nextCell.X, nextCell.Y, nextCell.gameGrid);
            tempCell.setGameObject(nextCell.CurrentGameObject);
            this.CurrentCell = nextCell;
            if (currentCell != nextCell)
            {
                if(PrevObj.GameObjectType == GameObjectType.REWARD)
                {
                    currentCell.setGameObject(Game.getRewardGameObject());
                }
                else
                {
                    currentCell.setGameObject(Game.getBlankGameObject());
                }
                PrevObj = nextObject;
            }
            else if (Vdirection == GameDirection.Up || nextCell.CurrentGameObject.GameObjectType == GameObjectType.WALL)
            {
                Vdirection = GameDirection.Down;
            }
            else if (Vdirection == GameDirection.Down|| nextCell.CurrentGameObject.GameObjectType == GameObjectType.WALL)
            {
                Vdirection = GameDirection.Up;
            }
            return tempCell;
        }
    }
}
