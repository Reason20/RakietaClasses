namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Outcomes
    {
        public int Id { get; set; }

        public double Value { get; set; }

        public bool InTme { get; set; }

        public int FactureId { get; set; }

        public virtual FactureSets FactureSets { get; set; }
    }
}
