using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RakietaLogikaBiznesowa.Models
{
    public class ContractorConstructor
    {

        // Constructor ::
        public string NIP { get; set; }
        
        public string REGON { get; set; }

        public string Name { get; set; }

        public string Comments { get; set; }

        public DateTime LastEditTime { get; set; }


        // HiddenFor ::

        public int Id { get; set; }




        // Object Creator
        public Address Address { get; set; }

        public Contact Contact { get; set; }

        public int MoneyboxId { get; set; }

        public int AddressOldId { get; set; }

    }
}