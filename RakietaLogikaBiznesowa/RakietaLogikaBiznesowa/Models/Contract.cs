namespace RakietaLogikaBiznesowa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Contract
    {
        public Contract()
        {
            LastEditTime = DateTime.Now;
            AgreementDate = DateTime.Now;
            From = DateTime.Now;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime AgreementDate { get; set; }

        public DateTime From { get; set; }

        public DateTime? To { get; set; }

        public bool IsValid { get; set; }

        public double Salary { get; set; }

        public short Payday { get; set; }

        public short WorkingHours { get; set; }

        public TypesOfContract Type { get; set; }

        public int WorkerId { get; set; }

        public DateTime LastEditTime { get; set; }

        public int? LastEditor { get; set; }

        public virtual User Worker { get; set; }

        public virtual User Editor { get; set; }
    }
}
