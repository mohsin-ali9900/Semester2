using CoffeeShop.DL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.BL
{
    public class menuItemBL
    {
        public string name;
        public string type;
        public int price;

        public menuItemBL(string Name, string Type, int Price)
        {
            this.name = Name;
            this.type = Type;
            this.price = Price;
        }

        public void storeItem(string path)
        {
            StreamWriter file = new StreamWriter(path,true);
            Console.WriteLine(name + "," + type + "," + price);
            file.Close();
        }
        public static bool readItem(string path)
        {
            if(File.Exists(path))
            {
                StreamReader file = new StreamReader(path,true);
                string record;
                while((record = file.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string name = splittedRecord[0];
                    string type = splittedRecord[1];
                    int price = int.Parse(splittedRecord[2]);
                    menuItemBL m = new menuItemBL(name, type, price);
                    coffeeShopDL.addItemInList(m);
                }
                file.Close();
                return true;
            }
            return false;
        }
    }
}
