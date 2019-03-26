using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_project
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer Iliya = new Customer("Iliya", 1678, 1);
            Customer Yulia = new Customer("Yulia", 1754, 2);
            Customer Igor = new Customer("Igor", 1789, 3);
            Account acc1 = new Account(Iliya, 18000);
            Account acc2 = new Account(Yulia, 12000);
            Account acc3 = new Account(Igor, 15000);
            Bank bank = new Bank("RishonLeZion", 8763, "Hapoalim");
            bank.AddNewCustomer(Iliya);
            bank.OpenNewAccount(Iliya, acc1);
            bank.OpenNewAccount(Yulia, acc2);
            //bank.JoinAccounts(acc1, acc2);
            try
            {
                bank.CloseAccount(acc3, Iliya);
            }
            catch (AccountNotFoundException e)
            {
                Console.WriteLine(e.StackTrace);
            }
            try
            {
                bank.GetCustomerByID(1);
            }
            catch (CustomerNotFoundException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
