namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DeliverySets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DeliverySets()
        {
            FactureSets = new HashSet<FactureSets>();
            ListOfItemsSets = new HashSet<ListOfItemsSets>();
        }

        public int Id { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string DeliveryName { get; set; }

        [Required]
        public string DeliveryNumber { get; set; }

        public int ListOfItemsId { get; set; }

        public DateTime LastEditTime { get; set; }

        public int LastEditor { get; set; }

        public virtual ICollection<ListOfItemsSets> ListOfItemsSets { get; set; }

        public virtual WorkerSets WorkerSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactureSets> FactureSets { get; set; }
    }
}
