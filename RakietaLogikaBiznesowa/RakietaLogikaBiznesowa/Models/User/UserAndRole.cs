using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RakietaLogikaBiznesowa.Models
{
    public class UserAndRole
    {

        public int UserId { get; set; }

        public int RoleId { get; set; }

    }
}