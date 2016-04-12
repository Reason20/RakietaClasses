namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ContractorSets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ContractorSets()
        {
            ContactSets = new HashSet<ContactSets>();
            ContractorFileTables = new HashSet<ContractorFileTables>();
            DealActions = new HashSet<DealActions>();
            Deals = new HashSet<Deals>();
            Tasks = new HashSet<Tasks>();
            Incomes = new HashSet<Incomes>();
            UserSets = new HashSet<UserSets>();
            FactureSets = new HashSet<FactureSets>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public long? Pesel { get; set; }

        public long NIP { get; set; }

        public long REGON { get; set; }

        [Required]
        public string Name { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Comments { get; set; }

        public int MainAddress { get; set; }

        public int? SecondAddress { get; set; }

        public DateTime LastEditTime { get; set; }

        public int? LastEditor { get; set; }

        public virtual AddressSets AddressSets { get; set; }

        public virtual AddressSets AddressSets1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContactSets> ContactSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContractorFileTables> ContractorFileTables { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DealActions> DealActions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deals> Deals { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tasks> Tasks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Incomes> Incomes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserSets> UserSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactureSets> FactureSets { get; set; }

        public virtual UserSets Editor { get; set; }
    }
}
