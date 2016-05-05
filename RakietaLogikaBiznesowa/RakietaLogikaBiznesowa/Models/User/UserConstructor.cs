using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RakietaLogikaBiznesowa.Models
{
    public class UserConstructor
    {

        //User :: 

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Pesel { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime JoinDate { get; set; }

        public MaleFemale Sex { get; set; }

        public string PlaceOfBirth { get; set; }

        [Required]
        public string IDNumber { get; set; }

        public string Notes { get; set; }

        public int ReferId { get; set; }

        public int ContractorId { get; set; }

        public int MoneyBoxId { get; set; }

        public bool IsWorker { get; set; }

        public int MainAddress { get; set; }

        public int ContactId { get; set; }

        // Bank ::
        public BankConstructor Bank { get; set; }

        public int BankId { get; set; }

        public bool DeleteOldBank { get; set; }
        // Temp ::

        public int AddressOldId { get; set; }


        // Other Models ::

        public Address Address { get; set; }

        public Contact Contact { get; set; }

    }
}