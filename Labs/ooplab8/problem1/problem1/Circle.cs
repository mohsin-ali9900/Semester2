using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem1
{
    internal class Circle
    {
        protected double radius = 1.0;
        protected string color = "red";
        public Circle()
        {
        }
        public Circle(double rad)
        {
            this.radius = rad;
        }
        public Circle(double rad, string color)
        {
            this.radius = rad;
            this.color = color;
        }
        public double getRadius()
        {
            return radius;
        }
        public void setRadius(double rad)
        {
            this.radius = rad;
        }
        public string getColor()
        {
            return color;
        }
        public void setColor(string color)
        {
            this.color = color;
        }
        public double getArea()
        {
            double area = 3.14 * radius * radius;
            return area
        }
        public string toString()
        {
            return "Radius : " + radius + " Color : " + color;
        }
    }
}
