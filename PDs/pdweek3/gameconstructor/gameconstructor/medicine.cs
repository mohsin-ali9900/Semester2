using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class medicine
    {
        public string medicineName;
        public int medicinePrice;
        public int medicineQuantity;


        public medicine(string medName, int medPrice, int medQuantity)
        {
            medicineName = medName;
            medicinePrice = medPrice;
            medicineQuantity = medQuantity;
        }

        public medicine()
        {
            medicineName = string.Empty;
        }
    }
}
