namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BoughtPackagesSets
    {
        public int Id { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public int PackagesId { get; set; }

        public int UserId { get; set; }

        public DateTime LastEditTime { get; set; }

        public int LastEditor { get; set; }

        public int? FactureId { get; set; }

        public virtual PackagesSets PackagesSets { get; set; }

        public virtual FactureSets FactureSets { get; set; }

        public virtual UserSets UserSets { get; set; }

        public virtual WorkerSets WorkerSets { get; set; }
    }
}
