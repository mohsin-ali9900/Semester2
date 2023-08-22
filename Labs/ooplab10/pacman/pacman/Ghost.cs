using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    internal abstract class Ghost : GameObject
    {
        public Ghost(char DisplayCharacter,GameCell CurrentCell) : base(DisplayCharacter,CurrentCell) 
        {

        }

        public abstract void Move();

        public virtual void SetCell(ref GameCell Cell)
        {

        }
        public void clearGameCellContent(GameCell gameCell, GameObject newGameObject)
        {
            gameCell.gameObject = newGameObject;
            Console.SetCursorPosition(gameCell.Y, gameCell.X);
            Console.Write(newGameObject.DisplayCharacter);
        }
        public void printGameObject(GameObject gameObject)
        {
            Console.SetCursorPosition(gameObject.CurrentCell.Y, gameObject.CurrentCell.X);
            Console.Write(gameObject.DisplayCharacter);
        }
    }
}
