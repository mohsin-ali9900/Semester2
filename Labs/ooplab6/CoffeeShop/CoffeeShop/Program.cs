using CoffeeShop.BL;
using CoffeeShop.DL;
using CoffeeShop.UL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
                string path = "menuItem.txt";
                bool read = menuItemBL.readItem(path);
                if(read == true)
                {
                    Console.WriteLine("Data Read Suucessfull.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("File Does NOT Exists.");
                    Console.ReadKey();
                }
            while(option != 9)
            {
                Console.Clear();
                option = menuUI.mainMenu();
                if(option == 1)
                {
                    menuItemBL item = menuItemUI.takeAndAddInputOfMenuItems();
                    coffeeShopDL.addItemInList(item);
                    item.storeItem(path);
                }
                else if(option == 2)
                {
                    menuItemBL chepestItems = coffeeShopDL.getCheapestItem();
                    coffeeShopUI.PrintCheapestItem(chepestItems);
                    Console.ReadKey();
                }
                else if (option == 3)
                {
                    //Console.WriteLine("hh");
                    coffeeShopUI.displayDrinks();
                    
                }
                else if (option == 4)
                {
                    coffeeShopUI.displayFoods();
                }
                else if (option == 5)
                {
                    coffeeShopUI.addOrder();
                }
                else if (option == 6)
                {
                    bool flag = coffeeShopBL.checkOrderListIfEmpty();
                    coffeeShopUI.fulFilOrder(flag);
                    Console.ReadKey();
                }
                else if (option == 7)
                {
                    coffeeShopUI.viewOrders();
                }
                else if (option == 8)
                {
                    int price = coffeeShopUI.viewPayableAmount();
                    coffeeShopUI.displayPrice(price);
                    Console.ReadKey();
                }
            }
        }
    }
}
