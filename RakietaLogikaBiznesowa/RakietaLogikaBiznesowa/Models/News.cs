namespace RakietaLogikaBiznesowa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime NewsStartTime { get; set; }

        public DateTime NewsExpiresTime { get; set; }

        [Required]
        public string Text { get; set; }

        public string Note { get; set; }

        public bool IsActive { get; set; }

        public DateTime LastEditTime { get; set; }

        public int TagId { get; set; }

        public int WorkerId { get; set; }

        public virtual Tags Tag { get; set; }

        public virtual User Editor { get; set; }
    }
}
