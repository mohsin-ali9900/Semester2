using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace projeactileMotion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] triangle = new char[5, 3] { { '@', ' ', ' ' }, { '@', '@', ' ' }, {'@', '@', '@' }, { ' ', '@', '@' }, { ' ', ' ', '@' } };
            char[,] opTriangle = new char[5, 3] { { ' ', ' ', '@' }, { ' ', '@', '@' }, { '@', '@', '@' }, { '@', '@', ' ' }, { '@', ' ', ' ' } };

            boundary b = new boundary(new point(0, 0), new point(90, 0), new point(0, 90), new point(90, 90));
            GameObject g1 = new GameObject(triangle, new point(5, 5),b, "petrol");
            GameObject g2 = new GameObject(opTriangle, new point(30, 40), b, "RightToLeft");
            List<GameObject> lst = new List<GameObject>();
            lst.Add(g1);
            lst.Add(g2);
            Console.ReadKey();
            //Thread.Sleep(2000);
            while (true)
            {
                Thread.Sleep(5);
                foreach(GameObject g in lst)
                {
                    g.erase();
                    g.Move();
                    g.draw();
                }
            }
        }
    }
}
