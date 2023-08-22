using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    internal class VerticalGhost : Ghost
    {
        public GameDirection direction = GameDirection.DOWN;

        public VerticalGhost(char DisplayCharacter, GameCell CurrentCell) : base(DisplayCharacter, CurrentCell)
        {

        }

        public override void Move()
        {
            GameCell nextCell = CurrentCell.NextCell(direction);
            if (nextCell != null)
            {
                if (nextCell.gameObject.gameObjectType != GameObjectType.WALL)
                {
                    GameObject newGO = new GameObject(' ', GameObjectType.None);
                    GameCell currentCell = CurrentCell;
                    clearGameCellContent(currentCell, newGO);
                    CurrentCell = nextCell;
                    printGameObject(this);
                }

                else if (direction == GameDirection.DOWN && nextCell.gameObject.gameObjectType == GameObjectType.WALL)
                {
                    direction = GameDirection.UP;
                }

                else if (direction == GameDirection.UP && nextCell.gameObject.gameObjectType == GameObjectType.WALL)
                {
                    direction = GameDirection.DOWN;
                }
            }
        }
    }
}
