using CoffeeShop.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DL
{
    internal class coffeeShopDL
    {
        public static List<menuItemBL> menuList = new List<menuItemBL>();

        public static menuItemBL getCheapestItem()
        {
            List<menuItemBL> orderedListOfItems = new List<menuItemBL>();
            orderedListOfItems = menuList.OrderBy(o => o.price).ToList();
            menuItemBL cheapestItem = orderedListOfItems[0];
            return cheapestItem;
        }
        public static void addItemInList(menuItemBL item)
        {
            menuList.Add(item);
        }
        public static bool checkOrderIfExists(string name)
        {
            bool flag = false;
            foreach(var n in menuList)
            {
                if(name == n.name)
                {
                    flag = true;
                }
            }
            return flag;
        }
    }

}
