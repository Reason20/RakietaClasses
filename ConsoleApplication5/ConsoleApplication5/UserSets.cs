namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserSets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserSets()
        {
            BoughtPackagesSets = new HashSet<BoughtPackagesSets>();
            ContactSets = new HashSet<ContactSets>();
            DealActions = new HashSet<DealActions>();
            Deals = new HashSet<Deals>();
            ExReportsSets = new HashSet<ExReportsSets>();
            FactureSets = new HashSet<FactureSets>();
            FactureSets1 = new HashSet<FactureSets>();
            FactureSets2 = new HashSet<FactureSets>();
            FormAnswers = new HashSet<FormAnswers>();
            HelpDeskPartialHistorySets = new HashSet<HelpDeskPartialHistorySets>();
            HelpdeskSets = new HashSet<HelpdeskSets>();
            Incomes = new HashSet<Incomes>();
            ListOfUserSets = new HashSet<ListOfUserSets>();
            UserFileTables = new HashSet<UserFileTables>();
            UserSets1 = new HashSet<UserSets>();
            BankAccountSets = new HashSet<BankAccountSets>();
            MailerSmserSets = new HashSet<MailerSmserSets>();
        }

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Surname { get; set; }

        public long PESEL { get; set; }

        public DateTime DateOfBirth { get; set; }

        public MaleFemale Sex { get; set; }

        [Required]
        public string PlaceOfBirth { get; set; }

        [Required]
        public string IDNumber { get; set; }

        public string Notes { get; set; }

        public int MainAddress { get; set; }

        public int PositionId { get; set; }

        public int? SecondAddress { get; set; }

        public DateTime JoinDate { get; set; }

        public int ReferId { get; set; }

        public int ContractorId { get; set; }

        public DateTime LastEditTime { get; set; }

        public int? LastEditor { get; set; }

        public int MoneyboxId { get; set; }

        public int? WorkerId { get; set; }

        public virtual AddressSets AddressSets { get; set; }

        public virtual AddressSets AddressSets1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoughtPackagesSets> BoughtPackagesSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContactSets> ContactSets { get; set; }

        public virtual ContractorSets ContractorSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DealActions> DealActions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deals> Deals { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExReportsSets> ExReportsSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactureSets> FactureSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactureSets> FactureSets1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactureSets> FactureSets2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormAnswers> FormAnswers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HelpDeskPartialHistorySets> HelpDeskPartialHistorySets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HelpdeskSets> HelpdeskSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Incomes> Incomes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListOfUserSets> ListOfUserSets { get; set; }

        public virtual MoneyboxSet MoneyboxSet { get; set; }

        public virtual PositionSets PositionSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserFileTables> UserFileTables { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserSets> UserSets1 { get; set; }

        public virtual UserSets UserSets2 { get; set; }

        public virtual WorkerSets WorkerSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual WorkerSets WorkerSets1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BankAccountSets> BankAccountSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MailerSmserSets> MailerSmserSets { get; set; }
    }
}
