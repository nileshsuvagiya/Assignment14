using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAssignment14
{
    public class CustomerBankAccount 
    {
        private string customerName;
        public CustomerBankAccount(Account account, string customerName)
        {
            MyAccount = account;
            this.customerName = customerName;
        }

        public string CustomerName { get { return customerName; } }
        public Account MyAccount { get; set; }


    }
}
