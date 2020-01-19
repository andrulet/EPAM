using System;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Fake;
using Moq;

namespace BLL.Tests
{
    public class IAccountServiceTest
    {
        public void InitAccountTest_ReturnsAccount()
        {
            var mock = new Mock<IAccountService>();
            string owner = "Andrei Yes";
            AccountType type = AccountType.Base;
            AccountGenerateId creator = new AccountGenerateId();
            Account defaultAcc = new BaseAccount(1, "Andrei", "Yes");
            Account depositedAcc = new BaseAccount(1, "Andrei", "Yes", 2000);
            mock.Setup(accService => accService.OpenAccount(owner, type, creator)).Returns(defaultAcc);
        }

        public void InitAccountTest_ThrowsArgumentException()
        {
            var mock = new Mock<IAccountService>();
            mock.Setup(accService => accService.OpenAccount("", AccountType.Base, null)).Throws<ArgumentNullException>();
        }

    }
}
