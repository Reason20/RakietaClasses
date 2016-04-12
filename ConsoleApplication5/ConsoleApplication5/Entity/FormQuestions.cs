namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FormQuestions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FormQuestions()
        {
            QuestionAnswers = new HashSet<FormAnswers>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime CreateTime { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime LastEditTime { get; set; }

        public int FormId { get; set; }

        public int WorkerSetId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormAnswers> QuestionAnswers { get; set; }

        public virtual Forms Forms { get; set; }

        public virtual WorkerSets WorkerSets { get; set; }
    }
}
