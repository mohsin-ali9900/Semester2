using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeactileMotion
{
    internal class boundary
    {
        public point TopLeft;
        public point TopRight;
        public point BottomLeft;
        public point BottomRight;

        public boundary(point TL,point TR, point BL, point BR)
        {
            this.TopLeft = TL;
            this.TopRight = TR;
            this.BottomLeft = BL;
            this.BottomRight = BR;
        }
        public boundary()
        {
            TopLeft = new point(0,0);
            TopRight = new point(0,90);
            BottomLeft = new point(90,0);
            BottomRight = new point(90,90);
        }
    }
}
