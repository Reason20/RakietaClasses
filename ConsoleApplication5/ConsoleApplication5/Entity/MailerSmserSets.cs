namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MailerSmserSets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MailerSmserSets()
        {
            Recipient = new HashSet<UserSets>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime? SendDate { get; set; }

        [Required]
        public string Text { get; set; }

        public bool Send { get; set; }

        public int EditorId { get; set; }

        public MailSms Type { get; set; }

        public int? LoadsId { get; set; }

        public virtual UserSets Sender { get; set; }

        public virtual Loads Installment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserSets> Recipient { get; set; }
    }
}
