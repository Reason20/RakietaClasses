namespace RakietaLogikaBiznesowa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ListOfItems
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ListOfItems()
        {
            Deliveries = new HashSet<Delivery>();
            ItemFactures = new HashSet<Facture>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Count { get; set; }

        [Required]
        public string Metric { get; set; }

        public double Price { get; set; }

        public double PrecentTax { get; set; }

        public double Tax { get; set; }

        public double Netto { get; set; }

        public DateTime LastEditTime { get; set; }

        public int? LastEditor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Delivery> Deliveries { get; set; }

        public virtual ICollection<Facture> ItemFactures { get; set; }

        public virtual User Editor { get; set; }
    }
}
