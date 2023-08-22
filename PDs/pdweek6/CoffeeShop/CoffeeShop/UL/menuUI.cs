using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.UL
{
    internal class menuUI
    {
        public static int mainMenu()
        {
            Console.WriteLine("1. Add a menu item.");
            Console.WriteLine("2. View the cheapest item in the menu.");
            Console.WriteLine("3. View Drinks menu.");
            Console.WriteLine("4. View Foods menu.");
            Console.WriteLine("5. Add Order.");
            Console.WriteLine("6. Fullfill the Order.");
            Console.WriteLine("7. View the orders list.");
            Console.WriteLine("8. Total payable amount.");
            Console.WriteLine("9. Exit.");
            Console.WriteLine("Enter Option Number : ");
            int option = int.Parse(Console.ReadLine());
            return option;
        }
    }
}
