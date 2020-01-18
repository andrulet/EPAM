using System;
using System.Linq;
using BLL.Interface.Interfaces;
using BLL.Interface.Entities;
using DependencyResolver;
using Ninject;

namespace ConsolePL
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolver();
        }

        static void Main()
        {
            IAccountService service = resolver.Get<IAccountService>();
            IAccountGetId creator = resolver.Get<IAccountGetId>();

            service.OpenAccount("Account owner 1", AccountType.Base, creator);
            service.OpenAccount("Account owner 2", AccountType.Base, creator);
            service.OpenAccount("Account owner 3", AccountType.Gold, creator);
            service.OpenAccount("Account owner 4", AccountType.Base, creator);

            var creditNumbers = service.GetAccounts().Select(acc => acc.Id).ToArray();

            foreach (var t in creditNumbers)
            {
                service.DepositMoney(t, 100);
            }

            foreach (var item in service.GetAccounts())
            {
                Console.WriteLine(item.ToString());
            }

            foreach (var t in creditNumbers)
            {
                service.WithdrawMoney(t, 10);
            }

            foreach (var item in service.GetAccounts())
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadLine();
        }
    }
}
