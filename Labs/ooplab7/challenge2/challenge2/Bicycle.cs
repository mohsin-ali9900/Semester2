using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge2
{
    internal class Bicycle
    {
        protected int cadence;
        protected int gear;
        protected int speed;

        public Bicycle(int cadence,int gear,int speed)
        {
            this.cadence = cadence;
            this.gear = gear;
            this.speed = speed;
        }
           

    }
}
