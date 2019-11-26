using System;

namespace Polynoms
{
    /// <summary>
    /// This class describes entity of polynomial.
    /// </summary>
    public class Polynomial
    {        
        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class.This constructor initializes properties Rates and Degree.
        /// </summary>
        /// <param name="rates">Array of polynomial rates</param>        
        /// <exception cref="ArgumentNullException">If ref of array equals null</exception>
        public Polynomial(int[] rates)
        {
            if (rates == null)
            {
                throw new ArgumentNullException();
            }

            this.Rates = rates;
            this.Degree = rates.Length - 1;
        }

        /// <summary>
        /// Gets array of rates of polynomial
        /// </summary>
        public int[] Rates { get; }

        /// <summary>
        /// Gets max degree of polynomial
        /// </summary>
        private int Degree { get; }

        /// <summary>
        /// This method overloads operator + for polynomials.
        /// </summary>
        /// <param name="a">The first polynomial.</param>
        /// <param name="b">The second polynomial.</param>        
        /// <returns>Result of adding of two polynomials</returns>
        public static Polynomial operator +(Polynomial a, Polynomial b)
        {
            int lengthA = a.Rates.Length;
            int lengthB = b.Rates.Length;
            int difAandB = Math.Abs(lengthA - lengthB);
            Polynomial c;
            if (lengthA > lengthB)
            {
                c = new Polynomial(new int[lengthA]);
                SumTwoPolinoms(a, b, difAandB, ref c);
            }
            else
            {
                c = new Polynomial(new int[lengthB]);
                SumTwoPolinoms(b, a, difAandB, ref c);
            }

            return c;
        }

        /// <summary>
        /// This method overloads operator - for polynomials.
        /// </summary>
        /// <param name="a">The first polynomial.</param>
        /// <param name="b">The second polynomial.</param>        
        /// <returns>Result of difference of two polynomials</returns>
        public static Polynomial operator -(Polynomial a, Polynomial b)
        {
            int lengthA = a.Rates.Length;
            int lengthB = b.Rates.Length;
            int difAandB = Math.Abs(lengthA - lengthB);
            Polynomial c;
            if (lengthA > lengthB)
            {
                c = new Polynomial(new int[lengthA]);
                DifTwoPolinoms(a, b, difAandB, ref c);
            }
            else
            {
                c = new Polynomial(new int[lengthB]);
                DifTwoPolinoms(a, difAandB, b, ref c);
            }

            return c;
        }

        /// <summary>
        /// This method overloads operator * for polynomials.
        /// </summary>
        /// <param name="a">The first polynomial.</param>
        /// <param name="b">The second polynomial.</param>        
        /// <returns>Result of multiplication of two polynomials</returns>
        public static Polynomial operator *(Polynomial a, Polynomial b)
        {
            int[] rates = new int[a.Rates.Length + b.Rates.Length - 1];
            for (int i = 0; i < a.Rates.Length; ++i)
            {
                for (int j = 0; j < b.Rates.Length; ++j)
                {
                    rates[i + j] += a.Rates[i] * b.Rates[j];
                }
            }

            return new Polynomial(rates);
        }

        /// <summary>
        /// This method overloads operator == for polynomial.
        /// </summary>
        /// <param name="a">The first polynomial.</param>
        /// <param name="b">The second polynomial.</param>        
        /// <returns>True if reference of A and B are the same. And false if aren't the same</returns>
        public static bool operator ==(Polynomial a, Polynomial b)
        {
            return ReferenceEquals(a, b);
        }

        /// <summary>
        /// This method overloads operator != for polynomial.
        /// </summary>
        /// <param name="a">The first polynomial.</param>
        /// <param name="b">The second polynomial.</param>        
        /// <returns>True if reference of A and B aren't the same. And false if are the same</returns>
        public static bool operator !=(Polynomial a, Polynomial b)
        {            
            return !ReferenceEquals(a, b)?true:false;
        }

        /// <summary>
        /// This overriding method converts polynomial in string.
        /// </summary>        
        /// <returns> string view of polynomial</returns>
        public override string ToString()
        {
            string s;
            string massage = (this.Degree == 0) ? $"{Rates[0]}" : $"{Rates[0]}x^{Degree}";
            for (int i = 1; i < this.Rates.Length; i++)
            {
                s = this.Rates[i] < 0 ? string.Empty : "+";
                if (this.Degree - i == 0)
                {
                    massage += this.Rates[i] < 0 ? $" {this.Rates[i]}" : $" +{this.Rates[i]}";
                    break;
                }

                massage += $" {s}{this.Rates[i]}x^{this.Degree - i}";
            }

            return massage;
        }

        /// <summary>
        /// This override method converts polynomial in hash.
        /// </summary>        
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode() << 1;
        }

        /// <summary>
        /// This override method check data of object and class instance are equals.
        /// </summary>
        /// <param name="obj">The object that must be checked and compared for equality with class instance.</param>
        /// <returns>True if two objects are equals and false  - if are' t </returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            Polynomial somePolynom = (Polynomial)obj;
            bool equalsLength = this.Rates.Length == somePolynom.Rates.Length;
            if (equalsLength == true)
            {
                for (int i = 0; i < somePolynom.Rates.Length; i++)
                {
                    if (this.Rates[i] != somePolynom.Rates[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// This method count adding of two polynomials.
        /// </summary>
        /// <param name="moreLength">The first polynomial with longer length of array Rates than the second polynomial.</param>
        /// <param name="lessLength">The second polynomial with short length of array Rates than the first polynomial.</param>
        /// <param name="dif">Difference between lengths of array Rates of two polynomials.</param>
        /// <param name="с">Resulting polynomial.</param>        
        private static void SumTwoPolinoms(Polynomial moreLength, Polynomial lessLength, int dif, ref Polynomial с)
        {
            for (int i = 0; i < dif; i++)
            {
                с.Rates[i] = moreLength.Rates[i];
            }

            for (int i = lessLength.Rates.Length - 1; i >= 0; i--)
            {
                с.Rates[i + dif] = lessLength.Rates[i] + moreLength.Rates[i + dif];
            }
        }

        /// <summary>
        /// This method count difference of two polynomials if the first polynomial more than the second polynomial.
        /// </summary>
        /// <param name="moreLength">The first polynomial with longer length of array Rates than the second polynomial.</param>
        /// <param name="lessLength">The second polynomial with short length of array Rates than the first polynomial.</param>
        /// <param name="dif">Difference between lengths of array Rates of two polynomials.</param>
        /// <param name="с">Resulting polynomial.</param>
        private static void DifTwoPolinoms(Polynomial moreLength, Polynomial lessLength, int dif, ref Polynomial с)
        {
            for (int i = 0; i < dif; i++)
            {
                с.Rates[i] = moreLength.Rates[i];
            }

            for (int i = lessLength.Rates.Length - 1; i >= 0; i--)
            {
                с.Rates[i + dif] = moreLength.Rates[i + dif] - lessLength.Rates[i];
            }
        }

        /// <summary>
        /// This method count difference of two polynomials if the second polynomial more than the first polynomial.
        /// </summary>
        /// <param name="lessLength">The first polynomial with longer length of array Rates than the second polynomial.</param>
        /// <param name="dif">Difference between lengths of array Rates of two polynomials.</param>
        /// <param name="moreLength">The second polynomial with short length of array Rates than the first polynomial.</param>        
        /// <param name="с">Resulting polynomial.</param>
        private static void DifTwoPolinoms(Polynomial lessLength, int dif, Polynomial moreLength, ref Polynomial с)
        {
            for (int i = 0; i < dif; i++)
            {
                с.Rates[i] = moreLength.Rates[i];
            }

            for (int i = lessLength.Rates.Length - 1; i >= 0; i--)
            {
                с.Rates[i + dif] = lessLength.Rates[i] - moreLength.Rates[i + dif];
            }
        }
    }
}
