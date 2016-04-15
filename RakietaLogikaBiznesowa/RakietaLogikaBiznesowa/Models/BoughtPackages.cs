namespace RakietaLogikaBiznesowa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BoughtPackages
    {
        public BoughtPackages()
        {
            LastEditTime = DateTime.Now;
            From = DateTime.Now;
            To = DateTime.Now;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public int PackagesId { get; set; }

        public int UserId { get; set; }

        public DateTime LastEditTime { get; set; }

        public int? LastEditor { get; set; }

        public int FactureId { get; set; }

        public virtual Packages BoughtPackage { get; set; }

        public virtual Facture PackageFacture { get; set; }

        public virtual User User { get; set; }

        public virtual User Editor { get; set; }
    }
}
