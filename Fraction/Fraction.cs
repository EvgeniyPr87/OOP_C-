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
        private int numerator;
        private int denominator;
        private int integerPart;

        public int Numerator
        {
            get { return numerator; }
            set { numerator = value; }
        }
        public int Denominator
        {
            get { return denominator; }
            set { denominator = value; }
        }
        public int IntegerPart
        {
            get { return integerPart; }
            set { integerPart = value; }
        }

        //          Constructors:
        public Fraction()
        {
            this.IntegerPart = 0;
            this.Numerator = 0;
            this.Denominator = 1;
        }
        public Fraction(int integer, int numerator, int denominator)
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
            this.IntegerPart = integer;

        }
        public Fraction(int numerator, int denominator)
        {
            this.IntegerPart = 0;
            this.Numerator = numerator;
            this.Denominator = denominator;
        }
        public Fraction(int integerPart)
        {
            this.IntegerPart = integerPart;
            this.Numerator = 0;
            this.Denominator = 1;
        }

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

        public Fraction WrongFraction()
        {
            if (IntegerPart != 0)
            {
                Numerator += IntegerPart * Denominator;
                IntegerPart = 0;
            }
            
            return this;
        }

        public Fraction ConvertingCorrect()
        {
            IntegerPart += Numerator / Denominator;
            Numerator %= Denominator;

            return this;
        }

        public Fraction Reduction()
        {
            int more, less, rest;
            if (Numerator < Denominator)
            {
                more = Numerator;
                less = Denominator;
            }
            else
            {
                more = Denominator;
                less = Numerator;
            }
            do
            {
                rest = more % less;
                more = less;
                less = rest;
            } while (rest != 0);
            int GCD = more;
            Numerator /= GCD;
            Denominator /= GCD; ;
            return this;
        }

        public Fraction ToInverted()
        {
            Fraction inverted = this;
            inverted.WrongFraction();
            (inverted.Numerator, inverted.Denominator) = (inverted.Denominator, inverted.Numerator);
            return inverted;
        }

        //      Operators:


        public static Fraction operator *(Fraction left, Fraction right)
        {
            left.WrongFraction();
            right.WrongFraction();
            return new Fraction
                (
                left.Numerator * right.Numerator,
                left.Denominator * right.Denominator
                );
        }

        public static Fraction operator /(Fraction left, Fraction right)
        {
            return left * right.ToInverted();
        }

        public static Fraction operator +(Fraction left, Fraction right)
        {
            left.WrongFraction();
            right.WrongFraction();
             Fraction result= new Fraction
                (
                (left.Numerator * right.Denominator) + (right.Numerator * left.Denominator),
                left.Denominator * right.Denominator
                ).ConvertingCorrect().Reduction();
            return result;
        }

        public static Fraction operator -(Fraction left, Fraction right)
        {
            left.WrongFraction();
            right.WrongFraction();
            return new Fraction
                (
                (left.Numerator * right.Denominator) - (right.Numerator * left.Denominator),
                left.Denominator * right.Denominator
                ).ConvertingCorrect().Reduction();
        }

        public static bool operator ==(Fraction left, Fraction right)
        {
            left.WrongFraction();
            right.WrongFraction();
            return left.Equals(right);
        }


        public static bool operator !=(Fraction left, Fraction right)
        {
            left.WrongFraction();
            right.WrongFraction();
            return !left.Equals(right);
        }

        public static bool operator >(Fraction left, Fraction right)
        {
            left.WrongFraction();
            right.WrongFraction();
            return left.Numerator * right.Denominator > right.Numerator * left.Denominator;
        }
        public static bool operator <(Fraction left, Fraction right)
        {
            left.WrongFraction();
            right.WrongFraction();
            return left.Numerator * right.Denominator < right.Numerator * left.Denominator;
        }
        public static bool operator >=(Fraction left, Fraction right)
        {
            return !(left < right);
        }
        public static bool operator <=(Fraction left, Fraction right)
        {
            return !(left > right);
        }
    }
}

