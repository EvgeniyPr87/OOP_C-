using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fraction fraction = new Fraction(2, 3);
            fraction.Print();
            //fraction.ToInverted();
           // fraction.Print();   
            //fraction.WrongFraction();
            //fraction.Print();

            Fraction fraction2 = new Fraction(1, 6);
           // fraction2.ConvertingCorrect();
            //fraction2.Print();
           // fraction2.ToInverted();
            fraction2.Print();
            Fraction fraction3 = new Fraction();
            fraction3 = fraction * fraction2;
            fraction3.Print();
            fraction3.ToInverted();
            fraction3.Print();
            Fraction fraction4=new Fraction();
            Fraction fraction5 = new Fraction(2,8);
            Fraction fraction6 = new Fraction(3,6);
            //fraction4 = fraction5 + fraction6;
            //fraction4.Print();
            Fraction fraction7 = new Fraction();
            fraction7 = fraction5 + fraction6;
            fraction7.Print();
            
            Console.WriteLine(fraction5 < fraction6);

            //fraction3 = fraction / fraction2;
            // fraction3.Print();

            //#error version
        }
    }
}
