namespace ConsoleApplication5
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

        public virtual DbSet<AddressSets> AddressSets { get; set; }
        public virtual DbSet<Announcements> Announcements { get; set; }
        public virtual DbSet<BankAccountSets> BankAccountSets { get; set; }
        public virtual DbSet<BoughtPackagesSets> BoughtPackagesSets { get; set; }
        public virtual DbSet<ClubInfoSets> ClubInfoSets { get; set; }
        public virtual DbSet<ContactSets> ContactSets { get; set; }
        public virtual DbSet<ContractorFileTables> ContractorFileTables { get; set; }
        public virtual DbSet<ContractorSets> ContractorSets { get; set; }
        public virtual DbSet<ContractSets> ContractSets { get; set; }
        public virtual DbSet<CountMachinesSets> CountMachinesSets { get; set; }
        public virtual DbSet<DealActions> DealActions { get; set; }
        public virtual DbSet<DealComments> DealComments { get; set; }
        public virtual DbSet<DealFileTables> DealFileTables { get; set; }
        public virtual DbSet<Deals> Deals { get; set; }
        public virtual DbSet<DeliverySets> DeliverySets { get; set; }
        public virtual DbSet<Devices> Devices { get; set; }
        public virtual DbSet<DiscountSets> DiscountSets { get; set; }
        public virtual DbSet<ExerciseSets> ExerciseSets { get; set; }
        public virtual DbSet<ExReportsSets> ExReportsSets { get; set; }
        public virtual DbSet<ExTypesSets> ExTypesSets { get; set; }
        public virtual DbSet<FactureFileTables> FactureFileTables { get; set; }
        public virtual DbSet<FactureSets> FactureSets { get; set; }
        public virtual DbSet<FormAnswers> FormAnswers { get; set; }
        public virtual DbSet<FormDevices> FormDevices { get; set; }
        public virtual DbSet<FormQuestions> FormQuestions { get; set; }
        public virtual DbSet<Forms> Forms { get; set; }
        public virtual DbSet<HelpdeskFileTables> HelpdeskFileTables { get; set; }
        public virtual DbSet<HelpDeskPartialHistorySets> HelpDeskPartialHistorySets { get; set; }
        public virtual DbSet<HelpdeskSets> HelpdeskSets { get; set; }
        public virtual DbSet<Incomes> Incomes { get; set; }
        public virtual DbSet<ListOfItemsSets> ListOfItemsSets { get; set; }
        public virtual DbSet<Loads> Loads { get; set; }
        public virtual DbSet<MailerSmserSets> MailerSmserSets { get; set; }
        public virtual DbSet<MainWarehouseSets> MainWarehouseSets { get; set; }
        public virtual DbSet<MoneyboxSet> MoneyboxSet { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Outcomes> Outcomes { get; set; }
        public virtual DbSet<PackagesSets> PackagesSets { get; set; }
        public virtual DbSet<PayoffSet> PayoffSet { get; set; }
        public virtual DbSet<PermissionsSets> PermissionsSets { get; set; }
        public virtual DbSet<RoleSets> RoleSets { get; set; }
        public virtual DbSet<Resources> Resources { get; set; }
        public virtual DbSet<RoomsSets> RoomsSets { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<TemplateSets> TemplateSets { get; set; }
        public virtual DbSet<UserFileTables> UserFileTables { get; set; }
        public virtual DbSet<UserSets> UserSets { get; set; }
        public virtual DbSet<WarehouseSets> WarehouseSets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressSets>()
                .HasMany(e => e.MainAddressCont)
                .WithRequired(e => e.MainAddressCont)
                .HasForeignKey(e => e.MainAddress)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AddressSets>()
                .HasMany(e => e.SecondAddressCont)
                .WithOptional(e => e.SecondAddressCont)
                .HasForeignKey(e => e.SecondAddress);

            modelBuilder.Entity<AddressSets>()
                .HasMany(e => e.MainAddressUser)
                .WithRequired(e => e.MainAddressUser)
                .HasForeignKey(e => e.MainAddress)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AddressSets>()
                .HasMany(e => e.ClubAddress)
                .WithRequired(e => e.ClubAddress)
                .HasForeignKey(e => e.AddressId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AddressSets>()
                .HasMany(e => e.SecondAddressUser)
                .WithOptional(e => e.SecondAddressUser)
                .HasForeignKey(e => e.SecondAddress);

            modelBuilder.Entity<AddressSets>()
                .HasMany(e => e.BankAddress)
                .WithOptional(e => e.BankAddress)
                .HasForeignKey(e => e.AddressId);

            modelBuilder.Entity<BankAccountSets>()
                .HasMany(e => e.AccountUsers)
                .WithMany(e => e.BankAccountSets)
                .Map(m => m.ToTable("AccountUsers"));

            modelBuilder.Entity<ClubInfoSets>()
                .HasMany(e => e.ClubContact)
                .WithOptional(e => e.ClubContact)
                .HasForeignKey(e => e.ClubId);

            modelBuilder.Entity<ClubInfoSets>()
                .HasMany(e => e.Machines)
                .WithRequired(e => e.Club)
                .HasForeignKey(e => e.ClubKey)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClubInfoSets>()
                .HasMany(e => e.Devices)
                .WithRequired(e => e.Club)
                .HasForeignKey(e => e.ClubId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClubInfoSets>()
                .HasMany(e => e.ClubFactures)
                .WithOptional(e => e.Club)
                .HasForeignKey(e => e.ClubId);

            modelBuilder.Entity<ClubInfoSets>()
                .HasMany(e => e.ClubWarehouse)
                .WithRequired(e => e.Club)
                .HasForeignKey(e => e.ClubId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClubInfoSets>()
                .HasMany(e => e.ClubRooms)
                .WithRequired(e => e.Club)
                .HasForeignKey(e => e.ClubId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClubInfoSets>()
                .HasMany(e => e.Worker)
                .WithMany(e => e.Club)
                .Map(m => m.ToTable("WorkersClubs").MapLeftKey("ClubId").MapRightKey("WorkerId"));

            modelBuilder.Entity<ContractorSets>()
                .HasMany(e => e.ContactCont)
                .WithOptional(e => e.ContactCont)
                .HasForeignKey(e => e.ContractorId);

            modelBuilder.Entity<ContractorSets>()
                .HasMany(e => e.ContractorFileTables)
                .WithRequired(e => e.Contractor)
                .HasForeignKey(e => e.ContractorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContractorSets>()
                .HasMany(e => e.DealActions)
                .WithOptional(e => e.Contractor)
                .HasForeignKey(e => e.ContractorId);

            modelBuilder.Entity<ContractorSets>()
                .HasMany(e => e.Deals)
                .WithOptional(e => e.Contractor)
                .HasForeignKey(e => e.ContractorId);

            modelBuilder.Entity<ContractorSets>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.Contractor)
                .HasForeignKey(e => e.ContractorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContractorSets>()
                .HasMany(e => e.Incomes)
                .WithOptional(e => e.ContractorPayer)
                .HasForeignKey(e => e.ContractorId);

            modelBuilder.Entity<ContractorSets>()
                .HasMany(e => e.ContWorkers)
                .WithOptional(e => e.Contractor)
                .HasForeignKey(e => e.ContractorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContractorSets>()
                .HasMany(e => e.ContFactures)
                .WithOptional(e => e.Contractor)
                .HasForeignKey(e => e.ContractorId);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.Contract)
                .WithRequired(e => e.Worker)
                .HasForeignKey(e => e.WorkerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Deals>()
                .HasMany(e => e.DealActions)
                .WithRequired(e => e.Deals)
                .HasForeignKey(e => e.DealId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Deals>()
                .HasMany(e => e.DealComments)
                .WithRequired(e => e.Deal)
                .HasForeignKey(e => e.DealId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Deals>()
                .HasMany(e => e.DealFileTables)
                .WithRequired(e => e.Deals)
                .HasForeignKey(e => e.DealId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Deals>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.Deal)
                .HasForeignKey(e => e.DealId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DeliverySets>()
                .HasMany(e => e.DeliveryFactures)
                .WithMany(e => e.Deliveries)
                .Map(m => m.ToTable("DeliveryFactures"));

            modelBuilder.Entity<Devices>()
                .HasMany(e => e.FormDevices)
                .WithRequired(e => e.Device)
                .HasForeignKey(e => e.DeviceId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DiscountSets>()
                .HasMany(e => e.DiscountedPackages)
                .WithMany(e => e.PackageDiscounts)
                .Map(m => m.ToTable("PackagesDiscounts"));

            modelBuilder.Entity<ExerciseSets>()
                .HasMany(e => e.Reports)
                .WithRequired(e => e.Exercise)
                .HasForeignKey(e => e.ExerciseId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ExerciseSets>()
                .HasMany(e => e.Worker)
                .WithMany(e => e.Exercise)
                .Map(m => m.ToTable("ExerciseLeaders").MapLeftKey("ExerciseId").MapRightKey("WorkerId"));

            modelBuilder.Entity<ExTypesSets>()
                .HasMany(e => e.Exercises)
                .WithRequired(e => e.Type)
                .HasForeignKey(e => e.ExTypesKey)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ExTypesSets>()
                .HasMany(e => e.Rooms)
                .WithMany(e => e.AvailableExTypes)
                .Map(m => m.ToTable("RoomsExTypes"));

            modelBuilder.Entity<FactureSets>()
                .HasMany(e => e.BoughtPackage)
                .WithRequired(e => e.PackageFacture)
                .HasForeignKey(e => e.FactureId);

            modelBuilder.Entity<FactureSets>()
                .HasMany(e => e.FactureFileTables)
                .WithRequired(e => e.Facture)
                .HasForeignKey(e => e.FactureId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FactureSets>()
                .HasMany(e => e.BoughtItems)
                .WithMany(e => e.ItemFactures)
                .Map(m => m.ToTable("ItemsOnFacture"));


            modelBuilder.Entity<FactureSets>()
                .HasMany(e => e.Incomes)
                .WithRequired(e => e.IncomeFacture)
                .HasForeignKey(e => e.FactureId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FactureSets>()
                .HasMany(e => e.Outcomes)
                .WithRequired(e => e.OutcomeFacture)
                .HasForeignKey(e => e.FactureId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FactureSets>()
                .HasMany(e => e.Warehouse)
                .WithMany(e => e.WarehouseFactures)
                .Map(m => m.ToTable("WarehouseFactures"));


            modelBuilder.Entity<FactureSets>()
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

            modelBuilder.Entity<HelpDeskPartialHistorySets>()
                .HasMany(e => e.HelpdeskFileTables)
                .WithOptional(e => e.HelpDeskPartialHistory)
                .HasForeignKey(e => e.HelpDeskPartialHistoryId);

            modelBuilder.Entity<HelpdeskSets>()
                .HasMany(e => e.HelpdeskFileTables)
                .WithOptional(e => e.HelpdeskSets)
                .HasForeignKey(e => e.HelpdeskId);

            modelBuilder.Entity<HelpdeskSets>()
                .HasMany(e => e.AnswerHistory)
                .WithRequired(e => e.HelpdeskApplication)
                .HasForeignKey(e => e.HelpdeskId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ListOfItemsSets>()
                .HasMany(e => e.Deliveries)
                .WithMany(e => e.DeliveryItems)
                .Map(m => m.ToTable("DeliveriedItems"));

            modelBuilder.Entity<Loads>()
                .HasMany(e => e.Payoffs)
                .WithRequired(e => e.Installment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MailerSmserSets>()
                .HasMany(e => e.Recipient)
                .WithMany(e => e.MailerSmserSets)
                .Map(m => m.ToTable("MailSmsRecipients"));

            modelBuilder.Entity<MainWarehouseSets>()
                .HasMany(e => e.Warehouses)
                .WithRequired(e => e.MainWarehouse)
                .HasForeignKey(e => e.MainWarehoseId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MoneyboxSet>()
                .HasMany(e => e.Incomes)
                .WithOptional(e => e.Moneybox)
                .HasForeignKey(e => e.MoneyboxId);

            modelBuilder.Entity<MoneyboxSet>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Moneybox)
                .HasForeignKey(e => e.MoneyboxId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MoneyboxSet>()
                .HasMany(e => e.Payoffs)
                .WithOptional(e => e.Moneybox)
                .HasForeignKey(e => e.MoneyboxId);

            modelBuilder.Entity<PackagesSets>()
                .HasMany(e => e.BoughtPackage)
                .WithRequired(e => e.BoughtPackage)
                .HasForeignKey(e => e.PackagesId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PackagesSets>()
                .HasMany(e => e.Exercises)
                .WithRequired(e => e.AllowedPackages)
                .HasForeignKey(e => e.PackagesId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PermissionsSets>()
                .HasMany(e => e.ApprovedRoles)
                .WithMany(e => e.RolePermissions)
                .Map(m => m.ToTable("RolePermissions"));

            modelBuilder.Entity<RoleSets>()
                .HasMany(e => e.Users)
                .WithMany(e => e.RoleSets)
                .Map(m => m.ToTable("UsersRoles"));

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.Permission)
                .WithMany(e => e.ApprovedUsers)
                .Map(m => m.ToTable("UsersPermissions"));

            modelBuilder.Entity<Resources>()
                .HasMany(e => e.Machines)
                .WithRequired(e => e.Resources)
                .HasForeignKey(e => e.ResourcesKey)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RoomsSets>()
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

            modelBuilder.Entity<TemplateSets>()
                .HasMany(e => e.Installments)
                .WithOptional(e => e.Template)
                .HasForeignKey(e => e.TemplateId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.BoughtPackagesSets)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.ContactSets)
                .WithOptional(e => e.ContactUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.DealActions)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.Deals)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.ExReports)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.FactureUpdate)
                .WithRequired(e => e.UserUpdate)
                .HasForeignKey(e => e.UpUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.FactureCreate)
                .WithRequired(e => e.UserCreate)
                .HasForeignKey(e => e.CrUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>() //todo
                .HasMany(e => e.FactureSets2)
                .WithOptional(e => e.UserSets2)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.FormAnswers)
                .WithRequired(e => e.Respondent)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.HelpDeskPartialHistory)
                .WithOptional(e => e.Recipient)
                .HasForeignKey(e => e.RecipientId);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.HelpdeskSets)
                .WithRequired(e => e.Recipient)
                .HasForeignKey(e => e.RecipientId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.Incomes)
                .WithOptional(e => e.UserPayer)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.UserFileTables)
                .WithRequired(e => e.UserSets)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>() // todo
                .HasMany(e => e.UserSets1)
                .WithOptional(e => e.UserSets2)
                .HasForeignKey(e => e.ReferId);

          // todo modelBuilder.Entity<VindicationSets>()
            //    .HasMany(e => e.MailerSmserSets)
            //    .WithOptional(e => e.VindicationSets)
            //    .HasForeignKey(e => e.VindicationId);

            //Start edit
            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.AddressEdit)
                .WithOptional(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.AnnouncementsEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.BankAccountEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.BoughtPackagesEdit)
                .WithOptional(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.ClubInfoEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.ContactEdit)
                .WithOptional(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.ContractorEdit)
                .WithOptional(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.ContractEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<UserSets>()
            //    .HasMany(e => e.ContractEdit)
            //    .WithOptional(e => e.Editor)
            //    .HasForeignKey(e => e.LastEditor)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.CountMachinesEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.DealActionsCreate)
                .WithRequired(e => e.Creator)
                .HasForeignKey(e => e.CreatorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.DealActionsEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.DealCommentsCreate)
                .WithRequired(e => e.Creator)
                .HasForeignKey(e => e.CreatorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.DealCreate)
                .WithRequired(e => e.Creator)
                .HasForeignKey(e => e.CreatorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.DealMenagerCreate)
                .WithRequired(e => e.DealMenager)
                .HasForeignKey(e => e.DealMenagerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.DealEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.DeliveryEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.DeviceCreate)
                .WithRequired(e => e.Creator)
                .HasForeignKey(e => e.CreatorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.DiscountEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.ExerciseEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.ExReportsEdit)
                .WithOptional(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.ExTypesEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.FactureEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.FormDevicesEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.FormQuestionEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.FormEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.HelpDeskAnswer)
                .WithOptional(e => e.Worker)
                .HasForeignKey(e => e.WorkerId);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.HelpdeskEdit)
                .WithOptional(e => e.Worker)
                .HasForeignKey(e => e.WorkerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.IncomesEdit)
                .WithOptional(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.ListOfItemsEdit)
                .WithOptional(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.MailerSmserSender)
                .WithRequired(e => e.Sender)
                .HasForeignKey(e => e.EditorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.MainWarehouseEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.NewsEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.WorkerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.PackagesEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.PermissionEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.RoleEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.ResourcesEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.RoomsEdit)
                .WithOptional(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.TagsEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.WorkerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.TaskEdit)
                .WithRequired(e => e.Worker)
                .HasForeignKey(e => e.WorkerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.TemplateEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.UserEdit)
                .WithOptional(e => e.Editor)
                .HasForeignKey(e => e.LastEditor);

            modelBuilder.Entity<UserSets>()
                .HasMany(e => e.WarehouseEdit)
                .WithRequired(e => e.Editor)
                .HasForeignKey(e => e.LastEditor)
                .WillCascadeOnDelete(false);

        }
    }
}
