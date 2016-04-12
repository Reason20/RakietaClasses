namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ExerciseSets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExerciseSets()
        {
            ExReportsSets = new HashSet<ExReportsSets>();
            Worker = new HashSet<UserSets>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Note { get; set; }

        public bool IsGroup { get; set; }

        public short TimeCount { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime StopTime { get; set; }

        public short MaxPeople { get; set; }

        public int RoomsId { get; set; }

        public int PackagesId { get; set; }

        public TypesOfExercise TypeOf { get; set; }

        [Required]
        public string ParticipantsList { get; set; }

        public int ExTypesKey { get; set; }

        public DateTime LastEditTime { get; set; }

        public int LastEditor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExReportsSets> ExReportsSets { get; set; }

        public virtual ExTypesSets ExTypesSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual PackagesSets PackagesSets { get; set; }

        public virtual RoomsSets RoomsSets { get; set; }

        public virtual UserSets Editor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserSets> Worker { get; set; }
    }
}
