namespace RakietaLogikaBiznesowa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Facture
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Facture()
        {
            BoughtPackage = new HashSet<BoughtPackages>();
            FactureFileTables = new HashSet<FactureFileTables>();
            BoughtItems = new HashSet<ListOfItems>();
            Incomes = new HashSet<Incomes>();
            Outcomes = new HashSet<Outcomes>();
            Warehouse = new HashSet<Warehouse>();
            Loads = new HashSet<Loads>();
            Deliveries = new HashSet<Delivery>();



            LastEditTime = DateTime.Now;
            OpDate = DateTime.Now;
            CrDate = DateTime.Now;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime OpDate { get; set; }

        [Required]
        public string FactureNumber { get; set; }

        [Required]
        public string NumberSeries { get; set; }

        public DateTime CrDate { get; set; }

        public FactureCategory Category { get; set; }

        public int? ContractorId { get; set; }

        public int CreatorId { get; set; }

        public DateTime LastEditTime { get; set; }

        public int LastEditor { get; set; }

        public int InstallmentCount { get; set; }

        public double Value { get; set; }

        public bool IsPaid { get; set; }

        public int? ClubId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoughtPackages> BoughtPackage { get; set; }

        public virtual Club Club { get; set; }

        public virtual Contractor Contractor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactureFileTables> FactureFileTables { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListOfItems> BoughtItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Incomes> Incomes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Outcomes> Outcomes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Warehouse> Warehouse { get; set; }

        public virtual User UserCreate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Loads> Loads { get; set; }

        public virtual User Editor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
