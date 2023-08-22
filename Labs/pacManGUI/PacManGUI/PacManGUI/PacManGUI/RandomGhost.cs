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
    internal class RandomGhost : Ghost
    {
        public RandomGhost(Image img,GameCell currentCell) : base(img,currentCell)
        {

        }
        public int getRandomVariable()
        {
            Random rnd = new Random();
            int num = rnd.Next(4);
            return num;
        }
        GameDirection direction = GameDirection.Down;
        public override GameCell  move()
        {
            int num = getRandomVariable();
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(direction);
            GameObject nextObj = nextCell.CurrentGameObject;
            GameCell tempCell = new GameCell(nextCell.X, nextCell.Y, nextCell.gameGrid);
            tempCell.setGameObject(nextCell.CurrentGameObject);
            this.CurrentCell = nextCell;
            if(currentCell !=  nextCell)
            {
                if(PrevObj.GameObjectType == GameObjectType.REWARD)
                {
                    currentCell.setGameObject(Game.getRewardGameObject());
                }
                else
                {
                    currentCell.setGameObject(Game.getBlankGameObject());
                }
                PrevObj = nextObj;
            }
            if(num == 0)
            {
                direction = GameDirection.Down;
            }
            else if(num ==1)
            {
                direction = GameDirection.Up;
            }
            else if(num == 2)
            {
                direction = GameDirection.Left;
            }
            else if(num == 3)
            {
                direction = GameDirection.Right;
            }
            return tempCell;
        }
    }
}
