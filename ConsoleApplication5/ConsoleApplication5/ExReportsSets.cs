namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ExReportsSets
    {
        public int Id { get; set; }

        public ExReportsStatus? Status { get; set; }

        public bool Paid { get; set; }

        public bool Cancel { get; set; }

        public int ExerciseId { get; set; }

        public int UserId { get; set; }

        public DateTime LastEditTime { get; set; }

        public int LastEditor { get; set; }

        public virtual ExerciseSets ExerciseSets { get; set; }

        public virtual UserSets UserSets { get; set; }

        public virtual WorkerSets WorkerSets { get; set; }
    }
}
