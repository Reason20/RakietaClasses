namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CountMachinesSets
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Count { get; set; }

        public int ClubKey { get; set; }

        public int ResourcesKey { get; set; }

        public DateTime LastEditTime { get; set; }

        public int LastEditor { get; set; }

        public virtual ClubInfoSets ClubInfoSets { get; set; }

        public virtual Resources Resources { get; set; }

        public virtual UserSets Editor { get; set; }
    }
}
