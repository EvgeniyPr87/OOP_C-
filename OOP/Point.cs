using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Point
    {
        //private double x;
        //double y;
       // public double X { get; set; }
        //public double Y { get; set; }

        //public double X
        //{
        //   get { return x; }
        //    set { x = value; }
        //}

        //public double Y
        //{
        //    get { return y; }
        //    set { y = value; }
        //}
        public double GetX() { return x; }
        public double GetY() { return y; }

        public void SetX(double x) { this.x = x; }
        public void SetY(double y) { this.y = y; }

        //              Methods:
        public void Print()
        //{ Console.WriteLine($"X={GetX()}, Y={GetY()}"); }
        { Console.WriteLine($"X={X}, Y={Y}"); }

        public double Distance(Point other)
        {
            double xDist = this.X - other.X;
            double yDist = this.Y - other.Y;
            return Math.Sqrt((xDist * xDist) + (yDist * yDist));
        }

    }
}
