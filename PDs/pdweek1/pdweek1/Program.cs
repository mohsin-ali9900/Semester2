using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdweek1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Example1();
            Example2();
        }
        static void Example1()
        {
            Random rnd = new Random();
            double randomDouble = rnd.NextDouble();
            Console.WriteLine(randomDouble);
            Console.ReadKey();
        }
        static void Example2()
        {
            Console.WriteLine("I am Colourless.");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("I am Blue Coloured.");
            Console.ReadKey();
        }
    }
}
