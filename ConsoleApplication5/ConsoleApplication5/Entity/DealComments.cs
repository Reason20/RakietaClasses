namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DealComments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public string Text { get; set; }

        public int DealId { get; set; }

        public int CreatorId { get; set; }

        public virtual Deals Deals { get; set; }

        public virtual UserSets Creator { get; set; }
    }
}
