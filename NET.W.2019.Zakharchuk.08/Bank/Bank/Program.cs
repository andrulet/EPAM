using System;
using System.Collections.Generic;
using AccountInfo;
using ServiceAccount;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Account a1 = new Account(100, "A1", "B1", 1000, 0, StatusAccount.Activate, TypeAccount.Base);
            Account a2 = new Account(101, "A2", "B2", 2000, 0, StatusAccount.Activate, TypeAccount.Gold);
            Account a3 = new Account(102, "A3", "B3", 3000, 0, StatusAccount.Activate, TypeAccount.Platium);
            Account a4 = new Account(103, "A4", "B4", 4000, 0, StatusAccount.Activate, TypeAccount.Base);
            Account a5 = new Account(104, "A5", "B5", 5000, 0, StatusAccount.Activate, TypeAccount.Gold);
            Account a6 = new Account(105, "A6", "B6", 6000, 0, StatusAccount.Activate, TypeAccount.Platium);

            Service service = new Service();
            service.CreateAccount(new Account(100, "A1", "B1", 1000, 0, StatusAccount.Activate, TypeAccount.Base));
            service.CreateAccount(new Account(101, "A2", "B2", 2000, 0, StatusAccount.Activate, TypeAccount.Gold));
            service.CreateAccount(new Account(102, "A3", "B3", 3000, 0, StatusAccount.Activate, TypeAccount.Platium));
            service.CreateAccount(new Account(102, "A3", "B3", 3000, 0, StatusAccount.Activate, TypeAccount.Platium));

            Print(service.GetAllAccounts());

            service.AddAmount(100, 500);
            Print(service.GetAllAccounts());

            service.CloseAccount(101);
            Print(service.GetAllAccounts());

            service.WithdrowAmount(102, 100);
            Print(service.GetAllAccounts());

            Console.ReadKey();
        }

        private static void Print(IEnumerable<Account> accounts)
        {
            foreach (var acc in accounts)
            {
                Console.WriteLine(acc.ToString());
            }
            Console.WriteLine();
        }
    }
}
