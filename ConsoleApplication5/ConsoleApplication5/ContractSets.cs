namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ContractSets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ContractSets()
        {
            WorkerSets1 = new HashSet<WorkerSets>();
        }

        public int Id { get; set; }

        public DateTime AgreementDate { get; set; }

        public DateTime From { get; set; }

        public DateTime? To { get; set; }

        public bool IsValid { get; set; }

        public double Salary { get; set; }

        public short Payday { get; set; }

        public short WorkingHours { get; set; }

        public TypesOfContract Type { get; set; }

        public int WorkerId { get; set; }

        public DateTime LastEditTime { get; set; }

        public int LastEditor { get; set; }

        public virtual WorkerSets WorkerSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkerSets> WorkerSets1 { get; set; }

        public virtual WorkerSets WorkerSets2 { get; set; }
    }
}
