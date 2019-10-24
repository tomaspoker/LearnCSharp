using System;

namespace LearnCSharp
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            try
            {
                var account = new BankAccount("Tomas", -50);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
            }

            //account.MakeWithdrawal(500, DateTime.Now, "Rent payment");

            //Console.WriteLine(account.Balance);

            //account.MakeDeposit(100, DateTime.Now, "Friend paid me back");

            //Console.WriteLine(account.Balance);

            //Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance");
        }
    }
}
