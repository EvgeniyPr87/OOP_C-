using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    internal class Fraction
    {
        public int IntegerPart { get; set; }
        public int Numerator { get; set; }
        private int denominator;
        public int Denominator
        {
            get => denominator;
            set => denominator = value == 0 ? 1 : value;
        }

        //          Constructors:

        //Defolt constructor:
        public Fraction()
        {
            Denominator = 1;
        }

        //Constructor with one parameter:
        public Fraction(int IntegerPart)
        {
            this.IntegerPart = IntegerPart;
            this.Denominator = 1;
        }

        //Constructor with two parameter:
        public Fraction(int Numerator, int Denominator)
        {
            this.Numerator = Numerator;
            this.Denominator = Denominator;
        }
        //Constructor with three parameter:
        public Fraction(int IntegerPart, int Numerator, int Denominator)
        {
            this.IntegerPart = IntegerPart;
            this.Numerator = Numerator;
            this.Denominator = Denominator;
        }
        ////CopyConstructor:
        public Fraction(Fraction other)
        {
            this.IntegerPart = other.IntegerPart;
            this.Numerator = other.Numerator;
            this.Denominator = other.Denominator;
        }
        // 1(1/2), 1/2, 1
        //          Methods:
        public void Print()
        {
            if (IntegerPart != 0 && Numerator != 0)
            { Console.WriteLine($"Дробь: {IntegerPart} ( {Numerator} / {Denominator} )"); }
            else if (IntegerPart != 0) { Console.WriteLine($"Дробь: {IntegerPart} "); }
            else if (IntegerPart == 0) { Console.WriteLine($"Дробь: {Numerator} / {Denominator} "); }
        }

        public Fraction WrongFraction() => new Fraction(Numerator + IntegerPart * Denominator, Denominator);

        public Fraction ConvertingCorrect() => new Fraction(Numerator / Denominator, Numerator %= Denominator, Denominator);

        public Fraction Reduction() => new Fraction(IntegerPart, Numerator / GCD(), Denominator / GCD());

        public int GCD() =>
            (int)Convert.ToInt32(System.Numerics.BigInteger.GreatestCommonDivisor(Numerator, Denominator).ToString());

        public Fraction ToInverted() => new Fraction(Denominator, WrongFraction().Numerator);

        //      Operators:

        public static Fraction operator *(Fraction left, Fraction right) =>
            new Fraction
                (
                left.WrongFraction().Numerator * right.WrongFraction().Numerator,
                 left.Denominator * right.Denominator
                );

        public static Fraction operator /(Fraction left, Fraction right) => left * right.ToInverted();

        public static Fraction operator +(Fraction left, Fraction right) =>
           new Fraction
               (
               (left.WrongFraction().Numerator * right.Denominator) + (right.WrongFraction().Numerator * left.Denominator),
               left.Denominator * right.Denominator
               ).ConvertingCorrect().Reduction();

        public static Fraction operator -(Fraction left, Fraction right) =>
       new Fraction
                (
                (left.Numerator * right.Denominator) - (right.Numerator * left.Denominator),
                left.Denominator * right.Denominator
                ).ConvertingCorrect().Reduction();

        public static bool operator ==(Fraction left, Fraction right) => left.WrongFraction().Equals(right.WrongFraction());

        public static bool operator !=(Fraction left, Fraction right) => !left.WrongFraction().Equals(right.WrongFraction());

        public static bool operator >(Fraction left, Fraction right) =>
            left.WrongFraction().Numerator * right.Denominator > right.WrongFraction().Numerator * left.Denominator;

        public static bool operator <(Fraction left, Fraction right) => !(left > right);
        
        public static bool operator >=(Fraction left, Fraction right)=> !(left < right);
        
        public static bool operator <=(Fraction left, Fraction right)=> !(left > right);
       
    }
}

