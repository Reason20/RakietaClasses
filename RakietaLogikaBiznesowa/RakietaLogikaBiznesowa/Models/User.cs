using System.Collections;
using Newtonsoft.Json.Converters;

namespace RakietaLogikaBiznesowa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {

            BoughtPackagesSets = new HashSet<BoughtPackages>();
            ContactSets = new HashSet<Contact>();
            DealActions = new HashSet<DealActions>();
            Deals = new HashSet<Deal>();
            ExReports = new HashSet<ExerciseReports>();
            FactureUpdate = new HashSet<Facture>();
            FactureCreate = new HashSet<Facture>();
            FactureSets2 = new HashSet<Facture>(); //todo
            FormAnswers = new HashSet<FormAnswers>();
            HelpDeskPartialHistory = new HashSet<HelpDeskPartialHistory>();
            HelpdeskSets = new HashSet<Helpdesk>();
            Incomes = new HashSet<Incomes>();
            UserFileTables = new HashSet<UserFileTables>();
            UserSets1 = new HashSet<User>();
            BankAccountSets = new HashSet<BankAccount>();
            MailerSmserSets = new HashSet<MailerSmser>();
            Roles = new HashSet<Role>();
            Permission = new HashSet<Permissions>();
            Loads = new HashSet<Loads>();

            //new

            Contract = new HashSet<Contract>();
            HelpDeskAnswer = new HashSet<HelpDeskPartialHistory>();
            Club = new HashSet<Club>();
            Exercise = new HashSet<Exercise>();

            //editors

            AddressEdit = new HashSet<Address>();
            AnnouncementsEdit = new HashSet<Announcement>();
            BankAccountEdit = new HashSet<BankAccount>();
            BoughtPackagesEdit = new HashSet<BoughtPackages>();
            ClubInfoEdit = new HashSet<Club>();
            ContactEdit = new HashSet<Contact>();
            ContractorEdit = new HashSet<Contractor>();
            ContractEdit = new HashSet<Contract>();
            CountMachinesEdit = new HashSet<CountMachines>();
            DealActionsEdit = new HashSet<DealActions>();
            DealEdit = new HashSet<Deal>();
            UserDealsMenager = new HashSet<Deal>();
            DeliveryEdit = new HashSet<Delivery>();
            DiscountEdit = new HashSet<Discount>();
            ExerciseEdit = new HashSet<Exercise>();
            ExReportsEdit = new HashSet<ExerciseReports>();
            ExTypesEdit = new HashSet<ExTypes>();
            FactureEdit = new HashSet<Facture>();
            FormDevicesEdit = new HashSet<FormDevices>();
            FormQuestionEdit = new HashSet<FormQuestions>();
            FormEdit = new HashSet<Forms>();
            HelpdeskEdit = new HashSet<Helpdesk>();
            IncomesEdit = new HashSet<Incomes>();
            ListOfItemsEdit = new HashSet<ListOfItems>();
            MainWarehouseEdit = new HashSet<MainWarehouse>();
            NewsEdit = new HashSet<News>();
            PackagesEdit = new HashSet<Packages>();
            PermissionEdit = new HashSet<Permissions>();
            RoleEdit = new HashSet<Role>();
            ResourcesEdit = new HashSet<Resources>();
            RoomsEdit = new HashSet<Rooms>();
            TagsEdit = new HashSet<Tags>();
            TaskEdit = new HashSet<Tasks>();
            TemplateEdit = new HashSet<Template>();
            UserEdit = new HashSet<User>();
            WarehouseEdit = new HashSet<Warehouse>();

            // create 

            DealActionsCreate = new HashSet<DealActions>();
            DealCommentsCreate = new HashSet<DealComment>();
            DealCreate = new HashSet<Deal>();
            DealMenagerCreate = new HashSet<Deal>();
            DeviceCreate = new HashSet<Devices>();
            MailerSmserSender = new HashSet<MailerSmser>();

            //Datetimes
            DateOfBirth = DateTime.Now;
            JoinDate = DateTime.Now;
            LastEditTime = DateTime.Now;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Login { get; set; }
        
        [Column(TypeName = "BINARY")]
        [MaxLength(256)]
        [Required]
        public byte[] Password { get; set; }

        [Required]
        public string Surname { get; set; }

        [Column(TypeName = "BINARY")]
        [MaxLength(256)]
        [Required]
        public byte[] PESEL { get; set; }

        public DateTime DateOfBirth { get; set; }

        public MaleFemale Sex { get; set; }

        [Required]
        public string PlaceOfBirth { get; set; }

        [Required]
        [Column(TypeName = "BINARY")]
        [MaxLength(256)]
        public byte[] IDNumber { get; set; }

        public string Notes { get; set; }

        public int MainAddress { get; set; }

        public int? SecondAddress { get; set; }

        public DateTime JoinDate { get; set; }

        public int? ReferId { get; set; }

        public int? ContractorId { get; set; }

        public DateTime LastEditTime { get; set; }

        public int? LastEditor { get; set; }

        public int MoneyboxId { get; set; }

        public Boolean IsWorker { get; set; }

        public int? ContractId { get; set; }

        public virtual Address MainAddressUser { get; set; }

        public virtual Address SecondAddressUser { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public virtual ICollection<Permissions> Permission { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoughtPackages> BoughtPackagesSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contact> ContactSets { get; set; }

        public virtual Contractor Contractor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DealActions> DealActions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deal> Deals { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExerciseReports> ExReports { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Facture> FactureUpdate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Facture> FactureCreate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Facture> FactureSets2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormAnswers> FormAnswers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Facture> OwnFactures { get; set; }
        

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HelpDeskPartialHistory> HelpDeskPartialHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Helpdesk> HelpdeskSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Incomes> Incomes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual Moneybox Moneybox { get; set; }

        //public virtual ICollection<Role> Role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserFileTables> UserFileTables { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> UserSets1 { get; set; }

        public virtual User UserSets2 { get; set; }

        public virtual User Editor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BankAccount> BankAccountSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MailerSmser> MailerSmserSets { get; set; }

        public virtual ICollection<Contract> Contract { get; set; }

        public virtual ICollection<Deal> UserDealsMenager { get; set; }

        public virtual ICollection<HelpDeskPartialHistory> HelpDeskAnswer { get; set; }

        public virtual ICollection<Club> Club { get; set; }

        public virtual ICollection<Exercise> Exercise { get; set; } 

        public virtual ICollection<Loads> Loads { get; set; }

        // editors

        public virtual ICollection<Address> AddressEdit { get; set; }

        public virtual ICollection<Announcement> AnnouncementsEdit { get; set; }

        public virtual ICollection<BankAccount> BankAccountEdit { get; set; }

        public virtual ICollection<BoughtPackages> BoughtPackagesEdit { get; set; }

        public virtual ICollection<Club> ClubInfoEdit { get; set; }

        public virtual ICollection<Contact> ContactEdit { get; set; }

        public virtual ICollection<Contractor> ContractorEdit { get; set; }

        public virtual ICollection<Contract> ContractEdit { get; set; }

        public virtual ICollection<CountMachines> CountMachinesEdit { get; set; }

        public virtual ICollection<DealActions> DealActionsEdit { get; set; }

        public virtual ICollection<Deal> DealEdit { get; set; }

        public virtual ICollection<Delivery> DeliveryEdit { get; set; }

        public virtual ICollection<Discount> DiscountEdit { get; set; }

        public virtual ICollection<Exercise> ExerciseEdit { get; set; }

        public virtual ICollection<ExerciseReports> ExReportsEdit { get; set; }

        public virtual ICollection<ExTypes> ExTypesEdit { get; set; }

        public virtual ICollection<Facture> FactureEdit { get; set; }

        public virtual ICollection<FormDevices> FormDevicesEdit { get; set; }

        public virtual ICollection<FormQuestions> FormQuestionEdit { get; set; }

        public virtual ICollection<Forms> FormEdit { get; set; }

        public virtual ICollection<Helpdesk> HelpdeskEdit { get; set; }

        public virtual ICollection<Incomes> IncomesEdit { get; set; }

        public virtual ICollection<ListOfItems> ListOfItemsEdit { get; set; }

        public virtual ICollection<MainWarehouse> MainWarehouseEdit { get; set; }

        public virtual ICollection<News> NewsEdit { get; set; }

        public virtual ICollection<Packages> PackagesEdit { get; set; }

        public virtual ICollection<Permissions> PermissionEdit { get; set; }

        public virtual ICollection<Role> RoleEdit { get; set; }

        public virtual ICollection<Resources> ResourcesEdit { get; set; }

        public virtual ICollection<Rooms> RoomsEdit { get; set; }

        public virtual ICollection<Tags> TagsEdit { get; set; }

        public virtual ICollection<Tasks> TaskEdit { get; set; }

        public virtual ICollection<Template> TemplateEdit { get; set; }

        public virtual ICollection<User> UserEdit { get; set; }

        public virtual ICollection<Warehouse> WarehouseEdit { get; set; }


        //create
        public virtual ICollection<DealActions> DealActionsCreate { get; set; }

        public virtual ICollection<DealComment> DealCommentsCreate { get; set; }

        public virtual ICollection<Deal> DealCreate { get; set; }

        public virtual ICollection<Deal> DealMenagerCreate { get; set; }

        public virtual ICollection<Devices> DeviceCreate { get; set; }

        public virtual ICollection<MailerSmser> MailerSmserSender { get; set; } 



    }

}
