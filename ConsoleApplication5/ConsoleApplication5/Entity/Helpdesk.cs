namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Helpdesk
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Helpdesk()
        {
            HelpdeskFileTables = new HashSet<HelpdeskFileTables>();
            AnswerHistory = new HashSet<HelpDeskPartialHistory>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public HelpdeskStatus Status { get; set; }

        public HelpdeskTypeOf TypeOf { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime Date { get; set; }

        public bool isAnswered { get; set; }

        public DateTime? AnswerDate { get; set; }

        public string AnswerText { get; set; }

        public int RecipientId { get; set; }

        public int? WorkerId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HelpdeskFileTables> HelpdeskFileTables { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HelpDeskPartialHistory> AnswerHistory { get; set; }

        public virtual User Recipient { get; set; }

        public virtual User Worker { get; set; }
    }
}
