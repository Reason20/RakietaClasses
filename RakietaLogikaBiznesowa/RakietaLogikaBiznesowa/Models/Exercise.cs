namespace RakietaLogikaBiznesowa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Exercise
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Exercise()
        {
            Reports = new HashSet<ExerciseReports>();
            Worker = new HashSet<User>();
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
        public virtual ICollection<ExerciseReports> Reports { get; set; }

        public virtual ExTypes Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual Packages AllowedPackages { get; set; }

        public virtual Rooms AllowedRooms { get; set; }

        public virtual User Editor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Worker { get; set; }
    }
}
