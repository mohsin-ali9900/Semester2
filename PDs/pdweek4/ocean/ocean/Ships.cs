using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ships
{
    class Ships
    {
        public Angle Latitude;
        public Angle Longitude;
        public string shipNumber;

        public Ships()
        {

        }
        public Ships(string ShipNumnber, Angle Latitude, Angle Longitude)
        {
            this.Latitude = Latitude;
            this.Longitude = Longitude;
            this.shipNumber = ShipNumnber;
        }
        public void adddatainList(Ships Sh, List<Ships> shipsInformation)
        {
            shipsInformation.Add(Sh);
        }
        public void FindShipLocation(string shipNo, List<Ships> shipsInfo)
        {
            foreach (var inn in shipsInfo)
            {
                if (shipNo == inn.shipNumber)
                {
                    inn.printPosition();
                }
            }
        }
        public void printPosition()
        {
            Console.WriteLine(Latitude.Degree + " " + Latitude.Minutes + " " + Latitude.Direction + " " + Longitude.Degree + " " + Longitude.Minutes + " " + Longitude.Direction);
        }
        public void returnShipNumber(int latDegree, float latMinutes, char latDIrection, int lonDegree, float lonMinutes, char lonDirection, List<Ships> shipsInformation)
        {
            foreach (var inn in shipsInformation)
            {
                if (latDegree == inn.Latitude.Degree && latMinutes == inn.Latitude.Minutes && latDIrection == inn.Latitude.Direction && lonDegree == inn.Longitude.Degree && lonMinutes == inn.Longitude.Minutes && lonDirection == inn.Longitude.Direction)
                {
                    Console.WriteLine("Ship Number is " + inn.shipNumber);
                }
            }
        }
        public bool checkShip(string shipNumber, List<Ships> shipsInfo)
        {
            foreach (var inn in shipsInfo)
            {
                if (shipNumber == inn.shipNumber)
                {
                    return true;
                }
            }
            return false;
        }
        public int indexFindingofshipNumber(string shipNumber, List<Ships> shipsInformation)
        {
            int index = -1;
            for (int i = 0; i < shipsInformation.Count; i++)
            {
                if (shipNumber == shipsInformation[i].shipNumber)
                {
                    index = i;
                    break;
                }
            }
            return index;

        }
    }
}
