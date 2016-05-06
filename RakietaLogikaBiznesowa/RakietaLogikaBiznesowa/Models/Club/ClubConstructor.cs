using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RakietaLogikaBiznesowa.Models
{
    public class ClubConstractor
    {
        //Club:
        public int id { get; set; }

        [Required]
        public string Name { get; set; }

        //Address:
        public Address Address { get; set; }

        public int AddressOldId { get; set; }
        //Contact:
        public Contact Contact { get; set; }
    }
}