using System;
using DoubleToBinary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetBinary.Tests
{
    [TestClass]
    public class GetBinary
    {        
        [TestMethod]
        public void GetBinary_minus255Point255_1100000001101111111010000010100011110101110000101000111101011100_Returned()
        {
            double number = -255.255;
            Assert.AreEqual(number.GetBinary(), "1100000001101111111010000010100011110101110000101000111101011100");
        }

        [TestMethod]
        public void GetBinary_255Point255_0100000001101111111010000010100011110101110000101000111101011100_Returned()
        {
            double number = 255.255;
            Assert.AreEqual(number.GetBinary(), "0100000001101111111010000010100011110101110000101000111101011100");
        }

        [TestMethod]
        public void GetBinary_4294967295Point0_0100000111101111111111111111111111111111111000000000000000000000()
        {
            double number = 4294967295.0;
            Assert.AreEqual(number.GetBinary(), "0100000111101111111111111111111111111111111000000000000000000000");
        }

        [TestMethod]
        public void GetBinary_doublePointMinValue_1111111111101111111111111111111111111111111111111111111111111111_Returned()
        {
            double number = double.MinValue;
            Assert.AreEqual(number.GetBinary(), "1111111111101111111111111111111111111111111111111111111111111111");
        }

        [TestMethod]
        public void GetBinary_doublePointMaxValue_0111111111101111111111111111111111111111111111111111111111111111_Returned()
        {
            double number = double.MaxValue;
            Assert.AreEqual(number.GetBinary(), "0111111111101111111111111111111111111111111111111111111111111111");
        }

        [TestMethod]
        public void GetBinary_doublePointEpsilone_0000000000000000000000000000000000000000000000000000000000000001_Returned()
        {
            double number = double.Epsilon;
            Assert.AreEqual(number.GetBinary(), "0000000000000000000000000000000000000000000000000000000000000001");
        }

        [TestMethod]
        public void GetBinary_doublePointNaN_1111111111111000000000000000000000000000000000000000000000000000_Returned()
        {
            double number = double.NaN;
            Assert.AreEqual(number.GetBinary(), "1111111111111000000000000000000000000000000000000000000000000000");
        }

        [TestMethod]
        public void GetBinary_doublePointNegativeInfinity_1111111111110000000000000000000000000000000000000000000000000000_Returned()
        {
            double number = double.NegativeInfinity;
            Assert.AreEqual(number.GetBinary(), "1111111111110000000000000000000000000000000000000000000000000000");
        }

        [TestMethod]
        public void GetBinary_doublePointPositiveInfinity_0111111111110000000000000000000000000000000000000000000000000000_Returned()
        {
            double number = double.PositiveInfinity;
            Assert.AreEqual(number.GetBinary(), "0111111111110000000000000000000000000000000000000000000000000000");
        }

        [TestMethod]
        public void GetBinary_minus0point0_1000000000000000000000000000000000000000000000000000000000000000_Returned()
        {
            double number = -0.0;
            Assert.AreEqual(number.GetBinary(), "1000000000000000000000000000000000000000000000000000000000000000");
        }

        [TestMethod]
        public void GetBinary_0point0_0000000000000000000000000000000000000000000000000000000000000000_Returned()
        {
            double number = 0.0;
            Assert.AreEqual(number.GetBinary(), "0000000000000000000000000000000000000000000000000000000000000000");
        }
    }
}
