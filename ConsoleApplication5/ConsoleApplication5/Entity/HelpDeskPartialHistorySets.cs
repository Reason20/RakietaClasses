namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HelpDeskPartialHistorySets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HelpDeskPartialHistorySets()
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

        public int? UserId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HelpdeskFileTables> HelpdeskFileTables { get; set; }

        public virtual HelpdeskSets HelpdeskSets { get; set; }

        public virtual UserSets UserSets { get; set; }

        public virtual WorkerSets WorkerSets { get; set; }
    }
}
