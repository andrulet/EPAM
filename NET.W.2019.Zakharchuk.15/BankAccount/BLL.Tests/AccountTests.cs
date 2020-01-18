using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.Interface.Entities;

namespace BLL.Testa
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void CheckIdOnNegatveNumber()
        {
            Assert.ThrowsException<ArgumentException>(() => new BaseAccount(-100, "Pedro", "Petrov"));
        }

        [TestMethod]
        public void CheckFirstNAmeOnEmpty()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new BaseAccount(100, string.Empty, "Petrov"));
        }

        [TestMethod]
        public void CheckSurnameOnEmpty()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new BaseAccount(100, "Pedro", string.Empty));
        }

        [TestMethod]
        public void CheckFirstNAmeOnNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new BaseAccount(100, null, "Petrov"));
        }

        [TestMethod]
        public void CheckSurnameOnNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new BaseAccount(100, "Pedro", null));
        }
    }
}
