using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_project
{
    public class Account
    {
        private static int numberOfAcc;
        private readonly int accountNumber;
        private readonly Customer accountOwner;
        private int maxMinusAllowed;
        public int AccountNumber
        {
            get
            {
                return this.accountNumber;
            }
        }
        public int Balance { get; private set; }
        public Customer AccountOwner
        {
            get
            {
                return accountOwner;
            }
        }
        public int MaxMinusAllowed
        {
            get
            {
                return maxMinusAllowed;
            }
        }

        public Account(Customer cust, int monthlyIncome)
        {
            accountNumber = numberOfAcc++;
            maxMinusAllowed = monthlyIncome * 3;

        }

        public void Add(int amountMoney)
        {
            Balance = Balance + amountMoney;
        }
        public static bool operator ==(Account a1, Account a2)
        {
            if (a1.AccountNumber == a2.AccountNumber)
                return true;
            return false;
        }

        public void Substract(int amountMoney)
        {
            Balance = Balance - amountMoney;
        }

        public static bool operator !=(Account acc1, Account acc2)
        {
            if (acc1.AccountNumber != acc2.AccountNumber)
            {
                return true;
            }

            return false;
        }


        public override bool Equals(object ob)
        {
            if (ob is Account)
            {
                Account acc1 = ob as Account;
                return this == acc1;

            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.AccountNumber;
        }

        public static Account operator +(Account acc1, Account acc2)
        {

            {
                Account acc3 = new Account(acc1.accountOwner, acc1.maxMinusAllowed / 3);
                acc3.Balance = acc1.Balance + acc2.Balance;
                acc3.maxMinusAllowed = acc1.maxMinusAllowed + acc2.maxMinusAllowed;
                return acc3;
            }
        }
    }
}
