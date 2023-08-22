using PacMan.GameGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManGUI.GameGL
{
    internal abstract class Ghost : GameObject
    {
        public abstract GameCell move();
        public Ghost(Image image, GameCell startCell) : base(GameObjectType.ENEMY, image)
        {
            this.CurrentCell = startCell;
        }

        public GameObject PrevObj = Game.getBlankGameObject();   
        public Ghost(GameObjectType type, Image image) : base(type, image)
        {
        }
    }
}
