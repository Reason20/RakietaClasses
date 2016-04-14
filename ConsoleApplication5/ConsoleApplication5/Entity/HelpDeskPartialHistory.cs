namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HelpDeskPartialHistory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HelpDeskPartialHistory()
        {
            HelpdeskFileTables = new HashSet<HelpdeskFileTables>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public HelpdeskStatus Status { get; set; }

        public DateTime AnswerDate { get; set; }

        [Required]
        public string AnswerText { get; set; }

        public int HelpdeskId { get; set; }

        public int? WorkerId { get; set; }

        public int? RecipientId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HelpdeskFileTables> HelpdeskFileTables { get; set; }

        public virtual Helpdesk HelpdeskApplication { get; set; }

        public virtual User Recipient { get; set; }

        public virtual User Worker { get; set; }
    }
}
