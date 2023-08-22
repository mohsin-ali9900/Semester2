using PacMan.GameGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManGUI.GameGL
{
    internal class HorizontalGhost : Ghost
    {
        public HorizontalGhost(Image img,GameCell startCell ) : base(img,startCell) { }

        GameDirection Hdirection = GameDirection.Left;
        public override GameCell move()
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(Hdirection);
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
            else if(Hdirection == GameDirection.Left || nextCell.CurrentGameObject.GameObjectType == GameObjectType.WALL)
            {
                Hdirection = GameDirection.Right;
            }
            else if(Hdirection == GameDirection.Right || nextCell.CurrentGameObject.GameObjectType == GameObjectType.WALL)
            {
                Hdirection=GameDirection.Left;
            }
            return tempCell;
        }
    }
}