namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Loads
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Loads()
        {
            PayoffSet = new HashSet<PayoffSet>();
            VindicationSets = new HashSet<VindicationSets>();
        }

        public int Id { get; set; }

        public double Value { get; set; }

        public DateTime CrDate { get; set; }

        public DateTime EndDate { get; set; }

        public double Interests { get; set; }

        public bool InTime { get; set; }

        public int FactureId { get; set; }

        public virtual FactureSets FactureSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PayoffSet> PayoffSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VindicationSets> VindicationSets { get; set; }
    }
}
