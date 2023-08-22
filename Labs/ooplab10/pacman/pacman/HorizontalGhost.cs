using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    internal class HorizontalGhost : Ghost
    {
        public GameDirection direction = GameDirection.RIGHT;

        public HorizontalGhost(char DisplayCharacter, GameCell CurrentCell) : base(DisplayCharacter, CurrentCell)
        {

        }

        public override void Move()
        {
            GameCell nextCell = CurrentCell.NextCell(direction);
            if(nextCell != null)
            {
                if(nextCell.gameObject.gameObjectType != GameObjectType.WALL)
                {
                    GameObject newGO = new GameObject(' ', GameObjectType.None);
                    GameCell currentCell = CurrentCell;
                    clearGameCellContent(currentCell, newGO);
                    CurrentCell = nextCell;
                    printGameObject(this);
                }

                else if(direction == GameDirection.LEFT && nextCell.gameObject.gameObjectType == GameObjectType.WALL)
                {
                    direction = GameDirection.RIGHT;
                }

                else if (direction == GameDirection.RIGHT && nextCell.gameObject.gameObjectType == GameObjectType.WALL)
                {
                    direction = GameDirection.LEFT;
                }
            }
        }



    }
}
