namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ContactSets
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Skype { get; set; }

        public string PhoneNumber { get; set; }

        public string MobileNumber { get; set; }

        public string FaxNumber { get; set; }

        public string Email { get; set; }

        public int? ContractorId { get; set; }

        public int? UserId { get; set; }

        public int? ClubId { get; set; }

        public DateTime LastEditTime { get; set; }

        public int? LastEditor { get; set; }

        public virtual ClubInfoSets ClubContact { get; set; }

        public virtual ContractorSets ContactCont { get; set; }

        public virtual UserSets ContactUser { get; set; }

        public virtual UserSets Editor { get; set; }
    }
}
