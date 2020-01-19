using System;
using System.Collections.Generic;
using BLL.Interface.Interfaces;
using BLL.Interface.Entities;
using DAL.EF;
using DependencyResolver;
using Ninject;
using System.Data.Entity;

namespace ConsolePL
{
    class Program
    {
        private static readonly IKernel Resolver;

        static Program()
        {
            Resolver = new StandardKernel();
            Resolver.ConfigurateResolver();
        }

        public static void Main()
        {            
            IAccountService bankManager = Resolver.Get<IAccountService>();
            IAccountGetId getId = Resolver.Get<IAccountGetId>();
            Database.SetInitializer(new AccoiuntStorageInitialazer());

            try
            {
                Console.WriteLine("AddTest");
                Addtest(bankManager, getId);               

                Console.WriteLine("DepositMoneyTest");
                DepositMoneyTest(bankManager);                

                Console.WriteLine("WithdrawMoneyTest");
                WithdrawMoneyTest(bankManager);                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        private static void Addtest(IAccountService bankManager, IAccountGetId getId)
        {
            bankManager.OpenAccount("fname1 sName1", AccountType.Base, getId);
            bankManager.OpenAccount("fname2 sName2", AccountType.Platinum, getId);

            ShowAccounts(bankManager.GetAccounts());
        }

        private static void WithdrawMoneyTest(IAccountService bankManager)
        {
            bankManager.WithdrawMoney(1, 4m);
            ShowAccounts(bankManager.GetAccounts());
        }

        private static void DepositMoneyTest(IAccountService bankManager)
        {
            bankManager.DepositMoney(1, 8m);
            ShowAccounts(bankManager.GetAccounts());
        }

        private static void ShowAccounts(IEnumerable<Account> accounts)
        {
            foreach (var account in accounts)
            {
                Console.WriteLine(string.Format($"First name: {account.FirstName,-20} Balance: {account.Score,-15} Number: {account.BonusPoint}"), account);
                Console.WriteLine(string.Format($"Last name: {account.Surname,-21} Status: {account.Surname,-17} Type: {account.GetType()}"), account);
            }

            Console.WriteLine(new string('-', 80));
        }        
    }
}
