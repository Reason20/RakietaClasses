﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RakietaLogikaBiznesowa.Models
{
    public class ContractorAndAddress
    {
        public int MoneyboxId { get; set; }
        public Contractor Contractor { get; set; }
        public Address Address { get; set; }
    }
}