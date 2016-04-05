namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Incomes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Incomes()
        {
            PayoffSet = new HashSet<PayoffSet>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public double Value { get; set; }

        public TypeOfPayment TypeOfPaid { get; set; }

        public int? UserId { get; set; }

        public int? ContractorId { get; set; }

        public int LastEditUser { get; set; }

        public int FactureId { get; set; }

        public int ClubId { get; set; }

        public int? MoneyboxId { get; set; }

        public virtual ClubInfoSets ClubInfoSets { get; set; }

        public virtual ContractorSets ContractorSets { get; set; }

        public virtual FactureSets FactureSets { get; set; }

        public virtual MoneyboxSet MoneyboxSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PayoffSet> PayoffSet { get; set; }

        public virtual UserSets UserSets { get; set; }

        public virtual WorkerSets WorkerSets { get; set; }
    }
}
