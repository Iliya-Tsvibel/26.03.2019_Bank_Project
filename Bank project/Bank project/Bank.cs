using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_project
{
    public class Bank : IBank
    {

        private List<Account> ListAccount = new List<Account>();
        private List<Customer> ListCustomer = new List<Customer>();
        private Dictionary<int, Customer> customerID = new Dictionary<int, Customer>();
        private Dictionary<int, Customer> customerNum = new Dictionary<int, Customer>();
        private Dictionary<int, Account> accountNum = new Dictionary<int, Account>();
        private Dictionary<Customer, List<Account>> dicCustomer = new Dictionary<Customer, List<Account>>();
        private int totalMoney;
        private int profits;

        public string Name { get; set; } // set for the methid bellow

        public string Adress { get; set; } // set for the methid bellow

        public int CustomerCount
        {
            get
            {
                return ListCustomer.Count();
            }
            set
            {

            }
        }
        public Bank(string adress, int customerCount, string name)
        {
            Adress = adress;
            CustomerCount = customerCount;
            Name = name;
        }

        internal Customer GetCustomerByID(int customerid)
        {
            if (customerID.TryGetValue(customerid, out Customer cust))
            {
                return cust;
            }
            else
            {
                throw new CustomerNotFoundException($"The customer with ID {customerid} not exist in this bank");
            }
        }

        internal Customer GetCustomerByNumber(int customerNumber)
        {
            if (customerNum.TryGetValue(customerNumber, out Customer cust))
            {
                return cust;
            }
            else
            {
                throw new CustomerNotFoundException($"The costumer with number{customerNumber} not exist in this bank");
            }
        }
        internal Account GetAccountByNumber(int accountNumber)
        {
            if (accountNum.TryGetValue(accountNumber, out Account acc))
            {
                return acc;
            }
            else
            {
                throw new AccountNotFoundException($"The customer account number {accountNumber} not exist in this bank");
            }
        }
        internal List<Account> GetAccountsByCustomer(Customer cust)
        {
            if (dicCustomer.TryGetValue(cust, out List<Account> acc))
            {
                return acc;
            }
            else
            {
                throw new AccountNotFoundException($"The customer {cust} not exist in this bank");
            }
        }

        internal void AddNewCustomer(Customer cust)
        {
            if (ListCustomer.Contains(cust))
            {
                throw new CustomerAlreadyExistException($"The customer {cust.Name} already exist in this bank");
            }
            else
            {
                ListCustomer.Add(cust);
                customerID.Add(cust.CustomerID, cust);
                customerNum.Add(cust.CustomerNumber, cust);

            }
           

        }
        internal void OpenNewAccount(Customer cust, Account acc)
        {
            if (ListAccount.Contains(acc))
            {
                throw new AccountAlreadyExistException($"The customer account number {acc} already exist in this bank");
            }
            else
            {
                ListAccount.Add(acc);
                accountNum.Add(acc.AccountNumber, acc);
                List<Account> accList = new List<Account>();
                accList.Add(acc);
                dicCustomer.Add(cust, accList);
                //totalMoney = totalMoney + acc.Balance;  // In Deposit function
            }



        }
        internal int Deposit(Account acc, int amountMoney)
        {
            if (ListAccount.Contains(acc))
            {
                acc.Add(amountMoney);
                totalMoney = totalMoney + amountMoney;
                return acc.Balance;
            }
            else
            {
                throw new AccountNotFoundException($"The customer account {acc} not exist in this bank");
            }


        }
        internal int Withdraw(Account acc, int amountMoney)
        {
            totalMoney = totalMoney - amountMoney;
            acc.Substract(amountMoney);
            if (acc.Balance < acc.MaxMinusAllowed)
            {
                throw new BalanceException($"The account {acc} already out of the possible minus");
            }
            return acc.Balance;
        }

        internal int GetCustomerTotalBalance(Customer cust)
        {
            int sumBall = 0;
            dicCustomer.TryGetValue(cust, out List<Account> listcust);
            foreach (Account acc in listcust)
            {
                sumBall = sumBall + acc.Balance;
            }
            return sumBall;
        }

        internal void CloseAccount(Account acc, Customer cust)
        {
            if (ListAccount.Contains(acc))
            {
                if (acc.Balance < 0)
                    throw new CustomerNotAllowedToCloseAccountException($"Thiss account cant be closed");
                else
                {
                    ListAccount.Remove(acc);
                    totalMoney = totalMoney - acc.Balance;

                }
                
            }
            else
            {
             
                if (!ListAccount.Contains(acc))
                    throw new AccountNotFoundException($"This account is not exist");
            }

        }

        internal void ChargeAnnualCommossion(float percent)
        {
            float comiss = 1f;

            foreach (Account acc in ListAccount)
            {
                if (acc.Balance < acc.MaxMinusAllowed)
                {
                    percent = percent * 4.5f;
                    profits = profits - Convert.ToInt32(comiss);

                }
                else
                {
                    
                    comiss = comiss * 1.5f;
                    profits = profits + Convert.ToInt32(comiss);

                    
                }

               

            }
        }

      

        //internal void JoinAccounts(Account acc1, Account acc2)
        //{
        //    if (acc1.AccountOwner.CustomerID == acc2.AccountOwner.CustomerID)
        //    {
        //        throw new NotSameCustomerException($"The accounts {acc1.AccountNumber} + {acc2.AccountNumber} it is can't be the same customer");
        //    }
        //    else
        //    {
        //        Account acc3 = acc1 + acc2;
        //        CloseAccount(acc1, acc1.AccountOwner);
        //        CloseAccount(acc2, acc2.AccountOwner);
        //        AddNewCustomer(acc3.AccountOwner);
        //        OpenNewAccount(acc3.AccountOwner, acc3);
        //    }

        //}

      
        

    }
}
