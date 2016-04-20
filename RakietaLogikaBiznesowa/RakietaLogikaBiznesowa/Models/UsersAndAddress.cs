using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RakietaLogikaBiznesowa.Models
{
    public class UsersAndAddress
    {
        public int MoneyboxId { get;set; }
        public User User { get; set; }
        public Address Address { get; set; }
    }
}