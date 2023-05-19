using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ships
{
    class Angle
    {
        public int Degree;
        public float Minutes;
        public char Direction;
        public Angle()
        {
            Console.WriteLine("Defult Constructor Called ::");
        }
        public Angle(int Deg, float min, char direct)
        {
            this.Degree = Deg;
            this.Minutes = min;
            this.Direction = direct;
        }
    }
}
