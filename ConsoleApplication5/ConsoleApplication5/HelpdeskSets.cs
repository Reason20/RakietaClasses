namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HelpdeskSets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HelpdeskSets()
        {
            HelpdeskFileTables = new HashSet<HelpdeskFileTables>();
            HelpDeskPartialHistorySets = new HashSet<HelpDeskPartialHistorySets>();
        }

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

        public int UserId { get; set; }

        public int WorkerId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HelpdeskFileTables> HelpdeskFileTables { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HelpDeskPartialHistorySets> HelpDeskPartialHistorySets { get; set; }

        public virtual UserSets UserSets { get; set; }

        public virtual WorkerSets WorkerSets { get; set; }
    }
}
