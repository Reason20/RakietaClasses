namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tasks
    {
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

        public int ContractorSetId { get; set; }

        public virtual ContractorSets Contractor { get; set; }

        public virtual Deals Deal { get; set; }

        public virtual WorkerSets WorkerSets { get; set; }
    }
}
