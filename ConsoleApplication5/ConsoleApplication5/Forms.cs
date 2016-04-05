namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Forms
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Forms()
        {
            FormAnswers = new HashSet<FormAnswers>();
            FormDevices = new HashSet<FormDevices>();
            FormQuestions = new HashSet<FormQuestions>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime FormStartTime { get; set; }

        public DateTime FormEndTime { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastEditTime { get; set; }

        public int TagId { get; set; }

        public int WorkerSetId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormAnswers> FormAnswers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormDevices> FormDevices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormQuestions> FormQuestions { get; set; }

        public virtual Tags Tags { get; set; }

        public virtual WorkerSets WorkerSets { get; set; }
    }
}
