namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HelpdeskFileTables
    {
        public int Id { get; set; }

        [Required]
        public string NameFile { get; set; }

        [Required]
        public byte[] DataFile { get; set; }

        [Required]
        public string FileExtencion { get; set; }

        public int Size { get; set; }

        public int? HelpdeskId { get; set; }

        public int? HelpDeskPartialHistorySets_Id { get; set; }

        public virtual HelpDeskPartialHistorySets HelpDeskPartialHistorySets { get; set; }

        public virtual HelpdeskSets HelpdeskSets { get; set; }
    }
}
