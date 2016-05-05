using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RakietaLogikaBiznesowa.Models
{
    public class UserAndBank : UserCreator
    {
        public int User { get; set; }
        public int Bank { get; set; }

    }
}