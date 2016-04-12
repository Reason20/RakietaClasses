namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RoomsSets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RoomsSets()
        {
            ExerciseSets = new HashSet<ExerciseSets>();
            ExTypesSets = new HashSet<ExTypesSets>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public short MaxPeople { get; set; }

        public int ClubId { get; set; }

        public TypeOfRoom TypeOf { get; set; }

        public DateTime LastEditTime { get; set; }

        public int? LastEditor { get; set; }

        public virtual ClubInfoSets ClubInfoSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExerciseSets> ExerciseSets { get; set; }

        public virtual UserSets Editor { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExTypesSets> ExTypesSets { get; set; }
    }
}
