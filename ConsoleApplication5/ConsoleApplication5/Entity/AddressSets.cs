namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AddressSets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AddressSets()
        {
            ContractorSets = new HashSet<ContractorSets>();
            ContractorSets1 = new HashSet<ContractorSets>();
            UserSets = new HashSet<UserSets>();
            ClubInfoSets = new HashSet<ClubInfoSets>();
            UserSets1 = new HashSet<UserSets>();
            BankAccountSets = new HashSet<BankAccountSets>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string HouseNumber { get; set; }

        public string ApartmentNumber { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string City { get; set; }

        public Provinces? Province { get; set; }

        public Countries Country { get; set; }

        public DateTime LastEditTime { get; set; }

        public int? LastEditor { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContractorSets> ContractorSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContractorSets> ContractorSets1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserSets> UserSets { get; set; }

        public virtual ICollection<ClubInfoSets> ClubInfoSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserSets> UserSets1 { get; set; }

        public virtual  UserSets Editor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BankAccountSets> BankAccountSets { get; set; }
    }
}
