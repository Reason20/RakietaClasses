using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RakietaLogikaBiznesowa.Models
{
    public class BankConstructor
    {
        public BankConstructor()
        {
            Bank = new BankAccount();
        }

        public string BankAccountNumber { get; set; }
        public string CardNumber { get; set; }
        public BankAccount Bank { get; set; }

        //HiddenFor  ::

        public int Id { get; set; }

        public DateTime LastEditTime { get; set; }
    }
}