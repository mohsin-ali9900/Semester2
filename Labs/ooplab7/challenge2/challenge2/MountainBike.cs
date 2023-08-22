using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge2
{
    internal class MountainBike : Bicycle
    {
        public int seatHeight;
        MountainBike(int seatHeight,int cadence,int gear,int speed):base (cadence,gear,speed)
        {
            this.seatHeight = seatHeight;
        }

        public void jj()
        {
            
        }
    }
}
