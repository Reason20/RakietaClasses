using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RakietaLogikaBiznesowa.Models
{
    public class UsersAndAddress
    {

        public int AddressOldId { get; set; }
        public User User { get; set; }
        public Address Address { get; set; }
        public Contact Contact { get; set; }
        public int ReferId { get; set; }
        public int MoneyboxId { get; set; }
        public string Password { get; set; }

    }
}