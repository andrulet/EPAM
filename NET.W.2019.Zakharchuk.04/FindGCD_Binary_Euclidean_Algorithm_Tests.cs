using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FindGCD.Tests
{
    [TestClass]
    public class FindGCD_Binary_Euclidean_Algorithm_Tests
    {
        [TestMethod]
        public void GetGcdTestFromIntegers_ArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => GCD.GetGcdByBinaryEuclideanAlgorithmFromIntegers(out Stopwatch timeSpend, null));
        }

        [TestMethod]
        public void GetGcdTestFromIntegers_minus5_5_55()
        {
            Assert.AreEqual(GCD.GetGcdByBinaryEuclideanAlgorithmFromIntegers(out Stopwatch timeSpend, -5, 5, -55), 5);
            Assert.IsTrue(TestGetGcdFromIntegers_TimeSpend(timeSpend));
        }

        [TestMethod]
        public void GetGcdTestFromIntegers_1_0_0_0()
        {
            Assert.AreEqual(GCD.GetGcdByBinaryEuclideanAlgorithmFromIntegers(out Stopwatch timeSpend, 1, 0, 0, 0), 1);
            Assert.IsTrue(TestGetGcdFromIntegers_TimeSpend(timeSpend));
        }

        [TestMethod]
        public void GetGcdTestFromIntegers_0_1_0_1()
        {
            Assert.AreEqual(GCD.GetGcdByBinaryEuclideanAlgorithmFromIntegers(out Stopwatch timeSpend, 0, 1, 0, 1), 1);
            Assert.IsTrue(TestGetGcdFromIntegers_TimeSpend(timeSpend));
        }

        [TestMethod]
        public void GetGcdTestFromIntegers_intMinValue_0_0()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GCD.GetGcdByBinaryEuclideanAlgorithmFromIntegers(out Stopwatch timeSpend, int.MinValue, 0, 0));
        }

        [TestMethod]
        public void GetGcdTestFromIntegers_0_0_0()
        {
            Assert.AreEqual(GCD.GetGcdByBinaryEuclideanAlgorithmFromIntegers(out Stopwatch timeSpend, 0, 0, 0), 0);
            Assert.IsTrue(TestGetGcdFromIntegers_TimeSpend(timeSpend));
        }

        [TestMethod]
        public void GetGcdTestFromIntegers_0_100_0()
        {
            Assert.AreEqual(GCD.GetGcdByBinaryEuclideanAlgorithmFromIntegers(out Stopwatch timeSpend, 0, 100, 0), 100);
            Assert.IsTrue(TestGetGcdFromIntegers_TimeSpend(timeSpend));
        }

        [TestMethod]
        public void GetGcdTestFromIntegers_5_minus7455_1075()
        {
            Assert.AreEqual(GCD.GetGcdByBinaryEuclideanAlgorithmFromIntegers(out Stopwatch timeSpend, 5, -7455, 1075), 5);
            Assert.IsTrue(TestGetGcdFromIntegers_TimeSpend(timeSpend));
        }

        [TestMethod]
        public void GetGcdTestFromIntegers_9_54_99()
        {
            Assert.AreEqual(GCD.GetGcdByBinaryEuclideanAlgorithmFromIntegers(out Stopwatch timeSpend, 9, 54, 99), 9);
            Assert.IsTrue(TestGetGcdFromIntegers_TimeSpend(timeSpend));
        }

        [TestMethod]
        public void GetGcdTestFromIntegers_minus9_minus55()
        {
            Assert.AreEqual(GCD.GetGcdByBinaryEuclideanAlgorithmFromIntegers(out Stopwatch timeSpend, -5, -55), 5);
            Assert.IsTrue(TestGetGcdFromIntegers_TimeSpend(timeSpend));
        }

        public bool TestGetGcdFromIntegers_TimeSpend(Stopwatch _timeSpend)
        {
            int timeCheck = (int)_timeSpend.ElapsedTicks;
            if (timeCheck < 140000)
            {
                return true;
            }

            Assert.Fail($"timeSpend = {(double)timeCheck / 100000}ms");
            return false;
        }
    }
}
