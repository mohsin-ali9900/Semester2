using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeactileMotion
{
    internal class point
    {
        int x;
        int y;

        public point()
        {

        }
        public point(int xx,int yy)
        {
            this.x = xx;
            this.y = yy;
        }
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        public void setX(int xx)
        {
            this.x = xx;
        }
        public void setY(int yy)
        {
            this.y = yy;
        }
    }
}
