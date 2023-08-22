using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem2.DL
{
    internal class staff:person
    {
        private string school;
        private double pay;

        public staff(string Name,string Address,string School,double Pay):base(Name,Address)
        {
            this.school = School;
            this.pay = Pay;
        }
        public string getSchool()
        {
            return school;
        }
        public void setSchool(string School)
        {
            this.school = School;
        }
        public double getPay()
        {
            return pay;
        }
        public void setPay(double Pay)
        {
            this.pay = Pay;
        }
        public override string toString()
        {
            return ("Name: " + name + " Address: " + address + " School: " + school + " Pay: " + pay);
        }
    }
}
