namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ListOfUserSets
    {
        public int Id { get; set; }

        public bool Reservation { get; set; }

        public bool Participant { get; set; }

        public int UserId { get; set; }

        public int ExerciseId { get; set; }

        public bool Willingness { get; set; }

        public virtual ExerciseSets ExerciseSets { get; set; }

        public virtual UserSets UserSets { get; set; }
    }
}
