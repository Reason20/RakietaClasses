using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RakietaLogikaBiznesowa.Models
{
    public class BankCreator
    {
        public string BankAccountNumber { get; set; }
        public string CardNumber { get; set; }
        public BankAccount Bank { get; set; }
    }
}