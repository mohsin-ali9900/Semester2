using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ships
{
    class Program
    {
        static void Main(string[] args)
        {
            Ships shippp = new Ships();
            List<Ships> shipsInformation = new List<Ships>();
            string Choice;
            do
            {
                Choice = menu();
                Console.Clear();
                if (Choice == "1")
                {
                    int LaDegree,LoDegree;
                    float LaMinutes,LoMinutes;
                    char LaDirection, LoDirection;
                    Console.WriteLine("Enter Ship Number ");
                    string Ship = Console.ReadLine();
                    Console.WriteLine("Enter Ship Latitude");

                    Console.WriteLine("Enter the LatitudeDegree ");
                    LaDegree = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the LatitudeMinutes ");
                    LaMinutes = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the LatitudeDirection ");
                    LaDirection = char.Parse(Console.ReadLine());
                    Angle La = new Angle(LaDegree, LaMinutes, LaDirection);
                    Console.WriteLine("Enter Ship Longitude ");

                    Console.WriteLine("Enter the LongitudeDegree ");
                    LoDegree = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the LongtitudeMinutes ");
                    LoMinutes = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the LongtitudeDirection ");
                    LoDirection = char.Parse(Console.ReadLine());
                    Angle Lo = new Angle(LoDegree, LoMinutes, LoDirection);
                    Ships Shi = new Ships(Ship, Lo, La);
                    shippp = Shi;
                    Shi.adddatainList(shippp, shipsInformation);
                }
                if (Choice == "2")
                {
                    string no;
                    Console.WriteLine("Enter the ShipNumber :::");
                    no = Console.ReadLine();
                    shippp.FindShipLocation(no, shipsInformation);
                    Console.ReadKey();
                }
                if (Choice == "3")
                {
                    int latdegree;
                    Console.WriteLine("Enter the latitude degree ::");
                    latdegree = int.Parse(Console.ReadLine());
                    float latMinutes;
                    Console.WriteLine("Enter the latitude Minutes ::");
                    latMinutes = float.Parse(Console.ReadLine());
                    char latDirection;
                    Console.WriteLine("Enter the latitude Direction ::");
                    latDirection = char.Parse(Console.ReadLine());
                    int londegree;
                    Console.WriteLine("Enter the Longitude degree ::");
                    londegree = int.Parse(Console.ReadLine());
                    float lonMinutes;
                    Console.WriteLine("Enter the Longitude Minutes ::");
                    lonMinutes = float.Parse(Console.ReadLine());
                    char lonDirection;
                    Console.WriteLine("Enter the Longitude Direction ::");
                    lonDirection = char.Parse(Console.ReadLine());
                    shippp.returnShipNumber(latdegree, latMinutes, latDirection, londegree, lonMinutes, lonDirection, shipsInformation);
                    Console.ReadKey();
                }
                if (Choice == "4")
                {
                    string shipNumber;
                    Console.WriteLine("Enter the SHip Number to change its position   ::");
                    shipNumber = Console.ReadLine();
                    bool check = shippp.checkShip(shipNumber, shipsInformation);
                    if (check)
                    {
                        int index = shippp.indexFindingofshipNumber(shipNumber, shipsInformation);
                        NewPosition(index, shipsInformation);
                    }
                    else
                    {
                        Console.WriteLine("Data not found ");
                    }
                }

            }
            while (Choice != "5");
        }
        static string menu()
        {
            string Option;
            Console.Clear();
            Console.WriteLine("1. Add Ship");
            Console.WriteLine("2. View Ship Position ");
            Console.WriteLine("3. View Ship Serial Number ");
            Console.WriteLine("4. Change Ship position ");
            Console.WriteLine("5. Exit ");
            Console.WriteLine("Enter the option ");
            Option = Console.ReadLine();
            return Option;
        }
        static void NewPosition(int index, List<Ships> shipsInformation)
        {
            int LaDegree, LoDegree;
            float LaMinutes, LoMinutes;
            char LaDirection, LoDirection;
            Console.WriteLine("Enter Ship Latitude");
            Console.WriteLine("Enter the LatitudeDegree ");
            LaDegree = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the LatitudeMinutes ");
            LaMinutes = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter the LatitudeDirection ");
            LaDirection = char.Parse(Console.ReadLine());

            Console.WriteLine("Enter Ship Longitude ");
            Console.WriteLine("Enter the LongitudeDegree ");
            LoDegree = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the LongtitudeMinutes ");
            LoMinutes = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter the LongtitudeDirection ");
            LoDirection = char.Parse(Console.ReadLine());
            shipsInformation[index].Latitude.Degree = LaDegree;
            shipsInformation[index].Latitude.Minutes = LaMinutes;
            shipsInformation[index].Latitude.Direction = LaDirection;
            shipsInformation[index].Longitude.Degree = LoDegree;
            shipsInformation[index].Longitude.Minutes = LoMinutes;
            shipsInformation[index].Longitude.Direction = LoDirection;
        }
    }
}
