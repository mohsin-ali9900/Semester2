using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    internal class RandomGhost : Ghost
    {
        GameDirection direction = GameDirection.DOWN;

        public RandomGhost(char DisplayCharacter, GameCell CurrentCell) : base(DisplayCharacter, CurrentCell)
        {

        }
        public int RandomDirection()
        {
            Random r = new Random();
            int num = r.Next(4);
            return num;
        }
        public override void Move()
        {
            char character = ' ';
            GameObjectType type = GameObjectType.None;
            int direc = RandomDirection();
            GameCell nextCell = CurrentCell.NextCell(direction);
            if (nextCell != null)
            {
                if (nextCell.gameObject.gameObjectType != GameObjectType.WALL)
                {
                    if(nextCell.gameObject.gameObjectType == GameObjectType.REWARD)
                    {
                        character = '.';
                        type = GameObjectType.REWARD;
                    }
                    GameObject newGO = new GameObject(character, type);
                    GameCell currentCell = CurrentCell;
                    clearGameCellContent(currentCell, newGO);
                    CurrentCell = nextCell;
                    printGameObject(this);
                }

                if(direc == 0)
                {
                    direction = GameDirection.LEFT;
                }

                else if (direc == 1)
                {
                    direction = GameDirection.RIGHT;
                }

                else if (direc == 2)
                {
                    direction = GameDirection.UP;
                }

                else if (direc == 3)
                {
                    direction = GameDirection.DOWN;
                }
            }
        }
    }
}
