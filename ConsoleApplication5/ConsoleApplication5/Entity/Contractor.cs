namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Contractor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contractor()
        {
            ContactCont = new HashSet<Contact>();
            ContractorFileTables = new HashSet<ContractorFileTables>();
            DealActions = new HashSet<DealActions>();
            Deals = new HashSet<Deal>();
            Tasks = new HashSet<Tasks>();
            Incomes = new HashSet<Incomes>();
            ContWorkers = new HashSet<User>();
            ContFactures = new HashSet<Facture>();
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

        public virtual Address MainAddressContractor { get; set; }

        public virtual Address SecondAddressContractor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contact> ContactCont { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContractorFileTables> ContractorFileTables { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DealActions> DealActions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deal> Deals { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tasks> Tasks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Incomes> Incomes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> ContWorkers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Facture> ContFactures { get; set; }

        public virtual User Editor { get; set; }
    }
}
