namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FormDevices
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastEditTime { get; set; }

        public int DeviceId { get; set; }

        public int FormId { get; set; }

        public int WorkerSetId { get; set; }

        public virtual Devices Device { get; set; }

        public virtual Forms Form { get; set; }

        public virtual WorkerSets WorkerSets { get; set; }
    }
}
