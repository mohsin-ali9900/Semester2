using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    internal class GameObject
    {
        public char DisplayCharacter;
        public GameCell CurrentCell;
        public GameObjectType gameObjectType;

        public GameObject(char DisplayCharacter, GameCell CurrentCell)
        {
            this.DisplayCharacter = DisplayCharacter;
            this.CurrentCell = CurrentCell;
        }

        public GameObject(char displayCharacter,GameObjectType gameObjectType)
        {
            DisplayCharacter = displayCharacter;
            this.gameObjectType = gameObjectType;
        }

        public static GameObjectType GetObjectType(char displayCharacter)
        {
            if(displayCharacter == 'P')
            {
                return GameObjectType.PLAYER;
            }

            else if(displayCharacter == 'H' || displayCharacter == 'V' || displayCharacter == 'R' || displayCharacter == 'S')
            {
                return GameObjectType.ENEMY;
            }

            else if (displayCharacter == '|' || displayCharacter == '%' || displayCharacter == '#')
            {
                return GameObjectType.WALL;
            }

            else if (displayCharacter == '.')
            {
                return GameObjectType.REWARD;
            }

            else
            {
                return GameObjectType.None;
            }
        }
    }
}
