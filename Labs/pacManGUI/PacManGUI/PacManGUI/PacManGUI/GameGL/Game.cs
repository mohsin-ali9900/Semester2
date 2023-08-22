using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace PacMan.GameGL
{
    public class Game
    {
        public static GameObject getBlankGameObject(){
            GameObject blankGameObject = new GameObject(GameObjectType.NONE, PacManGUI.Properties.Resources.simplebox);
            return blankGameObject;
        }
        public static GameObject getRewardGameObject()
        {
            GameObject rewardGameObject = new GameObject(GameObjectType.REWARD, PacManGUI.Properties.Resources.pallet);
            return rewardGameObject;
        }
        public static Image getGameObjectImage(char displayCharacter)
        {
            Image img = PacManGUI.Properties.Resources.simplebox;
            if (displayCharacter == '|' || displayCharacter == '%')
            {
                img = PacManGUI.Properties.Resources.vertical;
            }

            if (displayCharacter == '#')
            {
                img = PacManGUI.Properties.Resources.horizontal;
            }

            if (displayCharacter == '.')
            {
                img = PacManGUI.Properties.Resources.pallet;
            }
            if (displayCharacter == 'P' || displayCharacter == 'p') {
                img = PacManGUI.Properties.Resources.pacman_open;
            }
            if(displayCharacter == 'H')
            {
                img = PacManGUI.Properties.Resources.ghost_blue;
            }
            if(displayCharacter == 'V')
            {
                img = PacManGUI.Properties.Resources.ghost_orange;
            }
            if(displayCharacter == 'R')
            {
                img = PacManGUI.Properties.Resources.ghost_red;
            }
            if(displayCharacter == 'S')
            {
                img = PacManGUI.Properties.Resources.ghost_fright;
            }

            return img;
        }
    }
}
