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
            MailerSmserSets = new HashSet<MailerSmserSets>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public double Value { get; set; }

        public DateTime CrDate { get; set; }

        public DateTime EndDate { get; set; }

        public double Interests { get; set; }

        public bool InTime { get; set; }

        public int FactureId { get; set; }

        public VindicationStatus Status { get; set; }

        public string Comments { get; set; }

        public int? TemplateId { get; set; }

        public int? LastEditor { get; set; }

        public virtual FactureSets FactureSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PayoffSet> PayoffSet { get; set; }

        public virtual WorkerSets WorkerSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MailerSmserSets> MailerSmserSets { get; set; }

        public virtual TemplateSets TemplateSets { get; set; }

    }
}
