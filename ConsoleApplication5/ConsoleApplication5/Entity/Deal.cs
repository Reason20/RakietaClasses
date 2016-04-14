namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Deal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Deal()
        {
            DealActions = new HashSet<DealActions>();
            DealComments = new HashSet<DealComment>();
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

        public DateTime CreateDate { get; set; }

        public DateTime LastEditTime { get; set; }

        public int? UserId { get; set; }

        public int? ContractorId { get; set; }

        public int CreatorId { get; set; }

        public int MenagerId { get; set; }



        public int LastEditor { get; set; }

        public virtual Contractor Contractor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DealActions> DealActions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DealComment> DealComments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DealFileTables> DealFileTables { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tasks> Tasks { get; set; }

        public virtual User User { get; set; }

        public virtual User DealCreator { get; set; }

        public virtual User DealMenager { get; set; }

        public virtual User Editor { get; set; }
    }
}
