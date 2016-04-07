namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BankAccountSets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BankAccountSets()
        {
            //AddressSets = new HashSet<AddressSets>();
            UserSets = new HashSet<UserSets>();
        }

        public int Id { get; set; }

        [Required]
        public string BankAccountNumber { get; set; }

        public string CardNumber { get; set; }

        [Required]
        public string BankName { get; set; }

        public DateTime LastEditTime { get; set; }

        public int? AddressId { get; set; }

        public int LastEditor { get; set; }

        public virtual WorkerSets WorkerSets { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual AddressSets AddressSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserSets> UserSets { get; set; }
    }
}
