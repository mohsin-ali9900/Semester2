using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            products[] pro = new products[10];
            char option;
            int sum = 0;
            int count = 0;
            do
            {
                option = menu();
                if (option == '1')
                {
                    pro[count] = addProduct();
                    count++;
                }
                else if (option == '2')
                {
                    viewProducts(pro, count);

                }
                else if (option == '3')
                {
                    sum = netWorth(pro, count);
                    Console.WriteLine("Net Worth is : {0}", sum);
                    Console.ReadKey();
                }
                else if (option == '4')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input.");
                }
            }
            while (option != '4');
        }
        static char menu()
        {
            Console.Clear();
            char choice;
            Console.WriteLine("Press 1 for adding product.");
            Console.WriteLine("Press 2 for viewing products.");
            Console.WriteLine("Press 3 for viewing nte worth.");
            Console.WriteLine("Press 4 for exit.");
            choice = char.Parse(Console.ReadLine());
            return choice;
        }
        static products addProduct()
        {
            Console.Clear();
            products p1 = new products();
            Console.WriteLine("Enter ID : ");
            p1.id = Console.ReadLine();
            Console.WriteLine("Enter name : ");
            p1.name = (Console.ReadLine());
            Console.WriteLine("Enter category : ");
            p1.category = Console.ReadLine();
            Console.WriteLine("Enter brand name : ");
            p1.brandName = Console.ReadLine();
            Console.WriteLine("Enter country : ");
            p1.country = Console.ReadLine();
            Console.WriteLine("Enter price : ");
            p1.price = int.Parse(Console.ReadLine());
            return p1;
        }
        static void viewProducts(products[] p, int count)
        {
            Console.Clear();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("id : {0} , name : {1} , category : {2} , brand : {3} , country : {4} , price : {5}", p[i].id, p[i].name, p[i].category, p[i].brandName, p[i].country, p[i].price);
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static int netWorth(products[] pro, int count)
        {
            int net = 0;
            for(int i = 0; i < count; i++)
            {
                net = net + pro[i].price;
            }
            return net;
        }
    }
    
}
