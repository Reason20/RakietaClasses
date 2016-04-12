namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DealActions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public TypesOfDealAction Type { get; set; }

        public DateTime Date { get; set; }

        public string Note { get; set; }

        public DateTime LastEditTime { get; set; }

        public int? UserId { get; set; }

        public int? ContractorId { get; set; }

        public int CreatorId { get; set; }

        public int LastEditor { get; set; }

        public int DealId { get; set; }

        public virtual ContractorSets Contractor { get; set; }

        public virtual Deals Deals { get; set; }

        public virtual UserSets User { get; set; }

        public virtual WorkerSets WorkerSets { get; set; }

        public virtual WorkerSets WorkerSets1 { get; set; }
    }
}
