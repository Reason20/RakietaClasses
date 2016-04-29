using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RakietaLogikaBiznesowa.Models
{
    public class rsa
    {

        public rsa() 
        {
            
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(5000)]
        public string publicKey { get; set; }
       
        [Column(TypeName = "VARCHAR")]
        [StringLength(5000)]
        public string privateKey { get; set; }

    }
}