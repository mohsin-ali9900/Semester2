using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.BL
{
    public class coffeeShopBL
    {
        public string shopName;
        public static List<string> orders = new List<string>();

        public coffeeShopBL(string nameOfShop)
        {
            this.shopName = nameOfShop;
        }

        
        public static void addOrderIntoList(string order)
        {
            orders.Add(order);
        }

        public static bool checkOrderListIfEmpty()
        {
            bool flag = false;
            if(orders != null)
            {
                flag = true;
            }
            return flag;
        }
        public static void fulFilOrder()
        {
            bool flag = checkOrderListIfEmpty();
            if (flag == true)
            {

            }
        }
    }
}
