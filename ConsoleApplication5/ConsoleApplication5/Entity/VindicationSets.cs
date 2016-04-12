namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VindicationSets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VindicationSets()
        {
            MailerSmserSets = new HashSet<MailerSmserSets>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public VindicationStatus Status { get; set; }

        public string Comments { get; set; }

        public int TemplateId { get; set; }

        public int? LastEditor { get; set; }

        public int LoadsId { get; set; }

        public virtual Loads Loads { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MailerSmserSets> MailerSmserSets { get; set; }

        public virtual TemplateSets TemplateSets { get; set; }

        public virtual UserSets Editor { get; set; }

    }
}
