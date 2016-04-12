namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WarehouseSets
    {
        public WarehouseSets()
        {
            WarehouseFactures = new HashSet<FactureSets>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public short Count { get; set; }

        public int RetailPrice { get; set; }

        public int WholesalePrice { get; set; }

        public double Tax { get; set; }

        public int ClubId { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int MainWarehoseId { get; set; }

        public DateTime LastEditTime { get; set; }

        public int LastEditor { get; set; }

        public int? FactureId { get; set; }

        public virtual ClubInfoSets ClubInfoSets { get; set; }

        public virtual ICollection<FactureSets> WarehouseFactures { get; set; }

        public virtual MainWarehouseSets MainWarehouse { get; set; }

        public virtual WorkerSets WorkerSets { get; set; }
    }
}
