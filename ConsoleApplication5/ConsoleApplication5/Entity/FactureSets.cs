namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FactureSets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FactureSets()
        {
            BoughtPackagesSets = new HashSet<BoughtPackagesSets>();
            FactureFileTables = new HashSet<FactureFileTables>();
            ListOfItemsSets = new HashSet<ListOfItemsSets>();
            Incomes = new HashSet<Incomes>();
            Outcomes = new HashSet<Outcomes>();
            WarehouseSets = new HashSet<WarehouseSets>();
            Loads = new HashSet<Loads>();
            DeliverySets = new HashSet<DeliverySets>();
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

        public int CrUserId { get; set; }

        public int UpUserId { get; set; }

        public DateTime LastEditTime { get; set; }

        public int LastEditor { get; set; }

        public int InstallmentCount { get; set; }

        public int Value { get; set; }

        public bool IsPaid { get; set; }

        public int? UserId { get; set; }

        public int? ClubId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoughtPackagesSets> BoughtPackagesSets { get; set; }

        public virtual ClubInfoSets ClubInfoSets { get; set; }

        public virtual ContractorSets ContractorSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactureFileTables> FactureFileTables { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListOfItemsSets> ListOfItemsSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Incomes> Incomes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Outcomes> Outcomes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WarehouseSets> WarehouseSets { get; set; }

        public virtual UserSets UserSets { get; set; }

        public virtual UserSets UserSets1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Loads> Loads { get; set; }

        public virtual UserSets UserSets2 { get; set; }

        public virtual WorkerSets WorkerSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliverySets> DeliverySets { get; set; }
    }
}
