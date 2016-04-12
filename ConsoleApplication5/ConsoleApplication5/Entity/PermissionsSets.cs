namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PermissionsSets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PermissionsSets()
        {
            ApprovedRoles = new HashSet<RoleSets>();
            ApprovedUsers = new HashSet<UserSets>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Function { get; set; }

        public bool Write { get; set; }

        public bool Read { get; set; }

        public bool Update { get; set; }

        public bool Delete { get; set; }

        public DateTime LastEditTime { get; set; }

        public int LastEditor { get; set; }

        public virtual WorkerSets WorkerSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoleSets> ApprovedRoles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserSets> ApprovedUsers { get; set; }
    }
}
