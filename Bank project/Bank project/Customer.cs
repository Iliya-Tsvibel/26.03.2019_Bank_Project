using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_project
{
    public class Customer
    {
        private static int numberOfCust;
        private readonly int customerID;
        private readonly int customerNumber;


        public string Name { get; private set; }
        public int PhNumber { get; private set; }
        public int CustomerID
        {
            get
            {
                return this.customerID; //?
            }
        }
        public int CustomerNumber
        {
            get
            {
                return this.customerNumber; //?
            }

        }

        public Customer(string name, int phNumber, int customerID)
        {
            Name = name;
            PhNumber = phNumber;
            this.customerID = customerID; //?
            this.customerNumber = numberOfCust++; //?

        }

        public static bool operator ==(Customer cust1, Customer cust2)
        {
            if (cust1.CustomerNumber == cust2.CustomerNumber)
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(Customer cust1, Customer cust2)
        {
            if (cust1.CustomerNumber != cust2.CustomerNumber)
            {
                return true;
            }

            return false;
        }

        public override bool Equals(object ob)
        {
            if (ob is Customer)
            {
                Customer cust = ob as Customer;
                return this == cust;
            }
            return false;

        }

        public override int GetHashCode()
        {
            return this.CustomerNumber;
        }
    }
}
