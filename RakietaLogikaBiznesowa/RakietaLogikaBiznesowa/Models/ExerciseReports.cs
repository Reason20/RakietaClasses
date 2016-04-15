namespace RakietaLogikaBiznesowa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ExerciseReports
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public ExReportsStatus? Status { get; set; }

        public bool Paid { get; set; }

        public bool Reservation { get; set; }

        public bool Participated { get; set; }

        public bool Willingness { get; set; }

        public bool Canceled { get; set; }

        public int ExerciseId { get; set; }

        public int UserId { get; set; }

        public DateTime LastEditTime { get; set; }

        public int? LastEditor { get; set; }

        public virtual Exercise Exercise { get; set; }

        public virtual User User { get; set; }

        public virtual User Editor { get; set; }
    }
}
