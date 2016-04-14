namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HelpdeskFileTables
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string NameFile { get; set; }

        [Required]
        public byte[] DataFile { get; set; }

        [Required]
        public string FileExtencion { get; set; }

        public int Size { get; set; }

        public int? HelpdeskId { get; set; }

        public int? HelpDeskPartialHistoryId { get; set; }

        public virtual HelpDeskPartialHistory HelpDeskPartialHistory { get; set; }

        public virtual Helpdesk Helpdesk { get; set; }
    }
}
