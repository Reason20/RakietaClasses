namespace RakietaLogikaBiznesowa.Models
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
            Payoffs = new HashSet<Payoff>();
            MailSms = new HashSet<MailerSmser>();
            CrDate = DateTime.Now;
            EndDate = DateTime.Now;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public decimal Value { get; set; }

        public DateTime CrDate { get; set; }

        public DateTime EndDate { get; set; }

        public double Interests { get; set; }

        public bool InTime { get; set; }

        public bool IsPaid { get; set; }

        public int FactureId { get; set; }

        public VindicationStatus Status { get; set; }

        public string Comments { get; set; }

        public int? TemplateId { get; set; }

        public int? LastEditor { get; set; }

        public virtual Facture Facture { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payoff> Payoffs { get; set; }

        public virtual User Editor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MailerSmser> MailSms { get; set; }

        public virtual Template Template { get; set; }

    }
}
