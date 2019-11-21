using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FindGCD.Tests
{
    [TestClass]
    public class FindGCD
    {
        [TestMethod]
        public void GetGcd_Null_ArgumentNullExceptionReturned()
        {
            Assert.ThrowsException<ArgumentNullException>(() => GCD.GetGcd(out Stopwatch timeSpend, null));
        }

        [TestMethod]
        public void GetGcd_minus5_5_minus55_5Returned()
        {
            Assert.AreEqual(GCD.GetGcd(out Stopwatch timeSpend, -5, 5, -55), 5);
            Assert.IsTrue(TestGetGcdFromIntegers_TimeSpend(timeSpend));
        }

        [TestMethod]
        public void GetGcd_1_0_0_0_1Returned()
        {
            Assert.AreEqual(GCD.GetGcd(out Stopwatch timeSpend, 1, 0, 0, 0), 1);
            Assert.IsTrue(TestGetGcdFromIntegers_TimeSpend(timeSpend));
        }

        [TestMethod]
        public void GetGcd_0_1_0_1_1Returned()
        {
            Assert.AreEqual(GCD.GetGcd(out Stopwatch timeSpend, 0, 1, 0, 1), 1);
            Assert.IsTrue(TestGetGcdFromIntegers_TimeSpend(timeSpend));
        }

        [TestMethod]
        public void GetGcd_intMinValue_0_0_ArgumentOutOfRangeExceptionReturned()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GCD.GetGcd(out Stopwatch timeSpend, int.MinValue, 0, 0));
        }

        [TestMethod]
        public void GetGcd_intMaxValue_0_0_intMaxValueReturned()
        {
            Assert.AreEqual(GCD.GetGcd(out Stopwatch timeSpend, int.MaxValue, 0, 0), int.MaxValue);
            Assert.IsTrue(TestGetGcdFromIntegers_TimeSpend(timeSpend));
        }

        [TestMethod]
        public void GetGcd_0_0_0_0Returned()
        {
            Assert.AreEqual(GCD.GetGcd(out Stopwatch timeSpend, 0, 0, 0), 0);
            Assert.IsTrue(TestGetGcdFromIntegers_TimeSpend(timeSpend));
        }

        [TestMethod]
        public void GetGcdTest_0_100_0_100Returned()
        {
            Assert.AreEqual(GCD.GetGcd(out Stopwatch timeSpend, 0, 100, 0), 100);
            Assert.IsTrue(TestGetGcdFromIntegers_TimeSpend(timeSpend));
        }

        [TestMethod]
        public void GetGcdTest_5_minus7455_1075_5Returned()
        {
            Assert.AreEqual(GCD.GetGcd(out Stopwatch timeSpend, 5, -7455, 1075), 5);
            Assert.IsTrue(TestGetGcdFromIntegers_TimeSpend(timeSpend));
        }

        [TestMethod]
        public void GetGcdTest_9_54_99_9Returned()
        {
            Assert.AreEqual(GCD.GetGcd(out Stopwatch timeSpend, 9, 54, 99), 9);
            Assert.IsTrue(TestGetGcdFromIntegers_TimeSpend(timeSpend));
        }

        [TestMethod]
        public void GetGcd_minus5_minus55_5Returned()
        {
            Assert.AreEqual(GCD.GetGcd(out Stopwatch timeSpend, -5, -55), 5);
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
