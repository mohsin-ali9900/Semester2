using ConsoleApp1;
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
            List<signin> user = new List<signin>();

            
            Console.Clear();
            string username, userpassword, userrole;
            char choice = ' ';

            string path = "E:\\semester 2\\oops\\lab1\\pdweek2\\ConsoleApp1signup.txt";
            string path1 = "E:\\semester 2\\oops\\lab1\\pdweek2\\ConsoleApp1medicine.txt";

            List<medicine> med = new List<medicine>();
            List<string> namee = new List<string>() { "Panadol","Calpol","Dispirin"};
            List<int> pricee = new List<int>() { 50,60,70};
            List<int> quantityy = new List<int>() { 5,6,7,};

            while (choice != '3')
            {
                readSignUp(path,user);
                readMedicine(path1,med);
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
                    bool flaggg = checkSignup(user, username);
                    if (flaggg == true)
                    {
                        if ((username.Length > 2) && (userpassword.Length > 2) && (userrole == "admin" || userrole == "customer"))
                        {
                            user.Add(signup(username, userpassword, userrole));
                            writeSignUp(path, username, userpassword, userrole);
                        }
                        else
                        {
                            Console.WriteLine("Invalid username,password or role");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Account Already Exists.");
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
                    string output = login(user,username, userpassword);
                    Console.WriteLine("output {0}",output);
                    Console.ReadKey();
                    if (output == "admin")
                    {
                        
                        char choices = ' ';
                        while (choices != '0')
                        {
                            admin();
                            Console.WriteLine("Enter the option : ");
                            choices = char.Parse(Console.ReadLine());
                            

                            if (choices == '1')
                            {
                                string newmedicinename;
                                int newmedicineprice, newmedicinequantity;
                                Console.Clear();
                                header();
                                Console.WriteLine("        ADD STOCK >        ");
                                Console.WriteLine("*************************");

                                Console.WriteLine("Enter name of medicine to added : ");
                                newmedicinename = Console.ReadLine();
                                Console.WriteLine("Enter price of new medicine : ");
                                newmedicineprice = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter quantity of new medicine : ");
                                newmedicinequantity = int.Parse(Console.ReadLine());
                                med.Add(addstock(newmedicinename, ref newmedicineprice, ref newmedicinequantity,namee,pricee,quantityy));
                                writeMedicine(path1, newmedicinename, newmedicineprice, newmedicinequantity);
                            }
                            else if (choices == '2')
                            {
                                Console.Clear();
                                header();
                                Console.WriteLine("      DELETE STOCK >        ");
                                Console.WriteLine("*************************");
                                deletestock(med);
                                writeMedicinesOverwriteFile(med, path1);


                            }
                            else if (choices == '3')
                            {
                                
                                Console.Clear();
                                header();
                                Console.WriteLine("      UPDATE STOCK >     ");
                                Console.WriteLine("*************************");
                                updateprices(med);
                                writeMedicinesOverwriteFile(med, path1);

                            }
                            else if (choices == '4')
                            {
                                Console.Clear();
                                showstock(med);
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
                        Console.ReadKey();
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
                    Console.ReadKey();
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
        static signin signup(string name2, string password2, string role2)
        {
            // Checking if the account already exists.
            // If it exists it will terminate the progrm.

            signin users = new signin();   
            users.username = name2;
            users.password = password2;
            users.role= role2;
            return users;
        }
        static bool checkSignup(List<signin> users, string username)
        {
            bool flag = true; 
            for(int i = 0; i < users.Count; i++)
            {
                if (users[i].username == username)
                {
                    flag = false;
                }
            }
            return flag;
        }
        static string login(List<signin> user,string name1, string password1)
        {
            string roles = "";
            //signin sign = new signin();
            for (int i = 0; i < user.Count; i++)
            {
                if ((name1 == user[i].username) && (password1 == user[i].password))
                {
                    roles = user[i].role;
                    break;
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
        static void deletestock(List<medicine> med)
        {
            string deletemedicine;
            Console.WriteLine("Enter product you want to delete : ");
            deletemedicine = Console.ReadLine();
            int indx= index(med, deletemedicine);
            if (indx != -1)
            {
                med.RemoveAt(indx);
                Console.WriteLine("Successfully Deleted.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid name");
                Console.ReadKey();
            }
        }
        static int index(List<medicine> mmeedd,string name)
        {
            int index = -1;
            for(int i= 0; i<mmeedd.Count;i++)
            {
                if(name == mmeedd[i].medicineName)
                {
                    index = i;
                }
            }
            return index;
        }
        static medicine addstock(string addnewmedicine, ref int newmedicineprice, ref int newmedicinequantity,List<string> medName,List<int> medPrice,List<int> medQuantity)
        {
            medicine med = new medicine();
            med.medicineName = addnewmedicine;
            med.medicinePrice = newmedicineprice;
            med.medicineQuantity = newmedicinequantity;
            return med;
        }
        static void updateprices(List<medicine> medd)
        {
            string medicinetobeupdated = "";
            int updatedprice;
            Console.WriteLine("Enter name of medicine to be updated : ");
            medicinetobeupdated = Console.ReadLine();
            Console.WriteLine("Enter the new price : ");
            updatedprice = int.Parse(Console.ReadLine());

            int indx = index(medd, medicinetobeupdated);

            //  if we add invalid medicine name it will show that it is invalid.
            
            if (indx != -1)
            {
                medd[indx].medicinePrice = updatedprice;
                Console.WriteLine("Price Successfully Updated.");
                Console.ReadKey();
            }
            else
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
        static void showstock(List<medicine> medd)
        {
            header();
            Console.WriteLine("    PRICE CHECK MENU >             ");
            Console.WriteLine("*************************");
            Console.WriteLine("  Medicine" + "\t\t\t" + "Price" + "\t\t\t" + "quantity");
            for (int i = 0; i < medd.Count; i++)
            {
                if (medd[i].medicineName == "")
                {
                    break;
                }
                Console.WriteLine(i + 1 + ".  " + medd[i].medicineName + "\t\t\t" + medd[i].medicinePrice + "\t\t\t" + medd[i].medicineQuantity);
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
        static void readSignUp(string path,List<signin> user)
        {
            signin sign = new signin();
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    sign.username = parseData(record, 1);
                    sign.password = parseData(record, 2);
                    sign.role = parseData(record, 3);
                    user.Add(sign);
                }
                fileVariable.Close();
            }
            else
            {
                Console.Write("Not Exists!");
            }
        }
        static void writeSignUp(string path, string name, string password, string role)
        {
            StreamWriter file = new StreamWriter(path);
            file.WriteLine(name + "," + password + "," + role);
            file.Flush();
            file.Close();
        }
        static void readMedicine(string path,List<medicine> medd)
        {
            medicine data = new medicine();

            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    if(record=="")
                    {
                        break;
                    }
                    data.medicineName = parseData(record, 1);
                    data.medicinePrice = int.Parse(parseData(record, 2));
                    data.medicineQuantity = int.Parse(parseData(record, 3));
                    medd.Add(data);
                }
                fileVariable.Close();
            }
            else
            {
                Console.Write("Not Exists!");
            }
        }
        static void writeMedicine(string path,string medName,int medPrice,int medQuantity)
        {
            StreamWriter file = new StreamWriter(path,true);  // true appends
            if(File.Exists(path))
            {
                file.WriteLine(medName + ',' + medPrice+ ',' + medQuantity);
            }
            file.Flush();
            file.Close();
        }

        static void writeMedicinesOverwriteFile(List<medicine> medicines, string path)
        {
            StreamWriter file = new StreamWriter(path, false); // false overwrites
            foreach(medicine currentMedicine in medicines)
            {
                file.WriteLine("{0},{1},{2}", currentMedicine.medicineName, currentMedicine.medicinePrice, currentMedicine.medicineQuantity);
            }
            file.Flush();
            file.Close();
        }


    }
}
