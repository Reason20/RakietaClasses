namespace RakietaLogikaBiznesowa.Models
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
            Payoffs = new HashSet<Payoff>();
            Date = DateTime.Now;
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

        public int? LastEditor { get; set; }

        public int FactureId { get; set; }

        public int? MoneyboxId { get; set; }

        public virtual Contractor ContractorPayer { get; set; }

        public virtual Facture IncomeFacture { get; set; }

        public virtual Moneybox Moneybox { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payoff> Payoffs { get; set; }

        public virtual User UserPayer { get; set; }

        public virtual User Editor { get; set; }
    }
}
