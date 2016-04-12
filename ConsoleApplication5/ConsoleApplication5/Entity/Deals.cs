namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Deals
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Deals()
        {
            DealActions = new HashSet<DealActions>();
            DealComments = new HashSet<DealComments>();
            DealFileTables = new HashSet<DealFileTables>();
            Tasks = new HashSet<Tasks>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public DealStages CurrentStage { get; set; }

        public DealStages? ClosingStage { get; set; }

        public string Note { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime CrDate { get; set; }

        public DateTime LastEditTime { get; set; }

        public int? UserId { get; set; }

        public int? ContractorId { get; set; }

        public int CreatorId { get; set; }

        public int WorkerId { get; set; }

        public int LastEditor { get; set; }

        public virtual ContractorSets Contractor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DealActions> DealActions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DealComments> DealComments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DealFileTables> DealFileTables { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tasks> Tasks { get; set; }

        public virtual UserSets User { get; set; }

        public virtual WorkerSets WorkerSets { get; set; }

        public virtual WorkerSets WorkerSets1 { get; set; }

        public virtual WorkerSets WorkerSets2 { get; set; }
    }
}
