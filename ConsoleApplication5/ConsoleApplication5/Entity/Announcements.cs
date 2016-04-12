namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Announcements
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string CreateTime { get; set; }

        [Required]
        public string Text { get; set; }

        public string Note { get; set; }

        public bool IsActive { get; set; }

        public DateTime LastEditTime { get; set; }

        public int TagId { get; set; }

        public int LastEditor { get; set; }

        public virtual UserSets Editor { get; set; }

        public virtual Tags Tag { get; set; }
    }
}
