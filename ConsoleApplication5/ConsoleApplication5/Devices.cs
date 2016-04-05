namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Devices
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Devices()
        {
            FormDevices = new HashSet<FormDevices>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int WorkerSetId { get; set; }

        public int ClubInfoSetId { get; set; }

        public virtual ClubInfoSets ClubInfoSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormDevices> FormDevices { get; set; }

        public virtual WorkerSets WorkerSets { get; set; }
    }
}
