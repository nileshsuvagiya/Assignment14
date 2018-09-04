using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpAssignment14
{
    class Program
    {
        static void Main(string[] args)
        {
            Account jointAccount = new Account();
            CustomerBankAccount customer1 = new CustomerBankAccount(jointAccount, "Nilesh Suvagiya");
            CustomerBankAccount customer2 = new CustomerBankAccount(jointAccount, "Ashutosh Shahi");
            void Customer1Deposit()
            {
                Console.WriteLine("==================================================================");
                jointAccount.Deposit(1000.00);
                Console.WriteLine("{0} : A/C {1} ; Deposited {2} ; Balance {3} ", customer1.CustomerName, jointAccount.AccountNumber, "1000.00", jointAccount.GetBalance);
                Console.WriteLine("==================================================================");

            }
            void Customer2Withdraw()
            {
                Console.WriteLine("******************************************************************");
                jointAccount.Withdrawal(500.00);
                Console.WriteLine("{0} : A/C {1} ; Withdrawal {2} , Balance {3} ", customer2.CustomerName, jointAccount.AccountNumber, "500.00", jointAccount.GetBalance);
                Console.WriteLine("*******************************************************************");
            }

            Thread[] ts = new Thread[10];
            for (int i = 0; i < 10; i = i + 2)
            {
                ts[i] = new Thread(new ThreadStart(Customer1Deposit));
                ts[i + 1] = new Thread(new ThreadStart(Customer2Withdraw));
            }

            for (int i = 0; i < 10; i += 2)
            {
                ts[i].Start();
                Thread.Sleep(100);
                ts[i + 1].Start();
            }

            Console.ReadLine();

        }
    }
}
