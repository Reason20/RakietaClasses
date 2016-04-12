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
            Payoffs = new HashSet<PayoffSet>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public double Value { get; set; }

        public TypeOfPayment TypeOfPaid { get; set; }

        public int? UserId { get; set; }

        public int? ContractorId { get; set; }

        public int? LastEditUser { get; set; }

        public int FactureId { get; set; }

        public int? MoneyboxId { get; set; }

        public virtual ContractorSets ContractorPayer { get; set; }

        public virtual FactureSets IncomeFacture { get; set; }

        public virtual MoneyboxSet Moneybox { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PayoffSet> Payoffs { get; set; }

        public virtual UserSets UserPayer { get; set; }

        public virtual WorkerSets WorkerSets { get; set; }
    }
}
