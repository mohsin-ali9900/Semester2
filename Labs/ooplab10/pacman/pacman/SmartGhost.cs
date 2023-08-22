using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    internal class SmartGhost : Ghost
    {
        GameDirection direction = GameDirection.DOWN;
        public GameCell pacCell;
        public SmartGhost(char DisplayCharacter, GameCell CurrentCell) : base(DisplayCharacter, CurrentCell)
        {

        }

        public override void SetCell(ref GameCell G)
        {
            pacCell = G;
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
            }

            if (CurrentCell.X > pacCell.X)
            {
                direction = GameDirection.UP;
            }

            else if (CurrentCell.X < pacCell.X)
            {
                direction = GameDirection.DOWN;
            }

            if (CurrentCell.Y < pacCell.Y)
            {
                direction = GameDirection.RIGHT;
            }

            else if (CurrentCell.Y > pacCell.Y)
            {
                direction = GameDirection.LEFT;
            }
        }

    }
}
