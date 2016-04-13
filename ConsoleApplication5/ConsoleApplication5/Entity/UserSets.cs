using System.Collections;

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
            ExReports = new HashSet<ExReportsSets>();
            FactureUpdate = new HashSet<FactureSets>();
            FactureCreate = new HashSet<FactureSets>();
            FactureSets2 = new HashSet<FactureSets>(); //todo
            FormAnswers = new HashSet<FormAnswers>();
            HelpDeskPartialHistory = new HashSet<HelpDeskPartialHistorySets>();
            HelpdeskSets = new HashSet<HelpdeskSets>();
            Incomes = new HashSet<Incomes>();
            UserFileTables = new HashSet<UserFileTables>();
            UserSets1 = new HashSet<UserSets>();
            BankAccountSets = new HashSet<BankAccountSets>();
            MailerSmserSets = new HashSet<MailerSmserSets>();
            RoleSets = new HashSet<RoleSets>();
            Permission = new HashSet<PermissionsSets>();
            Loads = new HashSet<Loads>();

            //new

            Contract = new HashSet<ContractSets>();
            HelpDeskAnswer = new HashSet<HelpDeskPartialHistorySets>();
            Club = new HashSet<ClubInfoSets>();
            Exercise = new HashSet<ExerciseSets>();

            //editors

            AddressEdit = new HashSet<AddressSets>();
            AnnouncementsEdit = new HashSet<Announcements>();
            BankAccountEdit = new HashSet<BankAccountSets>();
            BoughtPackagesEdit = new HashSet<BoughtPackagesSets>();
            ClubInfoEdit = new HashSet<ClubInfoSets>();
            ContactEdit = new HashSet<ContactSets>();
            ContractorEdit = new HashSet<ContractorSets>();
            ContractEdit = new HashSet<ContractSets>();
            CountMachinesEdit = new HashSet<CountMachinesSets>();
            DealActionsEdit = new HashSet<DealActions>();
            DealEdit = new HashSet<Deals>();
            UserDealsMenager = new HashSet<Deals>();
            DeliveryEdit = new HashSet<DeliverySets>();
            DiscountEdit = new HashSet<DiscountSets>();
            ExerciseEdit = new HashSet<ExerciseSets>();
            ExReportsEdit = new HashSet<ExReportsSets>();
            ExTypesEdit = new HashSet<ExTypesSets>();
            FactureEdit = new HashSet<FactureSets>();
            FormDevicesEdit = new HashSet<FormDevices>();
            FormQuestionEdit = new HashSet<FormQuestions>();
            FormEdit = new HashSet<Forms>();
            HelpdeskEdit = new HashSet<HelpdeskSets>();
            IncomesEdit = new HashSet<Incomes>();
            ListOfItemsEdit = new HashSet<ListOfItemsSets>();
            MainWarehouseEdit = new HashSet<MainWarehouseSets>();
            NewsEdit = new HashSet<News>();
            PackagesEdit = new HashSet<PackagesSets>();
            PermissionEdit = new HashSet<PermissionsSets>();
            RoleEdit = new HashSet<RoleSets>();
            ResourcesEdit = new HashSet<Resources>();
            RoomsEdit = new HashSet<RoomsSets>();
            TagsEdit = new HashSet<Tags>();
            TaskEdit = new HashSet<Tasks>();
            TemplateEdit = new HashSet<TemplateSets>();
            UserEdit = new HashSet<UserSets>();
            WarehouseEdit = new HashSet<WarehouseSets>();

            // create 

            DealActionsCreate = new HashSet<DealActions>();
            DealCommentsCreate = new HashSet<DealComments>();
            DealCreate = new HashSet<Deals>();
            DealMenagerCreate = new HashSet<Deals>();
            DeviceCreate = new HashSet<Devices>();
            MailerSmserSender = new HashSet<MailerSmserSets>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public int? SecondAddress { get; set; }

        public DateTime JoinDate { get; set; }

        public int? ReferId { get; set; }

        public int? ContractorId { get; set; }

        public DateTime LastEditTime { get; set; }

        public int? LastEditor { get; set; }

        public int MoneyboxId { get; set; }

        public int? WorkerId { get; set; }

        public int? ContractId { get; set; }

        public virtual AddressSets MainAddressUser { get; set; }

        public virtual AddressSets SecondAddressUser { get; set; }

        public virtual ICollection<PermissionsSets> Permission { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoughtPackagesSets> BoughtPackagesSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContactSets> ContactSets { get; set; }

        public virtual ContractorSets Contractor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DealActions> DealActions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deals> Deals { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExReportsSets> ExReports { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactureSets> FactureUpdate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactureSets> FactureCreate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactureSets> FactureSets2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormAnswers> FormAnswers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HelpDeskPartialHistorySets> HelpDeskPartialHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HelpdeskSets> HelpdeskSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Incomes> Incomes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual MoneyboxSet Moneybox { get; set; }

        public virtual ICollection<RoleSets> RoleSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserFileTables> UserFileTables { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserSets> UserSets1 { get; set; }

        public virtual UserSets UserSets2 { get; set; }

        public virtual UserSets Editor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BankAccountSets> BankAccountSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MailerSmserSets> MailerSmserSets { get; set; }

        public virtual ICollection<ContractSets> Contract { get; set; }

        public virtual ICollection<Deals> UserDealsMenager { get; set; }

        public virtual ICollection<HelpDeskPartialHistorySets> HelpDeskAnswer { get; set; }

        public virtual ICollection<ClubInfoSets> Club { get; set; }

        public virtual ICollection<ExerciseSets> Exercise { get; set; } 

        public virtual ICollection<Loads> Loads { get; set; }
        
        // editors

        public virtual ICollection<AddressSets> AddressEdit { get; set; }

        public virtual ICollection<Announcements> AnnouncementsEdit { get; set; }

        public virtual ICollection<BankAccountSets> BankAccountEdit { get; set; }

        public virtual ICollection<BoughtPackagesSets> BoughtPackagesEdit { get; set; }

        public virtual ICollection<ClubInfoSets> ClubInfoEdit { get; set; }

        public virtual ICollection<ContactSets> ContactEdit { get; set; }

        public virtual ICollection<ContractorSets> ContractorEdit { get; set; }

        public virtual ICollection<ContractSets> ContractEdit { get; set; }

        public virtual ICollection<CountMachinesSets> CountMachinesEdit { get; set; }

        public virtual ICollection<DealActions> DealActionsEdit { get; set; }

        public virtual ICollection<Deals> DealEdit { get; set; }

        public virtual ICollection<DeliverySets> DeliveryEdit { get; set; }

        public virtual ICollection<DiscountSets> DiscountEdit { get; set; }

        public virtual ICollection<ExerciseSets> ExerciseEdit { get; set; }

        public virtual ICollection<ExReportsSets> ExReportsEdit { get; set; }

        public virtual ICollection<ExTypesSets> ExTypesEdit { get; set; }

        public virtual ICollection<FactureSets> FactureEdit { get; set; }

        public virtual ICollection<FormDevices> FormDevicesEdit { get; set; }

        public virtual ICollection<FormQuestions> FormQuestionEdit { get; set; }

        public virtual ICollection<Forms> FormEdit { get; set; }

        public virtual ICollection<HelpdeskSets> HelpdeskEdit { get; set; }

        public virtual ICollection<Incomes> IncomesEdit { get; set; }

        public virtual ICollection<ListOfItemsSets> ListOfItemsEdit { get; set; }

        public virtual ICollection<MainWarehouseSets> MainWarehouseEdit { get; set; }

        public virtual ICollection<News> NewsEdit { get; set; }

        public virtual ICollection<PackagesSets> PackagesEdit { get; set; }

        public virtual ICollection<PermissionsSets> PermissionEdit { get; set; }

        public virtual ICollection<RoleSets> RoleEdit { get; set; }

        public virtual ICollection<Resources> ResourcesEdit { get; set; }

        public virtual ICollection<RoomsSets> RoomsEdit { get; set; }

        public virtual ICollection<Tags> TagsEdit { get; set; }

        public virtual ICollection<Tasks> TaskEdit { get; set; }

        public virtual ICollection<TemplateSets> TemplateEdit { get; set; }

        public virtual ICollection<UserSets> UserEdit { get; set; }

        public virtual ICollection<WarehouseSets> WarehouseEdit { get; set; }


        //create
        public virtual ICollection<DealActions> DealActionsCreate { get; set; }

        public virtual ICollection<DealComments> DealCommentsCreate { get; set; }

        public virtual ICollection<Deals> DealCreate { get; set; }

        public virtual ICollection<Deals> DealMenagerCreate { get; set; }

        public virtual ICollection<Devices> DeviceCreate { get; set; }

        public virtual ICollection<MailerSmserSets> MailerSmserSender { get; set; } 



    }

}
