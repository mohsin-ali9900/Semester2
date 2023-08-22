using CoffeeShop.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.UL
{
    internal class menuItemUI
    {
        public static menuItemBL takeAndAddInputOfMenuItems()
        { 
                Console.WriteLine("Enter name of product : ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter type of product : ");
                string type = Console.ReadLine();
                Console.WriteLine("Enter price of product : ");
                int price = int.Parse(Console.ReadLine());
                menuItemBL mi = new menuItemBL(name, type, price);
                return mi;
        }
    }
}
