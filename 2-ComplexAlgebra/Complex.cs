using System;

namespace ComplexAlgebra
{
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// TODO: Model Complex numbers in an object-oriented way and implement this class.
    /// TODO: In other words, you must provide a means for:
    /// TODO: * instantiating complex numbers
    /// TODO: * accessing a complex number's real, and imaginary parts
    /// TODO: * accessing a complex number's modulus, and phase
    /// TODO: * complementing a complex number
    /// TODO: * summing up or subtracting two complex numbers
    /// TODO: * representing a complex number as a string or the form Re +/- iIm
    /// TODO:     - e.g. via the ToString() method
    /// TODO: * checking whether two complex numbers are equal or not
    /// TODO:     - e.g. via the Equals(object) method
    public class Complex
    {
        public int Real { get; }
        public int Imaginary { get; }
        public double Modulus
        {
            get => Math.Sqrt(Math.Pow(Real, 2) + Math.Pow(Imaginary, 2));
        }
        public double Phase
        {
            get => Math.Atan2(Imaginary, Real);
        }

        public Complex(int re, int im)
        {
            Real = re;
            Imaginary = im;
        }

        public Complex Complement() => new Complex(Real, -Imaginary);

        public Complex Plus(Complex n) => new Complex(this.Real + n.Real, this.Imaginary + n.Imaginary);

        public Complex Minus(Complex n) => new Complex(this.Real - n.Real, this.Imaginary - n.Imaginary);

        private string GetSign()
        {
            if(Imaginary >= 0)
            {
                return " + ";
            }
            else
            {
                return " - ";
            }
        }

        private string ImaginaryPartToString()
        {
            string toReturn = "";
            if(Imaginary != 0)
            {
                if(Math.Abs(Imaginary) != 1)
                {
                    toReturn = GetSign() + Math.Abs(Imaginary) + "i";
                }
                else
                {
                    toReturn = GetSign() + "i";
                }
            }
            return toReturn;
        }

        public override string ToString()
        {
            string toReturn = Real.ToString();
            if (toReturn.Equals("0"))
            {
                toReturn = ImaginaryPartToString();
            }
            else
            {
                toReturn = toReturn + ImaginaryPartToString();
            }
            return toReturn;
        }

        public override bool Equals(object obj)
        {
            return obj is Complex complex &&
                   Real == complex.Real &&
                   Imaginary == complex.Imaginary;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Real, Imaginary);
        }
    }
}