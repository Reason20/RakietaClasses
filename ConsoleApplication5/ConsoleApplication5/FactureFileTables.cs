namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FactureFileTables
    {
        public int Id { get; set; }

        [Required]
        public string NameFile { get; set; }

        [Required]
        public byte[] DataFile { get; set; }

        [Required]
        public string FileExtencion { get; set; }

        public int Size { get; set; }

        public int FactureSet_Id { get; set; }

        public virtual FactureSets FactureSets { get; set; }
    }
}
