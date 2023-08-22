using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pacGame
{
    internal class Cell
    {
        public char value;
        public int X;
        public int Y;

        public Cell(char value, int X, int Y)
        {
            this.value = value;
            this.X = X;
            this.Y = Y;
        }
        public char GetValue()
        {
            return value;
        }
        public void SetValue(char value)
        {
            this.value = value;
        }
        public int GetX()
        {
            return X;
        }

        public int GetY()
        {
            return Y;
        }
        public bool isPacmanPresent()
        {
            bool flag = false;
            if (value == 'P')
            {
                flag = true;
            }
            return flag;
        }
        public bool isGhostPresent(char ghostCharacter)
        {
            bool flag = false;
            if (ghostCharacter == 'G')
            {
                flag = true;
            }
            return flag;
        }
    }
}
