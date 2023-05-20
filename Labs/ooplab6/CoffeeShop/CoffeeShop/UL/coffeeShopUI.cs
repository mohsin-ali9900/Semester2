using CoffeeShop.BL;
using CoffeeShop.DL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.UL
{
    public class coffeeShopUI
    {
        public static void PrintCheapestItem(menuItemBL cheap)
        {
            Console.WriteLine("Name : " + cheap.name + "Price : " + cheap.price);
        }
        public static void displayDrinks()
        {
            foreach(var mi in coffeeShopDL.menuList)
            {
                if (mi.type == "drink")
                {
                    Console.WriteLine("Name : " + mi.name);
                }
                
            }
            Console.ReadKey();
        }
        public static void displayFoods()
        {
            foreach (var mi in coffeeShopDL.menuList)
            {
                if (mi != null)
                {
                    if (mi.type == "food")
                    {
                        Console.WriteLine("Name : " + mi.name);
                    }
                }
            }
            Console.ReadKey();
        }
        public static void addOrder()
        {
            Console.WriteLine("Enter name of item you want to buy : ");
            string name = Console.ReadLine();
            bool flag = coffeeShopDL.checkOrderIfExists(name);
            if(flag == true)
            {
                coffeeShopBL.addOrderIntoList(name);
            }
            else
            {
                Console.WriteLine("This Item Is Currently Unavailable.");
                Console.ReadKey();
            }
        }
        public static void viewOrders()
        {
            if (coffeeShopBL.orders != null)
            {
                for (int i = 0; i < coffeeShopBL.orders.Count; i++)
                {
                    Console.WriteLine(coffeeShopBL.orders[i]);
                }
                Console.ReadKey();
            }
        }
        public static int viewPayableAmount()
        {
            int bill = 0;
            if(coffeeShopBL.orders != null)
            { 
                for (int i = 0; i < coffeeShopBL.orders.Count; i++)
                {
                    for(int j = 0; j < coffeeShopDL.menuList.Count; j++)
                    {
                        if (coffeeShopBL.orders[i] == coffeeShopDL.menuList[j].name)
                        {
                            bill = bill + coffeeShopDL.menuList[j].price;
                        }
                    }
                }
            }
            return bill;
        }
        public static void fulFilOrder(bool flag)
        {
            if(flag == true)
            {
                foreach (var l in coffeeShopBL.orders)
                {
                    Console.WriteLine(l + " item is ready.");
                }
                coffeeShopBL.orders = null;
            }
            else
            {
                Console.WriteLine("All orders have been fulfilled.");
            }
        }
        public static void displayPrice(int price)
        {
            Console.WriteLine("Payable Amount is : {0}",price);
        }
        

    }
}
