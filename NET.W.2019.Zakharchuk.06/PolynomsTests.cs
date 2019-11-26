using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polynoms;

namespace Polynoms.Tests
{
    [TestClass]
    public class PolynomsTests
    {
        [TestMethod]
        public void Polynomial_Null_ArgumentNullExceptionReturned()
        {            
            Assert.ThrowsException<ArgumentNullException>(() => new Polynomial(null));
        }

        [TestMethod]
        public void PolynomialToString_8_minus9_Returned8xIn1_minus9()
        {
            Polynomial A = new Polynomial(new int[] { 8 , -9 });
            Assert.AreEqual(A.ToString(), "8x^1 -9");
        }

        [TestMethod]
        public void PolynomialEquals_10_minus7_and_10_minus7_ReturnedTrue()
        {
            Polynomial A = new Polynomial(new int[] { 10, -7 });
            Polynomial B = new Polynomial(new int[] { 10, -7 });
            Assert.AreEqual(A.Equals(B), true);
        }

        [TestMethod]
        public void PolynomialEquals_10_minus8_and_10_minus7_ReturnedFalse()
        {
            Polynomial A = new Polynomial(new int[] { 10, -8 });
            Polynomial B = new Polynomial(new int[] { 10, -7 });
            Assert.AreEqual(A.Equals(B), false);
        }
        [TestMethod]
        public void PolynomialEquals_array100_minus8_and_100minus8ReturnedFalse()
        {
            Polynomial A = new Polynomial(new int[] { 100, -8 });            
            Assert.AreEqual(A.Equals(new int[] { 100, -8 }), false);
        }

        [TestMethod]
        public void _7minus9_2_Plus_10_9_10_minus7_4Returned10_9_17_minus16_6()
        {
            Polynomial A = new Polynomial(new int[] { 7, -9, 2 });
            Polynomial B = new Polynomial(new int[] { 10, 9, 10, -7, 4 });
            Polynomial C = A + B;            
            Assert.AreEqual(C.ToString(), "10x^4 +9x^3 +17x^2 -16x^1 +6");
        }

        [TestMethod]
        public void _7minus9_2_Minus_10_9_10_minus7_4Returned10_9_minus3_minus2_minus2()
        {
            Polynomial A = new Polynomial(new int[] { 7, -9, 2 });
            Polynomial B = new Polynomial(new int[] { 10, 9, 10, -7, 4 });
            Polynomial C = A - B;
            Assert.AreEqual(C.ToString(), "10x^4 +9x^3 -3x^2 -2x^1 -2");
        }

        [TestMethod]
        public void _7minus9_2_Multiplay_10_9_10_minus7_4Returned10_9_minus3_minus2_minus2()
        {
            Polynomial A = new Polynomial(new int[] { -9, 2 });
            Polynomial B = new Polynomial(new int[] { 10, -7, 4 });
            Polynomial C = A * B;            
            Assert.AreEqual(C.ToString(), "-90x^3 +83x^2 -50x^1 +8");            
        }

    }
}
