using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hostellite std = new Hostellite();
            std.name = "Mohsin";
            std.roomNo = 10;
            Console.WriteLine(std.name + " is a " + std.roomNo);
        }
    }
}
