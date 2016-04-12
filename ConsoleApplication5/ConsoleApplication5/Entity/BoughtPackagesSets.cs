namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BoughtPackagesSets
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public int PackagesId { get; set; }

        public int UserId { get; set; }

        public DateTime LastEditTime { get; set; }

        public int? LastEditor { get; set; }

        public int FactureId { get; set; }

        public virtual PackagesSets BoughtPackage { get; set; }

        public virtual FactureSets PackageFacture { get; set; }

        public virtual UserSets User { get; set; }

        public virtual WorkerSets WorkerSets { get; set; }
    }
}
