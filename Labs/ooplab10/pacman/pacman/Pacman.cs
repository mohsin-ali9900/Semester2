using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    internal class Pacman : GameObject
    {
        public Pacman(char DisplayCharacter,GameCell CurrentCell) : base(DisplayCharacter, CurrentCell)
        {

        }
    }
}
