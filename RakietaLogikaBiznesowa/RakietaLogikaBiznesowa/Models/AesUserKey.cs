using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RakietaLogikaBiznesowa.Models
{
    public class AesUserKey
    {


        [Key]
        public string Id { get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(5000)]
        public string IV { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(5000)]
        public string key { get; set; }

    }
}