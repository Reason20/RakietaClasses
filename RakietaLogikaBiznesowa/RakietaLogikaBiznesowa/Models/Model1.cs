namespace RakietaLogikaBiznesowa.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Rakieta")
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<BankAccount> BankAccount { get; set; }
        public virtual DbSet<BoughtPackages> BoughtPackages { get; set; }
        public virtual DbSet<Club> Club { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<ContractorFileTables> ContractorFileTables { get; set; }
        public virtual DbSet<Contractor> Contractor { get; set; }
        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<CountMachines> CountMachines { get; set; }
        public virtual DbSet<DealActions> DealActions { get; set; }
        public virtual DbSet<DealComment> DealComments { get; set; }
        public virtual DbSet<DealFileTables> DealFileTables { get; set; }
        public virtual DbSet<Deal> Deal { get; set; }
        public virtual DbSet<Delivery> Delivery { get; set; }
        public virtual DbSet<Devices> Devices { get; set; }
        public virtual DbSet<Discount> Discount { get; set; }
        public virtual DbSet<Exercise> Exercise { get; set; }
        public virtual DbSet<ExerciseReports> ExReports { get; set; }
        public virtual DbSet<ExTypes> ExTypes { get; set; }
        public virtual DbSet<FactureFileTables> FactureFileTables { get; set; }
        public virtual DbSet<Facture> Facture { get; set; }
        public virtual DbSet<FormAnswers> FormAnswers { get; set; }
        public virtual DbSet<FormDevices> FormDevices { get; set; }
        public virtual DbSet<FormQuestions> FormQuestions { get; set; }
        public virtual DbSet<Forms> Forms { get; set; }
        public virtual DbSet<HelpdeskFileTables> HelpdeskFileTables { get; set; }
        public virtual DbSet<HelpDeskPartialHistory> HelpDeskPartialHistory { get; set; }
        public virtual DbSet<Helpdesk> HelpdeskSets { get; set; }
        public virtual DbSet<Incomes> Incomes { get; set; }
        public virtual DbSet<ListOfItems> ListOfItems { get; set; }
        public virtual DbSet<Loads> Loads { get; set; }
        public virtual DbSet<MailerSmser> MailerSmser { get; set; }
        public virtual DbSet<MainWarehouse> MainWarehouse { get; set; }
        public virtual DbSet<Moneybox> Moneybox { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Outcomes> Outcomes { get; set; }
        public virtual DbSet<Packages> Packages { get; set; }
        public virtual DbSet<Payoff> Payoff { get; set; }
        public virtual DbSet<Permissions> Permissions { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Resources> Resources { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<Template> Template { get; set; }
        public virtual DbSet<UserFileTables> UserFileTables { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Warehouse> Warehouse { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasMany(e => e.MainAddressContractor)
                .WithRequired(e => e.MainAddressContractor)
                .HasForeignKey(e => e.MainAddress)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.SecondAddressContractor)
                .WithOptional(e => e.SecondAddressContractor)
                .HasForeignKey(e => e.SecondAddress);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.MainAddressUser)
                .WithRequired(e => e.MainAddressUser)
                .HasForeignKey(e => e.MainAddress)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.ClubAddress)
                .WithRequired(e => e.ClubAddress)
                .HasForeignKey(e => e.AddressId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.SecondAddressUser)
                .WithOptional(e => e.SecondAddressUser)
                .HasForeignKey(e => e.SecondAddress);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.BankAddress)
                .WithOptional(e => e.BankAddress)
                .HasForeignKey(e => e.AddressId);

            modelBuilder.Entity<BankAccount>()
                .HasMany(e => e.AccountUsers)
                .WithMany(e => e.BankAccountSets)
                .Map(m => m.ToTable("AccountUsers"));

            modelBuilder.Entity<Club>()
                .HasMany(e => e.ClubContact)
                .WithOptional(e => e.ClubContact)
                .HasForeignKey(e => e.ClubId);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.Machines)
                .WithRequired(e => e.Club)
                .HasForeignKey(e => e.ClubKey)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.Devices)
                .WithRequired(e => e.Club)
                .HasForeignKey(e => e.ClubId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.ClubFactures)
                .WithOptional(e => e.Club)
                .HasForeignKey(e => e.ClubId);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.ClubWarehouse)
                .WithRequired(e => e.Club)
                .HasForeignKey(e => e.ClubId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.ClubRooms)
                .WithRequired(e => e.Club)
                .HasForeignKey(e => e.ClubId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.Worker)
                .WithMany(e => e.Club)
                .Map(m => m.ToTable("WorkersClubs").MapLeftKey("ClubId").MapRightKey("WorkerId"));

            modelBuilder.Entity<Contractor>()
                .HasMany(e => e.ContactCont)
                .WithOptional(e => e.ContactCont)
                .HasForeignKey(e => e.ContractorId);

            modelBuilder.Entity<Contractor>()
                .HasMany(e => e.ContractorFileTables)
                .WithRequired(e => e.Contractor)
                .HasForeignKey(e => e.ContractorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contractor>()
                .HasMany(e => e.DealActions)
                .WithOptional(e => e.Contractor)
                .HasForeignKey(e => e.ContractorId);

            modelBuilder.Entity<Contractor>()
                .HasMany(e => e.Deals)
                .WithOptional(e => e.Contractor)
                .HasForeignKey(e => e.ContractorId);

            modelBuilder.Entity<Contractor>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.Contractor)
                .HasForeignKey(e => e.ContractorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contractor>()
                .HasMany(e => e.Incomes)
                .WithOptional(e => e.ContractorPayer)
                .HasForeignKey(e => e.ContractorId);

            modelBuilder.Entity<Contractor>()
                .HasMany(e => e.ContWorkers)
                .WithOptional(e => e.Contractor)
                .HasForeignKey(e => e.ContractorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contractor>()
                .HasMany(e => e.ContFactures)
                .WithOptional(e => e.Contractor)
                .HasForeignKey(e => e.ContractorId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Contract)
                .WithRequired(e => e.Worker)
                .HasForeignKey(e => e.WorkerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Deal>()
                .HasMany(e => e.DealActions)
                .WithRequired(e => e.Deal)
                .HasForeignKey(e => e.DealId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Deal>()
                .HasMany(e => e.DealComments)
                .WithRequired(e => e.Deal)
                .HasForeignKey(e => e.DealId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Deal>()
                .HasMany(e => e.DealFileTables)
                .WithRequired(e => e.DealsTable)
                .HasForeignKey(e => e.DealId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Deal>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.Deal)
                .HasForeignKey(e => e.DealId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Delivery>()
                .HasMany(e => e.DeliveryFactures)
                .WithMany(e => e.Deliveries)
                .Map(m => m.ToTable("DeliveryFactures"));

            modelBuilder.Entity<Devices>()
                .HasMany(e => e.FormDevices)
                .WithRequired(e => e.Device)
                .HasForeignKey(e => e.DeviceId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Discount>()
                .HasMany(e => e.DiscountedPackages)
                .WithMany(e => e.PackageDiscounts)
                .Map(m => m.ToTable("PackagesDiscounts"));

            modelBuilder.Entity<Exercise>()
                .HasMany(e => e.Reports)
                .WithRequired(e => e.Exercise)
                .HasForeignKey(e => e.ExerciseId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Exercise>()
                .HasMany(e => e.Worker)
                .WithMany(e => e.Exercise)
                .Map(m => m.ToTable("ExerciseLeaders").MapLeftKey("ExerciseId").MapRightKey("WorkerId"));

            modelBuilder.Entity<ExTypes>()
                .HasMany(e => e.Exercises)
                .WithRequired(e => e.Type)
                .HasForeignKey(e => e.ExTypesKey)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ExTypes>()
                .HasMany(e => e.Rooms)
                .WithMany(e => e.AvailableExTypes)
                .Map(m => m.ToTable("RoomsExTypes"));

            modelBuilder.Entity<Facture>()
                .HasMany(e => e.BoughtPackage)
                .WithRequired(e => e.PackageFacture)
                .HasForeignKey(e => e.FactureId);

            modelBuilder.Entity<Facture>()
                .HasMany(e => e.FactureFileTables)
                .WithRequired(e => e.Facture)
                .HasForeignKey(e => e.FactureId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Facture>()
                .HasMany(e => e.BoughtItems)
                .WithMany(e => e.ItemFactures)
                .Map(m => m.ToTable("ItemsOnFacture"));


            modelBuilder.Entity<Facture>()
                .HasMany(e => e.Incomes)
                .WithRequired(e => e.IncomeFacture)
                .HasForeignKey(e => e.FactureId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Facture>()
                .HasMany(e => e.Outcomes)
                .WithRequired(e => e.OutcomeFacture)
                .HasForeignKey(e => e.FactureId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Facture>()
                .HasMany(e => e.Warehouse)
                .WithMany(e => e.WarehouseFactures)
                .Map(m => m.ToTable("WarehouseFactures"));


            modelBuilder.Entity<Facture>()
                .HasMany(e => e.Loads)
                .WithRequired(e => e.Facture)
                .HasForeignKey(e => e.FactureId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FormQuestions>()
                .HasMany(e => e.QuestionAnswers)
                .WithRequired(e => e.FormQuestions)
                .HasForeignKey(e => e.FormQuestionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Forms>()
                .HasMany(e => e.Answers)
                .WithRequired(e => e.Forms)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Forms>()
                .HasMany(e => e.Devices)
                .WithRequired(e => e.Form)
                .HasForeignKey(e => e.FormId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Forms>()
                .HasMany(e => e.Questions)
                .WithRequired(e => e.Forms)
                .HasForeignKey(e => e.FormId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HelpDeskPartialHistory>()
                .HasMany(e => e.HelpdeskFileTables)
                .WithOptional(e => e.HelpDeskPartialHistory)
                .HasForeignKey(e => e.HelpDeskPartialHistoryId);

            modelBuilder.Entity<Helpdesk>()
                .HasMany(e => e.HelpdeskFileTables)
                .WithOptional(e => e.Helpdesk)
                .HasForeignKey(e => e.HelpdeskId);

            modelBuilder.Entity<Helpdesk>()
                .HasMany(e => e.AnswerHistory)
                .WithRequired(e => e.HelpdeskApplication)
                .HasForeignKey(e => e.HelpdeskId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ListOfItems>()
                .HasMany(e => e.Deliveries)
                .WithMany(e => e.DeliveryItems)
                .Map(m => m.ToTable("DeliveriedItems"));

            modelBuilder.Entity<Loads>()
                .HasMany(e => e.Payoffs)
                .WithRequired(e => e.Installment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MailerSmser>()
                .HasMany(e => e.Recipient)
                .WithMany(e => e.MailerSmserSets)
                .Map(m => m.ToTable("MailSmsRecipients"));

            modelBuilder.Entity<MainWarehouse>()
                .HasMany(e => e.Warehouses)
                .WithRequired(e => e.MainWarehouse)
                .HasForeignKey(e => e.MainWarehoseId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Moneybox>()
                .HasMany(e => e.Incomes)
                .WithOptional(e => e.Moneybox)
                .HasForeignKey(e => e.MoneyboxId);

            modelBuilder.Entity<Moneybox>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Moneybox)
                .HasForeignKey(e => e.MoneyboxId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Moneybox>()
                .HasMany(e => e.Payoffs)
                .WithOptional(e => e.Moneybox)
                .HasForeignKey(e => e.MoneyboxId);

            modelBuilder.Entity<Packages>()
                .HasMany(e => e.BoughtPackage)
                .WithRequired(e => e.BoughtPackage)
                .HasForeignKey(e => e.PackagesId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Packages>()
                .HasMany(e => e.Exercises)
                .WithRequired(e => e.AllowedPackages)
                .HasForeignKey(e => e.PackagesId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Permissions>()
                .HasMany(e => e.ApprovedRoles)
                .WithMany(e => e.RolePermissions)
                .Map(m => m.ToTable("RolePermissions"));

            //modelBuilder.Entity<Role>()
            //    .HasMany(e => e.Users)
            //    .WithMany(e => e.Role)
            //    .Map(m => m.ToTable("UsersRoles"));

            modelBuilder.Entity<User>()
                .HasMany(e => e.Roles)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.UserRole)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.RoleId);

                //            modelBuilder.Entity<Address>()
                //.HasMany(e => e.MainAddressContractor)
                //.WithRequired(e => e.MainAddressContractor)
                //.HasForeignKey(e => e.MainAddress)
                //.WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Permission)
                .WithMany(e => e.ApprovedUsers)
                .Map(m => m.ToTable("UsersPermissions"));

            modelBuilder.Entity<Resources>()
                .HasMany(e => e.Machines)
                .WithRequired(e => e.Resources)
                .HasForeignKey(e => e.ResourcesKey)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rooms>()
                .HasMany(e => e.BookedExercises)
                .WithRequired(e => e.AllowedRooms)
                .HasForeignKey(e => e.RoomsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tags>()
                .HasMany(e => e.Announcements)
                .WithRequired(e => e.Tag)
                .HasForeignKey(e => e.TagId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tags>()
                .HasMany(e => e.Forms)
                .WithRequired(e => e.Tag)
                .HasForeignKey(e => e.TagId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tags>()
                .HasMany(e => e.News)
                .WithRequired(e => e.Tag)
                .HasForeignKey(e => e.TagId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Template>()
                .HasMany(e => e.Installments)
                .WithOptional(e => e.Template)
                .HasForeignKey(e => e.TemplateId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.BoughtPackagesSets)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ContactSets)
                .WithOptional(e => e.ContactUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.DealActions)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Deals)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ExReports)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FactureUpdate)
                .WithRequired(e => e.UserUpdate)
                .HasForeignKey(e => e.UpdateUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FactureCreate)
                .WithRequired(e => e.UserCreate)
                .HasForeignKey(e => e.CreatorId)
                .WillCascadeOnDelete(false);
            
            modelBuilder.Entity<User>()
                .HasMany(e => e.FactureSets2)
                .WithOptional(e => e.UserSets2)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FormAnswers)
                .WithRequired(e => e.Respondent)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.HelpDeskPartialHistory)
                .WithOptional(e => e.Recipient)
                .HasForeignKey(e => e.RecipientId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.HelpdeskSets)
                .WithRequired(e => e.Recipient)
                .HasForeignKey(e => e.RecipientId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Incomes)
                .WithOptional(e => e.UserPayer)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserFileTables)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserSets1)
                .WithOptional(e => e.UserSets2)
                .HasForeignKey(e => e.ReferId);


            //Start edit

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserRoleEdit)
                .WithOptional(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Loads>()
                .HasMany(e => e.MailSms)
                .WithOptional(e =>  e.Installment)
                .HasForeignKey(e => e.LoadsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Loads)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.AddressEdit)
                .WithOptional(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.AnnouncementsEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.BankAccountEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.BoughtPackagesEdit)
                .WithOptional(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ClubInfoEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ContactEdit)
                .WithOptional(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ContractorEdit)
                .WithOptional(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ContractEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<User>()
            //    .HasMany(e => e.ContractEdit)
            //    .WithOptional(e => e.Editor)
            //    .HasForeignKey(e => e.LastEditor)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.CountMachinesEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.DealActionsCreate)
                .WithRequired(e => e.Creator)
                .HasForeignKey(e => e.CreatorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.DealActionsEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.DealCommentsCreate)
                .WithRequired(e => e.Creator)
                .HasForeignKey(e => e.CreatorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.DealCreate)
                .WithRequired(e => e.DealCreator)
                .HasForeignKey(e => e.CreatorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.DealMenagerCreate)
                .WithRequired(e => e.DealMenager)
                .HasForeignKey(e => e.MenagerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.DealEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.DeliveryEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.DeviceCreate)
                .WithRequired(e => e.Creator)
                .HasForeignKey(e => e.CreatorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.DiscountEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ExerciseEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ExReportsEdit)
                .WithOptional(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ExTypesEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FactureEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FormDevicesEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FormQuestionEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FormEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.HelpDeskAnswer)
                .WithOptional(e => e.Worker)
                .HasForeignKey(e => e.WorkerId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.HelpdeskEdit)
                .WithOptional(e => e.Worker)
                .HasForeignKey(e => e.WorkerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.IncomesEdit)
                .WithOptional(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ListOfItemsEdit)
                .WithOptional(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.MailerSmserSender)
                .WithRequired(e => e.Sender)
                .HasForeignKey(e => e.EditorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.MainWarehouseEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.NewsEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.WorkerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PackagesEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.RoleEdit)
                .WithOptional(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ResourcesEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.RoomsEdit)
                .WithOptional(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TagsEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.WorkerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TaskEdit)
                .WithRequired(e => e.Worker)
                .HasForeignKey(e => e.WorkerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TemplateEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserEdit)
                .WithOptional(e => e.Editor)
                .HasForeignKey(e => e.LastEditor);

            modelBuilder.Entity<User>()
                .HasMany(e => e.WarehouseEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

        }

        public System.Data.Entity.DbSet<RakietaLogikaBiznesowa.Models.UserAndRole> UserAndRoles { get; set; }
    }
}
