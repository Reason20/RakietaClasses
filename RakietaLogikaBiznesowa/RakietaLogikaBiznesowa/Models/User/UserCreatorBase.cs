using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace RakietaLogikaBiznesowa.Models
{
    public class UserCreatorBase
    {

        public int AddressOldId { get; set; }
        public User User { get; set; }
        public Address Address { get; set; }
        public Contact Contact { get; set; }
        public BankAccount Bank { get; set; }
        public int ReferId { get; set; }
        public int MoneyboxId { get; set; }
        public string Password { get; set; }
        public long Pesel { get; set; }
        public string IDNumber { get; set; }
        public string BankAccountNumber { get; set; }
        public string CardNumber { get; set; }
    }
}