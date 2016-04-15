namespace RakietaLogikaBiznesowa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tasks
    {
        public Tasks()
        {
            EndDate = DateTime.Now;
            StartDate = DateTime.Now;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Note { get; set; }

        public int DealId { get; set; }

        public int WorkerId { get; set; }

        public int ContractorId { get; set; }

        public virtual Contractor Contractor { get; set; }

        public virtual Deal Deal { get; set; }

        public virtual User Worker { get; set; }

    }
}
