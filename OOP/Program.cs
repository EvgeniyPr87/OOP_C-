using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point point=new Point();//создаем объект класса
            Point point2 = new Point();
            point2.X = 25;
            point2.Y = 35;
            //point.SetX(2);
            //point.SetY(3);
            point.Print();
            point.X = 7;
            point.Y = 8;
            Console.WriteLine($"Propertis: X={point.X}, Y={point.Y}");
            
            Console.WriteLine($"Дистанция до указанной точки: {point.Distance(point2)}");
        }
    }
}
