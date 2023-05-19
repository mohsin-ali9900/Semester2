using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            customer cust = new customer();
            int choice = 0;
            while(choice != 4)
            {
                menu();
                customer data = new customer();
                Console.WriteLine("Input choice :");
                choice = int.Parse(Console.ReadLine());
                if(choice == 1)
                {
                    data = inputInfo();
                }
                else if(choice == 2)
                {
                    inputProduct(data);
                }
                else if(choice == 3)
                {
                    List<product> custtt = new List<product>();
                    custtt = data.showProducts();
                    for(int i = 0; i < custtt.Count();i++)
                    {
                        Console.WriteLine("{0}", custtt[i].productName);
                    }
                }
                else if (choice== 4)
                {
                    break;
                }
            }      
        }

        static customer inputInfo()
        {
            Console.WriteLine("Enter Name : ");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter Address : ");
            string Address = Console.ReadLine();
            Console.WriteLine("Enter Contact : ");
            int Contact = int.Parse(Console.ReadLine());

            customer info = new customer(Name,Address,Contact);
            return info;
        }

        static void inputProduct(customer custo)
        {

            float taxx = 0.0F;
            while(true)
            {
                Console.WriteLine("DO you want to add product (Y/N) : ");
                char permit = char.Parse(Console.ReadLine());
                if (permit == 'Y' || permit == 'y')
                {
                    Console.WriteLine("Enter product Name : ");
                    string Name = Console.ReadLine();
                    Console.WriteLine("Enter Product Type : ");
                    string Type = Console.ReadLine();
                    Console.WriteLine("Enter Product price : ");
                    int Price = int.Parse(Console.ReadLine());
                    product info = new product(Name, Type, Price);
                    taxx = taxx + info.calculateTax();
                    custo.assignToList(info);
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Tax is : {0}", taxx);
            Console.ReadKey();
        }

        static void menu()
        {
            Console.WriteLine("1. Input info of Customer. ");
            Console.WriteLine("2. Input info of product. ");
            Console.WriteLine("3. Display products. ");
            Console.WriteLine("4. Exit.");
        }
    }
}
