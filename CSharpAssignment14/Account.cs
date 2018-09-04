using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpAssignment14
{
    public class Account
    {

        private string _accountNumber;

        private string _customerAddress;

        private double _balance;

        private static object _lock= new object();

        public Account()
        {
            

            this._accountNumber = (new Random().Next(1, 100)).ToString();
        }

        public void Withdrawal(double amount)
        {
            try
            {
                Monitor.Enter(_lock);
                {
                    if (this._balance > amount)
                    {
                        this._balance -= amount;
                        Console.WriteLine("Customer(A/C:{0}) :  has withdrawed {1} amount", AccountNumber, amount.ToString());
                    }

                }
            }
            finally
            {
                Monitor.Exit(_lock);
            }

        }

        public void Deposit(double amount)
        {
            try
            {
                Monitor.Enter(_lock);
                this._balance += amount;
                Console.WriteLine("Customer(A/C:{0}) : has deposited {1} amount ", AccountNumber, amount.ToString());
            }
            finally
            {
                Monitor.Exit(_lock);
            }

        }

        public double GetBalance
        {
            get
            {
                try
                {
                    Monitor.Enter(_lock);
                    return this._balance;
                }
                finally
                {
                    Monitor.Exit(_lock);
                }

            }
        }


        public string AccountNumber { get => _accountNumber; set => _accountNumber = value; }
        public string CustomerAddress { get => _customerAddress; set => _customerAddress = value; }
    }
}
