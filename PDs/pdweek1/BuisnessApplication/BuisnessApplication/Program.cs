using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // GLOBAL
            const int arraysize = 100;
            string[] name = new string[arraysize];
            string[] password = new string[arraysize];
            string[] role = new string[arraysize];
            int count = 0, countbill = 0;

            int mainmedicineCount = 0;
            int size = 50;
            string[] medicinename = new string[size]; 
            //string[] medicinename = new string[size];
            /*medicinename[0] =  "Panadol";
            medicinename[1] =  "Aspirin";
            medicinename[2] =  "asdf";
            medicinename[3] =  "asdffgd";
            medicinename[4] =  "asdfdfgd";*/
            //int[] prices = { 50, 40, 70, 90, 74 };
            int[] prices = new int[size];
            //int[] quantity = { 10, 20, 15, 26, 17 };
            int[] quantity = new int[size];
            string[] allusernames = new string[50];
            int[] allbills = new int[50];
            string[] alluserpasswords = new string[50];
            // GLOBAL

            Console.Clear();
            string username, userpassword, userrole;
            char choice = ' ';
            bool checkChoices;

            string path = "E:\\oops\\lab1\\pdweek1\\BuisnessApplication\\signup.txt";
            string path1 = "E:\\oops\\lab1\\pdweek1\\BuisnessApplication\\medicine.txt";

            while (choice != '3')
            {
                readSignUp(path,name,password,role,ref count);
                readMedicine(path1, medicinename, prices, quantity, ref mainmedicineCount);
                Console.Clear();
                loginmenu();
                Console.WriteLine("Enter the choice : ");
                choice = char.Parse(Console.ReadLine());
                if (choice == '2')
                {
                    Console.Clear();
                    header();
                    Console.WriteLine("        SIGN UP >        ");
                    Console.WriteLine("*************************");
                    Console.WriteLine("Enter the username : ");
                    username = Console.ReadLine();
                    Console.WriteLine("Enter the password : ");
                    userpassword = Console.ReadLine();
                    Console.WriteLine("Enter the role : ");
                    userrole = Console.ReadLine();

                    if ((username.Length > 2) && (userpassword.Length > 2) && (userrole == "admin" || userrole == "customer"))
                    {
                        signup(username, userpassword, userrole,name,password,role, ref count);
                        writeSignUp(path, username, userpassword, userrole);
                        //writeSignUp();
                    }
                    else
                    {
                        Console.WriteLine("Invalid username,password or role");
                        Console.ReadKey();
                    }
                }
                else if (choice == '1')
                {
                    Console.Clear();
                    header();
                    Console.WriteLine("         LOGIN >         ");
                    Console.WriteLine("*************************");
                    Console.WriteLine("Enter the username : ");
                    username = Console.ReadLine();
                    Console.WriteLine("Enter the password : ");
                    userpassword = Console.ReadLine();
                    string output = login(username, userpassword,name,password,role,ref count);
                    if (output == "admin")
                    {
                        char choices=' ';
                        while (choices != '0')
                        {
                            admin();
                            Console.WriteLine("Enter the option : ");
                            choices = char.Parse(Console.ReadLine());

                            if (choices == '1')
                            {
                                Console.Clear();
                                header();
                                Console.WriteLine("        ADD STOCK >        ");
                                Console.WriteLine("*************************");
                                string addnewmedicine;
                                int newmedicineprice, newmedicinequantity;

                                Console.WriteLine("Enter name of medicine to added : ");
                                addnewmedicine = Console.ReadLine();
                                Console.WriteLine("Enter price of new medicine : ");
                                newmedicineprice = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter quantity of new medicine : ");
                                newmedicinequantity = int.Parse(Console.ReadLine());
                                //mainmedicineCount++;
                                addstock(medicinename, prices,quantity,ref mainmedicineCount,addnewmedicine,ref newmedicineprice,ref newmedicinequantity);
                                writeMedicine(path1, ref mainmedicineCount, medicinename, prices, quantity);
                                //writeMedicine();
                            }
                            else if (choices == '2')
                            {
                                Console.Clear();
                                header();
                                Console.WriteLine("      DELETE STOCK >        ");
                                Console.WriteLine("*************************");
                                deletestock(ref mainmedicineCount,medicinename,prices,quantity,path1);
                                writeMedicine(path1, ref mainmedicineCount, medicinename, prices, quantity);

                                //writeMedicine();
                            }
                            else if (choices == '3')
                            {
                                Console.Clear();
                                header();
                                Console.WriteLine("      UPDATE STOCK >     ");
                                Console.WriteLine("*************************");
                                updateprices(path1,prices,medicinename,ref mainmedicineCount,quantity);
                                //writeMedicine(path1, ref mainmedicineCount, medicinename, prices, quantity);
                                //writeMedicine();
                            }
                            else if (choices == '4')
                            {
                                Console.Clear();
                                showstock(medicinename,prices,quantity, ref size, ref mainmedicineCount);
                            }
                            else if (choices == '5')
                            {
                                //manageworkers();
                            }
                            else if (choices == '6')
                            {
                                //offerdicount();
                            }
                            else if (choices == '7')
                            {
                                //Under process();
                            }
                            else if (choices == '8')
                            {
                                //updatenamepassadmin();
                            }
                            else if (choices == '9')
                            {
                                //viewFeedbacks();
                            }
                            else if (choices == '0')
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input.");
                                Console.ReadKey();
                            }
                        }
                    }

                    else if (output == "customer")
                    {

                        
                    }
                    else
                    {

                        Console.WriteLine("Invalid username/password");
                        Console.Clear();
                    }
                }
                else if (choice == '3')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input.");
                    Console.Clear();
                }
            }
        }

    
        static void header()
        {
            Console.WriteLine("#######################################################################################################");
            Console.WriteLine("#######################################################################################################");
            Console.WriteLine("#####                                                                                             #####");
            Console.WriteLine("#####                           -: MSN   PHARMACY  MANAGEMENT  SYSTEM :-                          #####");
            Console.WriteLine("#####                                                                                             #####");
            Console.WriteLine("#######################################################################################################");
            Console.WriteLine("#######################################################################################################");
        }
        static void loginmenu()
        {
            header();
            Console.WriteLine("    LOGIN MENU >             ");
            Console.WriteLine("*************************");
            Console.WriteLine("1.  SignIn with your credentials. ");
            Console.WriteLine("2.  SignUp to get your credentials. ");
            Console.WriteLine("3.  Exit program. ");
            Console.WriteLine("    ");
        }
        static void signup(string name2, string password2, string role2, string[] name, string[] password, string[] role,ref int count)
        {
            // Checking if the account already exists.
            // If it exists it will terminate the progrm.
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if (name2 == name[i] && role2 == role[i])
                    {
                        Console.WriteLine("This account already exists.");
                    }
                    else
                    {
                        name[count] = name2;
                        password[count] = password2;
                        role[count] = role2;
                        count++;
                    }
                }
            }
            else
            {
                name[count] = name2;
                password[count] = password2;
                role[count] = role2;

                count++;
            }
        }
        static string login(string name1, string password1, string[] name, string[] password, string[] role,ref int count)
        {
            string roles = "";
            for (int i = 0; i < count; i++)
            {
                if ((name1 == name[i]) && (password1 == password[i]))
                {
                    roles = role[i];
                }
            }

            return roles;
        }
        static void admin()
        {
            Console.Clear();
            header();
            Console.WriteLine("    ADMIN MENU >             ");
            Console.WriteLine("*************************");
            Console.WriteLine("1.  Add Stock. ");
            Console.WriteLine("2.  Delete Bills. ");
            Console.WriteLine("3.  Update Prices. ");
            Console.WriteLine("4.  Show stock. ");
            Console.WriteLine("5.  Manage Workers. ");
            Console.WriteLine("6.  Offer Discount. ");
            Console.WriteLine("7.  Save Data. ");
            Console.WriteLine("8.  Update username/password   ");
            Console.WriteLine("9.  View Feedback.   ");
            Console.WriteLine("10.  Press 0 to exit.");
        }
        static void deletestock(ref int mainmedicineCount,string[] medicinename, int[] prices, int[] quantity, string path)
        {
            string deletemedicine;
            Console.WriteLine("Enter product you want to delete : ");
            deletemedicine = Console.ReadLine();

            for (int i = 0; i < mainmedicineCount; i++)
            {
                if (deletemedicine == medicinename[i])
                {
                    for (int z = i; z < mainmedicineCount; z++)
                    {
                        medicinename[z] = medicinename[z + 1];
                        prices[z] = prices[z + 1];
                        quantity[z] = quantity[z + 1];
                    }
                    mainmedicineCount--;
                }
            }
        }
        static void addstock(string[] medicinename, int[] prices, int[] quantity,ref int mainmedicineCount,string addnewmedicine,ref int newmedicineprice,ref int newmedicinequantity)
        {

            medicinename[mainmedicineCount] = addnewmedicine;
            prices[mainmedicineCount] = newmedicineprice;
            quantity[mainmedicineCount] = newmedicinequantity;
            mainmedicineCount++;
            //size++;
            Console.WriteLine("count    {0}",mainmedicineCount);
            Console.ReadKey();
        }
        static void updateprices(string path,int[] prices, string[] medicinename,ref int mainmedicineCount, int[] productQuantity)
        {
            bool flag = true;
            string medicinetobeupdated="";
            int updatedprice;
            Console.WriteLine("Enter name of medicine to be updated : ");
            medicinetobeupdated = Console.ReadLine();
            Console.WriteLine("Enter the new price : ");
            updatedprice = int.Parse(Console.ReadLine());
            //Console.WriteLine("count    {0}", mainmedicineCount);
            //Console.ReadKey();
            //  if we add invalid medicine name it will show that it is invalid.
            for (int i = 0; i < mainmedicineCount; i++)
            {
                //Console.WriteLine(medicinename[i]);
                //Console.ReadKey();
                if (medicinetobeupdated == medicinename[i])
                {
                    prices[i] = updatedprice;
                    writeMedicine(path,ref mainmedicineCount, medicinename, prices, productQuantity);
                    flag = false;
                    break;
                }
            }
             if(flag == true)
                {
                    Console.WriteLine("Invalid medicine name .");
                    Console.ReadKey();
             
                }
        }
        /*static void updatestock(string[] medicinename, int[] quantity,ref int mainmedicineCount, string soldmedicinename, int soldmedicinequantity)
        {
            for (int i = 0; i < mainmedicineCount; i++)
            {
                if (soldmedicinename == medicinename[i])
                {
                    quantity[i] = quantity[i] - soldmedicinequantity;
                }
            }
        }*/
        static void showstock(string[] medicinename, int[] prices, int[] quantity, ref int size, ref int mainmedicineCount)
        {
            header();
            Console.WriteLine("    PRICE CHECK MENU >             ");
            Console.WriteLine("*************************");
            Console.WriteLine("  Medicine"+"\t\t\t"+"Price"+"\t\t\t"+"quantity");
            for (int i = 0; i < mainmedicineCount; i++)
            {
                if (medicinename[i] == "")
                {
                    break;
                }
                Console.WriteLine(i + 1 + ".  " + medicinename[i] + "\t\t\t" + prices[i] + "\t\t\t" + quantity[i]);
            }
            Console.WriteLine("    Press any key to exit.    ");
            Console.ReadKey();
        }
        static string parseData(string name, int password)
        {
            int comma = 1;
            string item = "";
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == ',')
                {
                    comma++;
                }
                else if (comma == password)
                {
                    item = item + name[i];
                }
            }
            return item;
        }
        static void readSignUp(string path, string[] names, string[] passwords, string[] role, ref int Count)
        {
            int x = 0;
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    names[Count] = parseData(record, 1);
                    passwords[Count] = parseData(record, 2);
                    role[Count] = parseData(record, 3);
                    Count++;
                    if (x >= 5)
                    {
                        break;
                    }
                }
                fileVariable.Close();
            }
            else
            {
                Console.Write("Not Exists!");
            }
        }
        static void writeSignUp(string path, string name, string password,string role)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(name + "," + password + "," + role);
            file.Flush();
            file.Close();
        }
        static void readMedicine(string path, string[] productName, int[] productPrice, int[] productQuantity, ref int Count)
        {

            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    productName[Count] = parseData(record, 1);
                    productPrice[Count] = int.Parse(parseData(record, 2));
                    productQuantity[Count] = int.Parse(parseData(record, 3));
                    Count++;
                }
                fileVariable.Close();
            }
            else
            {
                Console.Write("Not Exists!");
            }
        }
        static void writeMedicine(string path,ref int medicineCount, string[] productName, int[] productPrice, int[] productQuantity)
        {
            StreamWriter file = new StreamWriter(path);
            for (int i = 0; i < medicineCount; i++)
            {
                file.WriteLine(productName[i] + ',' + productPrice[i] + ',' + productQuantity[i]);
                
            }
            file.Close();
        }


    }
}
