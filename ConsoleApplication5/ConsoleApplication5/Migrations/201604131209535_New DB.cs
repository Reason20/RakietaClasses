namespace ConsoleApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(nullable: false),
                        HouseNumber = c.String(nullable: false),
                        ApartmentNumber = c.String(),
                        PostalCode = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Province = c.Short(),
                        Country = c.Short(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.BankAccountSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BankAccountNumber = c.String(nullable: false),
                        CardNumber = c.String(),
                        BankName = c.String(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        AddressId = c.Int(),
                        LastEditor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .ForeignKey("dbo.AddressSets", t => t.AddressId)
                .Index(t => t.AddressId)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.UserSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        PESEL = c.Long(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Sex = c.Byte(nullable: false),
                        PlaceOfBirth = c.String(nullable: false),
                        IDNumber = c.String(nullable: false),
                        Notes = c.String(),
                        MainAddress = c.Int(nullable: false),
                        SecondAddress = c.Int(),
                        JoinDate = c.DateTime(nullable: false),
                        ReferId = c.Int(),
                        ContractorId = c.Int(),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(),
                        MoneyboxId = c.Int(nullable: false),
                        WorkerId = c.Int(),
                        ContractId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MoneyboxSet", t => t.MoneyboxId)
                .ForeignKey("dbo.ContractorSets", t => t.ContractorId)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .ForeignKey("dbo.UserSets", t => t.ReferId)
                .ForeignKey("dbo.AddressSets", t => t.MainAddress)
                .ForeignKey("dbo.AddressSets", t => t.SecondAddress)
                .Index(t => t.MainAddress)
                .Index(t => t.SecondAddress)
                .Index(t => t.ReferId)
                .Index(t => t.ContractorId)
                .Index(t => t.LastEditor)
                .Index(t => t.MoneyboxId);
            
            CreateTable(
                "dbo.Announcements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        CreateTime = c.String(nullable: false),
                        Text = c.String(nullable: false),
                        Note = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        TagId = c.Int(nullable: false),
                        LastEditor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tags", t => t.TagId)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .Index(t => t.TagId)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        WorkerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserSets", t => t.WorkerId)
                .Index(t => t.WorkerId);
            
            CreateTable(
                "dbo.Forms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        FormStartTime = c.DateTime(nullable: false),
                        FormEndTime = c.DateTime(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        TagId = c.Int(nullable: false),
                        LastEditor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tags", t => t.TagId)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .Index(t => t.TagId)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.FormAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FormsId = c.Int(nullable: false),
                        FormQuestionId = c.Int(nullable: false),
                        Answer = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FormQuestions", t => t.FormQuestionId)
                .ForeignKey("dbo.Forms", t => t.FormsId)
                .ForeignKey("dbo.UserSets", t => t.UserId)
                .Index(t => t.FormsId)
                .Index(t => t.FormQuestionId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.FormQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateTime = c.DateTime(nullable: false),
                        Text = c.String(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        FormId = c.Int(nullable: false),
                        LastEditor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Forms", t => t.FormId)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .Index(t => t.FormId)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.FormDevices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsActive = c.Boolean(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        DeviceId = c.Int(nullable: false),
                        FormId = c.Int(nullable: false),
                        LastEditor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Devices", t => t.DeviceId)
                .ForeignKey("dbo.Forms", t => t.FormId)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .Index(t => t.DeviceId)
                .Index(t => t.FormId)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CreatorId = c.Int(nullable: false),
                        ClubId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClubInfoSets", t => t.ClubId)
                .ForeignKey("dbo.UserSets", t => t.CreatorId)
                .Index(t => t.CreatorId)
                .Index(t => t.ClubId);
            
            CreateTable(
                "dbo.ClubInfoSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AddressId = c.Int(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .ForeignKey("dbo.AddressSets", t => t.AddressId)
                .Index(t => t.AddressId)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.ContactSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Skype = c.String(),
                        PhoneNumber = c.String(),
                        MobileNumber = c.String(),
                        FaxNumber = c.String(),
                        Email = c.String(),
                        ContractorId = c.Int(),
                        UserId = c.Int(),
                        ClubId = c.Int(),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContractorSets", t => t.ContractorId)
                .ForeignKey("dbo.ClubInfoSets", t => t.ClubId)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .ForeignKey("dbo.UserSets", t => t.UserId)
                .Index(t => t.ContractorId)
                .Index(t => t.UserId)
                .Index(t => t.ClubId)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.ContractorSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pesel = c.Long(),
                        NIP = c.Long(nullable: false),
                        REGON = c.Long(nullable: false),
                        Name = c.String(nullable: false),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        Comments = c.String(),
                        MainAddress = c.Int(nullable: false),
                        SecondAddress = c.Int(),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .ForeignKey("dbo.AddressSets", t => t.MainAddress)
                .ForeignKey("dbo.AddressSets", t => t.SecondAddress)
                .Index(t => t.MainAddress)
                .Index(t => t.SecondAddress)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.FactureSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OpDate = c.DateTime(nullable: false),
                        FactureNumber = c.String(nullable: false),
                        NumberSeries = c.String(nullable: false),
                        CrDate = c.DateTime(nullable: false),
                        Category = c.Short(nullable: false),
                        ContractorId = c.Int(),
                        CrUserId = c.Int(nullable: false),
                        UpUserId = c.Int(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(nullable: false),
                        InstallmentCount = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        IsPaid = c.Boolean(nullable: false),
                        UserId = c.Int(),
                        ClubId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContractorSets", t => t.ContractorId)
                .ForeignKey("dbo.ClubInfoSets", t => t.ClubId)
                .ForeignKey("dbo.UserSets", t => t.CrUserId)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .ForeignKey("dbo.UserSets", t => t.UserId)
                .ForeignKey("dbo.UserSets", t => t.UpUserId)
                .Index(t => t.ContractorId)
                .Index(t => t.CrUserId)
                .Index(t => t.UpUserId)
                .Index(t => t.LastEditor)
                .Index(t => t.UserId)
                .Index(t => t.ClubId);
            
            CreateTable(
                "dbo.ListOfItemsSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Count = c.Int(nullable: false),
                        Metric = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        PrecentTax = c.Double(nullable: false),
                        Tax = c.Double(nullable: false),
                        Netto = c.Double(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.DeliverySets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeliveryDate = c.DateTime(nullable: false),
                        DeliveryName = c.String(),
                        DeliveryNumber = c.String(nullable: false),
                        ListOfItemsId = c.Int(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.BoughtPackagesSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(nullable: false),
                        PackagesId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(),
                        FactureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PackagesSets", t => t.PackagesId)
                .ForeignKey("dbo.FactureSets", t => t.FactureId, cascadeDelete: true)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .ForeignKey("dbo.UserSets", t => t.UserId)
                .Index(t => t.PackagesId)
                .Index(t => t.UserId)
                .Index(t => t.LastEditor)
                .Index(t => t.FactureId);
            
            CreateTable(
                "dbo.PackagesSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Cost = c.Double(nullable: false),
                        Length = c.String(nullable: false),
                        TypeOf = c.Short(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.ExerciseSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Note = c.String(),
                        IsGroup = c.Boolean(nullable: false),
                        TimeCount = c.Short(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        StopTime = c.DateTime(nullable: false),
                        MaxPeople = c.Short(nullable: false),
                        RoomsId = c.Int(nullable: false),
                        PackagesId = c.Int(nullable: false),
                        TypeOf = c.Short(nullable: false),
                        ParticipantsList = c.String(nullable: false),
                        ExTypesKey = c.Int(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExTypesSets", t => t.ExTypesKey)
                .ForeignKey("dbo.RoomsSets", t => t.RoomsId)
                .ForeignKey("dbo.PackagesSets", t => t.PackagesId)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .Index(t => t.RoomsId)
                .Index(t => t.PackagesId)
                .Index(t => t.ExTypesKey)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.RoomsSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        MaxPeople = c.Short(nullable: false),
                        ClubId = c.Int(nullable: false),
                        TypeOf = c.Short(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClubInfoSets", t => t.ClubId)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .Index(t => t.ClubId)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.ExTypesSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.ExReportsSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Short(),
                        Paid = c.Boolean(nullable: false),
                        Reservation = c.Boolean(nullable: false),
                        Participated = c.Boolean(nullable: false),
                        Willingness = c.Boolean(nullable: false),
                        Canceled = c.Boolean(nullable: false),
                        ExerciseId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExerciseSets", t => t.ExerciseId)
                .ForeignKey("dbo.UserSets", t => t.UserId)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .Index(t => t.ExerciseId)
                .Index(t => t.UserId)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.DiscountSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        Amount = c.Short(),
                        TypeOf = c.Short(nullable: false),
                        LastEditTime = c.String(nullable: false),
                        LastEditor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.FactureFileTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameFile = c.String(nullable: false),
                        DataFile = c.Binary(nullable: false),
                        FileExtencion = c.String(nullable: false),
                        Size = c.Int(nullable: false),
                        FactureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FactureSets", t => t.FactureId)
                .Index(t => t.FactureId);
            
            CreateTable(
                "dbo.Incomes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Value = c.Double(nullable: false),
                        TypeOfPaid = c.Short(nullable: false),
                        UserId = c.Int(),
                        ContractorId = c.Int(),
                        LastEditor = c.Int(),
                        FactureId = c.Int(nullable: false),
                        MoneyboxId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MoneyboxSet", t => t.MoneyboxId)
                .ForeignKey("dbo.FactureSets", t => t.FactureId)
                .ForeignKey("dbo.ContractorSets", t => t.ContractorId)
                .ForeignKey("dbo.UserSets", t => t.UserId)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .Index(t => t.UserId)
                .Index(t => t.ContractorId)
                .Index(t => t.LastEditor)
                .Index(t => t.FactureId)
                .Index(t => t.MoneyboxId);
            
            CreateTable(
                "dbo.MoneyboxSet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(nullable: false),
                        NumberOfUsers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PayoffSet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeOf = c.Short(nullable: false),
                        Value = c.Double(nullable: false),
                        PercentOfLoad = c.Double(nullable: false),
                        PercentOfIncome = c.Double(nullable: false),
                        LoadsId = c.Int(nullable: false),
                        IncomesId = c.Int(),
                        MoneyboxId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Incomes", t => t.IncomesId)
                .ForeignKey("dbo.Loads", t => t.LoadsId)
                .ForeignKey("dbo.MoneyboxSet", t => t.MoneyboxId)
                .Index(t => t.LoadsId)
                .Index(t => t.IncomesId)
                .Index(t => t.MoneyboxId);
            
            CreateTable(
                "dbo.Loads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Double(nullable: false),
                        CrDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Interests = c.Double(nullable: false),
                        InTime = c.Boolean(nullable: false),
                        FactureId = c.Int(nullable: false),
                        Status = c.Short(nullable: false),
                        Comments = c.String(),
                        TemplateId = c.Int(),
                        LastEditor = c.Int(),
                        Worker_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TemplateSets", t => t.TemplateId)
                .ForeignKey("dbo.UserSets", t => t.Worker_Id)
                .ForeignKey("dbo.FactureSets", t => t.FactureId)
                .Index(t => t.FactureId)
                .Index(t => t.TemplateId)
                .Index(t => t.Worker_Id);
            
            CreateTable(
                "dbo.MailerSmserSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SendDate = c.DateTime(),
                        Text = c.String(nullable: false),
                        Send = c.Boolean(nullable: false),
                        EditorId = c.Int(nullable: false),
                        Type = c.Short(nullable: false),
                        VindicationId = c.Int(),
                        Installment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Loads", t => t.Installment_Id)
                .ForeignKey("dbo.UserSets", t => t.EditorId)
                .Index(t => t.EditorId)
                .Index(t => t.Installment_Id);
            
            CreateTable(
                "dbo.TemplateSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Text = c.String(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        TypeOf = c.Short(nullable: false),
                        LastEditor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.Outcomes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Double(nullable: false),
                        InTme = c.Boolean(nullable: false),
                        FactureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FactureSets", t => t.FactureId)
                .Index(t => t.FactureId);
            
            CreateTable(
                "dbo.WarehouseSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Count = c.Short(nullable: false),
                        RetailPrice = c.Int(nullable: false),
                        WholesalePrice = c.Int(nullable: false),
                        Tax = c.Double(nullable: false),
                        ClubId = c.Int(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        MainWarehoseId = c.Int(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(nullable: false),
                        FactureId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MainWarehouseSets", t => t.MainWarehoseId)
                .ForeignKey("dbo.ClubInfoSets", t => t.ClubId)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .Index(t => t.ClubId)
                .Index(t => t.MainWarehoseId)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.MainWarehouseSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TypeOf = c.Short(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.ContractorFileTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameFile = c.String(nullable: false),
                        DataFile = c.Binary(nullable: false),
                        FileExtencion = c.String(nullable: false),
                        Size = c.Int(nullable: false),
                        ContractorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContractorSets", t => t.ContractorId)
                .Index(t => t.ContractorId);
            
            CreateTable(
                "dbo.DealActions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Type = c.Short(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Note = c.String(),
                        LastEditTime = c.DateTime(nullable: false),
                        UserId = c.Int(),
                        ContractorId = c.Int(),
                        CreatorId = c.Int(nullable: false),
                        LastEditor = c.Int(nullable: false),
                        DealId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deals", t => t.DealId)
                .ForeignKey("dbo.ContractorSets", t => t.ContractorId)
                .ForeignKey("dbo.UserSets", t => t.UserId)
                .ForeignKey("dbo.UserSets", t => t.CreatorId)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .Index(t => t.UserId)
                .Index(t => t.ContractorId)
                .Index(t => t.CreatorId)
                .Index(t => t.LastEditor)
                .Index(t => t.DealId);
            
            CreateTable(
                "dbo.Deals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        CurrentStage = c.Short(nullable: false),
                        ClosingStage = c.Short(),
                        Note = c.String(),
                        EndDate = c.DateTime(),
                        CrDate = c.DateTime(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        UserId = c.Int(),
                        ContractorId = c.Int(),
                        CreatorId = c.Int(nullable: false),
                        DealMenagerId = c.Int(nullable: false),
                        LastEditor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContractorSets", t => t.ContractorId)
                .ForeignKey("dbo.UserSets", t => t.CreatorId)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .ForeignKey("dbo.UserSets", t => t.DealMenagerId)
                .ForeignKey("dbo.UserSets", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ContractorId)
                .Index(t => t.CreatorId)
                .Index(t => t.DealMenagerId)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.DealComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Text = c.String(nullable: false),
                        DealId = c.Int(nullable: false),
                        CreatorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deals", t => t.DealId)
                .ForeignKey("dbo.UserSets", t => t.CreatorId)
                .Index(t => t.DealId)
                .Index(t => t.CreatorId);
            
            CreateTable(
                "dbo.DealFileTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameFile = c.String(nullable: false),
                        DataFile = c.Binary(nullable: false),
                        FileExtencion = c.String(nullable: false),
                        Size = c.Int(nullable: false),
                        DealId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deals", t => t.DealId)
                .Index(t => t.DealId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Note = c.String(),
                        DealId = c.Int(nullable: false),
                        WorkerId = c.Int(nullable: false),
                        ContractorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deals", t => t.DealId)
                .ForeignKey("dbo.ContractorSets", t => t.ContractorId)
                .ForeignKey("dbo.UserSets", t => t.WorkerId)
                .Index(t => t.DealId)
                .Index(t => t.WorkerId)
                .Index(t => t.ContractorId);
            
            CreateTable(
                "dbo.CountMachinesSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        ClubKey = c.Int(nullable: false),
                        ResourcesKey = c.Int(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resources", t => t.ResourcesKey)
                .ForeignKey("dbo.ClubInfoSets", t => t.ClubKey)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .Index(t => t.ClubKey)
                .Index(t => t.ResourcesKey)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TypeOf = c.Short(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        NewsStartTime = c.DateTime(nullable: false),
                        NewsExpiresTime = c.DateTime(nullable: false),
                        Text = c.String(nullable: false),
                        Note = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        TagId = c.Int(nullable: false),
                        WorkerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tags", t => t.TagId)
                .ForeignKey("dbo.UserSets", t => t.WorkerId)
                .Index(t => t.TagId)
                .Index(t => t.WorkerId);
            
            CreateTable(
                "dbo.ContractSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AgreementDate = c.DateTime(nullable: false),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(),
                        IsValid = c.Boolean(nullable: false),
                        Salary = c.Double(nullable: false),
                        Payday = c.Short(nullable: false),
                        WorkingHours = c.Short(nullable: false),
                        Type = c.Short(nullable: false),
                        WorkerId = c.Int(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserSets", t => t.WorkerId)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .Index(t => t.WorkerId)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.HelpDeskPartialHistorySets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Short(nullable: false),
                        AnswerDate = c.DateTime(nullable: false),
                        AnswerText = c.String(nullable: false),
                        HelpdeskId = c.Int(nullable: false),
                        WorkerId = c.Int(),
                        RecipientId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HelpdeskSets", t => t.HelpdeskId)
                .ForeignKey("dbo.UserSets", t => t.WorkerId)
                .ForeignKey("dbo.UserSets", t => t.RecipientId)
                .Index(t => t.HelpdeskId)
                .Index(t => t.WorkerId)
                .Index(t => t.RecipientId);
            
            CreateTable(
                "dbo.HelpdeskSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Short(nullable: false),
                        TypeOf = c.Byte(nullable: false),
                        Title = c.String(nullable: false),
                        Text = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        isAnswered = c.Boolean(nullable: false),
                        AnswerDate = c.DateTime(),
                        AnswerText = c.String(),
                        RecipientId = c.Int(nullable: false),
                        WorkerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserSets", t => t.WorkerId)
                .ForeignKey("dbo.UserSets", t => t.RecipientId)
                .Index(t => t.RecipientId)
                .Index(t => t.WorkerId);
            
            CreateTable(
                "dbo.HelpdeskFileTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameFile = c.String(nullable: false),
                        DataFile = c.Binary(nullable: false),
                        FileExtencion = c.String(nullable: false),
                        Size = c.Int(nullable: false),
                        HelpdeskId = c.Int(),
                        HelpDeskPartialHistoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HelpdeskSets", t => t.HelpdeskId)
                .ForeignKey("dbo.HelpDeskPartialHistorySets", t => t.HelpDeskPartialHistoryId)
                .Index(t => t.HelpdeskId)
                .Index(t => t.HelpDeskPartialHistoryId);
            
            CreateTable(
                "dbo.PermissionsSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Function = c.Int(nullable: false),
                        Write = c.Boolean(nullable: false),
                        Read = c.Boolean(nullable: false),
                        Update = c.Boolean(nullable: false),
                        Delete = c.Boolean(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.RoleSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserSets", t => t.LastEditor)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.UserFileTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameFile = c.String(nullable: false),
                        DataFile = c.Binary(nullable: false),
                        FileExtencion = c.String(nullable: false),
                        Size = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserSets", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.DeliveryFactures",
                c => new
                    {
                        DeliverySets_Id = c.Int(nullable: false),
                        FactureSets_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DeliverySets_Id, t.FactureSets_Id })
                .ForeignKey("dbo.DeliverySets", t => t.DeliverySets_Id, cascadeDelete: true)
                .ForeignKey("dbo.FactureSets", t => t.FactureSets_Id, cascadeDelete: true)
                .Index(t => t.DeliverySets_Id)
                .Index(t => t.FactureSets_Id);
            
            CreateTable(
                "dbo.DeliveriedItems",
                c => new
                    {
                        ListOfItemsSets_Id = c.Int(nullable: false),
                        DeliverySets_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ListOfItemsSets_Id, t.DeliverySets_Id })
                .ForeignKey("dbo.ListOfItemsSets", t => t.ListOfItemsSets_Id, cascadeDelete: true)
                .ForeignKey("dbo.DeliverySets", t => t.DeliverySets_Id, cascadeDelete: true)
                .Index(t => t.ListOfItemsSets_Id)
                .Index(t => t.DeliverySets_Id);
            
            CreateTable(
                "dbo.ItemsOnFacture",
                c => new
                    {
                        FactureSets_Id = c.Int(nullable: false),
                        ListOfItemsSets_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FactureSets_Id, t.ListOfItemsSets_Id })
                .ForeignKey("dbo.FactureSets", t => t.FactureSets_Id, cascadeDelete: true)
                .ForeignKey("dbo.ListOfItemsSets", t => t.ListOfItemsSets_Id, cascadeDelete: true)
                .Index(t => t.FactureSets_Id)
                .Index(t => t.ListOfItemsSets_Id);
            
            CreateTable(
                "dbo.RoomsExTypes",
                c => new
                    {
                        ExTypesSets_Id = c.Int(nullable: false),
                        RoomsSets_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ExTypesSets_Id, t.RoomsSets_Id })
                .ForeignKey("dbo.ExTypesSets", t => t.ExTypesSets_Id, cascadeDelete: true)
                .ForeignKey("dbo.RoomsSets", t => t.RoomsSets_Id, cascadeDelete: true)
                .Index(t => t.ExTypesSets_Id)
                .Index(t => t.RoomsSets_Id);
            
            CreateTable(
                "dbo.ExerciseLeaders",
                c => new
                    {
                        ExerciseId = c.Int(nullable: false),
                        WorkerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ExerciseId, t.WorkerId })
                .ForeignKey("dbo.ExerciseSets", t => t.ExerciseId, cascadeDelete: true)
                .ForeignKey("dbo.UserSets", t => t.WorkerId, cascadeDelete: true)
                .Index(t => t.ExerciseId)
                .Index(t => t.WorkerId);
            
            CreateTable(
                "dbo.PackagesDiscounts",
                c => new
                    {
                        DiscountSets_Id = c.Int(nullable: false),
                        PackagesSets_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DiscountSets_Id, t.PackagesSets_Id })
                .ForeignKey("dbo.DiscountSets", t => t.DiscountSets_Id, cascadeDelete: true)
                .ForeignKey("dbo.PackagesSets", t => t.PackagesSets_Id, cascadeDelete: true)
                .Index(t => t.DiscountSets_Id)
                .Index(t => t.PackagesSets_Id);
            
            CreateTable(
                "dbo.MailSmsRecipients",
                c => new
                    {
                        MailerSmserSets_Id = c.Int(nullable: false),
                        UserSets_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MailerSmserSets_Id, t.UserSets_Id })
                .ForeignKey("dbo.MailerSmserSets", t => t.MailerSmserSets_Id, cascadeDelete: true)
                .ForeignKey("dbo.UserSets", t => t.UserSets_Id, cascadeDelete: true)
                .Index(t => t.MailerSmserSets_Id)
                .Index(t => t.UserSets_Id);
            
            CreateTable(
                "dbo.WarehouseFactures",
                c => new
                    {
                        FactureSets_Id = c.Int(nullable: false),
                        WarehouseSets_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FactureSets_Id, t.WarehouseSets_Id })
                .ForeignKey("dbo.FactureSets", t => t.FactureSets_Id, cascadeDelete: true)
                .ForeignKey("dbo.WarehouseSets", t => t.WarehouseSets_Id, cascadeDelete: true)
                .Index(t => t.FactureSets_Id)
                .Index(t => t.WarehouseSets_Id);
            
            CreateTable(
                "dbo.WorkersClubs",
                c => new
                    {
                        ClubId = c.Int(nullable: false),
                        WorkerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ClubId, t.WorkerId })
                .ForeignKey("dbo.ClubInfoSets", t => t.ClubId, cascadeDelete: true)
                .ForeignKey("dbo.UserSets", t => t.WorkerId, cascadeDelete: true)
                .Index(t => t.ClubId)
                .Index(t => t.WorkerId);
            
            CreateTable(
                "dbo.UsersRoles",
                c => new
                    {
                        RoleSets_Id = c.Int(nullable: false),
                        UserSets_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleSets_Id, t.UserSets_Id })
                .ForeignKey("dbo.RoleSets", t => t.RoleSets_Id, cascadeDelete: true)
                .ForeignKey("dbo.UserSets", t => t.UserSets_Id, cascadeDelete: true)
                .Index(t => t.RoleSets_Id)
                .Index(t => t.UserSets_Id);
            
            CreateTable(
                "dbo.RolePermissions",
                c => new
                    {
                        PermissionsSets_Id = c.Int(nullable: false),
                        RoleSets_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PermissionsSets_Id, t.RoleSets_Id })
                .ForeignKey("dbo.PermissionsSets", t => t.PermissionsSets_Id, cascadeDelete: true)
                .ForeignKey("dbo.RoleSets", t => t.RoleSets_Id, cascadeDelete: true)
                .Index(t => t.PermissionsSets_Id)
                .Index(t => t.RoleSets_Id);
            
            CreateTable(
                "dbo.UsersPermissions",
                c => new
                    {
                        UserSets_Id = c.Int(nullable: false),
                        PermissionsSets_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserSets_Id, t.PermissionsSets_Id })
                .ForeignKey("dbo.UserSets", t => t.UserSets_Id, cascadeDelete: true)
                .ForeignKey("dbo.PermissionsSets", t => t.PermissionsSets_Id, cascadeDelete: true)
                .Index(t => t.UserSets_Id)
                .Index(t => t.PermissionsSets_Id);
            
            CreateTable(
                "dbo.AccountUsers",
                c => new
                    {
                        BankAccountSets_Id = c.Int(nullable: false),
                        UserSets_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BankAccountSets_Id, t.UserSets_Id })
                .ForeignKey("dbo.BankAccountSets", t => t.BankAccountSets_Id, cascadeDelete: true)
                .ForeignKey("dbo.UserSets", t => t.UserSets_Id, cascadeDelete: true)
                .Index(t => t.BankAccountSets_Id)
                .Index(t => t.UserSets_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSets", "SecondAddress", "dbo.AddressSets");
            DropForeignKey("dbo.ContractorSets", "SecondAddress", "dbo.AddressSets");
            DropForeignKey("dbo.UserSets", "MainAddress", "dbo.AddressSets");
            DropForeignKey("dbo.ContractorSets", "MainAddress", "dbo.AddressSets");
            DropForeignKey("dbo.ClubInfoSets", "AddressId", "dbo.AddressSets");
            DropForeignKey("dbo.BankAccountSets", "AddressId", "dbo.AddressSets");
            DropForeignKey("dbo.AccountUsers", "UserSets_Id", "dbo.UserSets");
            DropForeignKey("dbo.AccountUsers", "BankAccountSets_Id", "dbo.BankAccountSets");
            DropForeignKey("dbo.WarehouseSets", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.UserSets", "ReferId", "dbo.UserSets");
            DropForeignKey("dbo.UserFileTables", "UserId", "dbo.UserSets");
            DropForeignKey("dbo.UserSets", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.TemplateSets", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.Tasks", "WorkerId", "dbo.UserSets");
            DropForeignKey("dbo.Tags", "WorkerId", "dbo.UserSets");
            DropForeignKey("dbo.RoomsSets", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.RoleSets", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.Resources", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.PermissionsSets", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.UsersPermissions", "PermissionsSets_Id", "dbo.PermissionsSets");
            DropForeignKey("dbo.UsersPermissions", "UserSets_Id", "dbo.UserSets");
            DropForeignKey("dbo.RolePermissions", "RoleSets_Id", "dbo.RoleSets");
            DropForeignKey("dbo.RolePermissions", "PermissionsSets_Id", "dbo.PermissionsSets");
            DropForeignKey("dbo.UsersRoles", "UserSets_Id", "dbo.UserSets");
            DropForeignKey("dbo.UsersRoles", "RoleSets_Id", "dbo.RoleSets");
            DropForeignKey("dbo.PackagesSets", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.News", "WorkerId", "dbo.UserSets");
            DropForeignKey("dbo.MainWarehouseSets", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.MailerSmserSets", "EditorId", "dbo.UserSets");
            DropForeignKey("dbo.ListOfItemsSets", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.Incomes", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.Incomes", "UserId", "dbo.UserSets");
            DropForeignKey("dbo.HelpdeskSets", "RecipientId", "dbo.UserSets");
            DropForeignKey("dbo.HelpDeskPartialHistorySets", "RecipientId", "dbo.UserSets");
            DropForeignKey("dbo.HelpdeskSets", "WorkerId", "dbo.UserSets");
            DropForeignKey("dbo.HelpDeskPartialHistorySets", "WorkerId", "dbo.UserSets");
            DropForeignKey("dbo.HelpdeskFileTables", "HelpDeskPartialHistoryId", "dbo.HelpDeskPartialHistorySets");
            DropForeignKey("dbo.HelpdeskFileTables", "HelpdeskId", "dbo.HelpdeskSets");
            DropForeignKey("dbo.HelpDeskPartialHistorySets", "HelpdeskId", "dbo.HelpdeskSets");
            DropForeignKey("dbo.FormQuestions", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.Forms", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.FormDevices", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.FormAnswers", "UserId", "dbo.UserSets");
            DropForeignKey("dbo.FactureSets", "UpUserId", "dbo.UserSets");
            DropForeignKey("dbo.FactureSets", "UserId", "dbo.UserSets");
            DropForeignKey("dbo.FactureSets", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.FactureSets", "CrUserId", "dbo.UserSets");
            DropForeignKey("dbo.ExTypesSets", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.ExReportsSets", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.ExReportsSets", "UserId", "dbo.UserSets");
            DropForeignKey("dbo.ExerciseSets", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.DiscountSets", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.Devices", "CreatorId", "dbo.UserSets");
            DropForeignKey("dbo.DeliverySets", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.Deals", "UserId", "dbo.UserSets");
            DropForeignKey("dbo.Deals", "DealMenagerId", "dbo.UserSets");
            DropForeignKey("dbo.Deals", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.Deals", "CreatorId", "dbo.UserSets");
            DropForeignKey("dbo.DealComments", "CreatorId", "dbo.UserSets");
            DropForeignKey("dbo.DealActions", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.DealActions", "CreatorId", "dbo.UserSets");
            DropForeignKey("dbo.DealActions", "UserId", "dbo.UserSets");
            DropForeignKey("dbo.CountMachinesSets", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.ContractorSets", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.ContractSets", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.ContractSets", "WorkerId", "dbo.UserSets");
            DropForeignKey("dbo.ContactSets", "UserId", "dbo.UserSets");
            DropForeignKey("dbo.ContactSets", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.ClubInfoSets", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.BoughtPackagesSets", "UserId", "dbo.UserSets");
            DropForeignKey("dbo.BoughtPackagesSets", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.BankAccountSets", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.Announcements", "LastEditor", "dbo.UserSets");
            DropForeignKey("dbo.News", "TagId", "dbo.Tags");
            DropForeignKey("dbo.Forms", "TagId", "dbo.Tags");
            DropForeignKey("dbo.FormQuestions", "FormId", "dbo.Forms");
            DropForeignKey("dbo.FormDevices", "FormId", "dbo.Forms");
            DropForeignKey("dbo.FormDevices", "DeviceId", "dbo.Devices");
            DropForeignKey("dbo.WorkersClubs", "WorkerId", "dbo.UserSets");
            DropForeignKey("dbo.WorkersClubs", "ClubId", "dbo.ClubInfoSets");
            DropForeignKey("dbo.CountMachinesSets", "ClubKey", "dbo.ClubInfoSets");
            DropForeignKey("dbo.CountMachinesSets", "ResourcesKey", "dbo.Resources");
            DropForeignKey("dbo.Devices", "ClubId", "dbo.ClubInfoSets");
            DropForeignKey("dbo.WarehouseSets", "ClubId", "dbo.ClubInfoSets");
            DropForeignKey("dbo.RoomsSets", "ClubId", "dbo.ClubInfoSets");
            DropForeignKey("dbo.FactureSets", "ClubId", "dbo.ClubInfoSets");
            DropForeignKey("dbo.ContactSets", "ClubId", "dbo.ClubInfoSets");
            DropForeignKey("dbo.Tasks", "ContractorId", "dbo.ContractorSets");
            DropForeignKey("dbo.Incomes", "ContractorId", "dbo.ContractorSets");
            DropForeignKey("dbo.Deals", "ContractorId", "dbo.ContractorSets");
            DropForeignKey("dbo.DealActions", "ContractorId", "dbo.ContractorSets");
            DropForeignKey("dbo.Tasks", "DealId", "dbo.Deals");
            DropForeignKey("dbo.DealFileTables", "DealId", "dbo.Deals");
            DropForeignKey("dbo.DealComments", "DealId", "dbo.Deals");
            DropForeignKey("dbo.DealActions", "DealId", "dbo.Deals");
            DropForeignKey("dbo.UserSets", "ContractorId", "dbo.ContractorSets");
            DropForeignKey("dbo.ContractorFileTables", "ContractorId", "dbo.ContractorSets");
            DropForeignKey("dbo.FactureSets", "ContractorId", "dbo.ContractorSets");
            DropForeignKey("dbo.WarehouseFactures", "WarehouseSets_Id", "dbo.WarehouseSets");
            DropForeignKey("dbo.WarehouseFactures", "FactureSets_Id", "dbo.FactureSets");
            DropForeignKey("dbo.WarehouseSets", "MainWarehoseId", "dbo.MainWarehouseSets");
            DropForeignKey("dbo.Outcomes", "FactureId", "dbo.FactureSets");
            DropForeignKey("dbo.Loads", "FactureId", "dbo.FactureSets");
            DropForeignKey("dbo.Incomes", "FactureId", "dbo.FactureSets");
            DropForeignKey("dbo.UserSets", "MoneyboxId", "dbo.MoneyboxSet");
            DropForeignKey("dbo.PayoffSet", "MoneyboxId", "dbo.MoneyboxSet");
            DropForeignKey("dbo.Loads", "Worker_Id", "dbo.UserSets");
            DropForeignKey("dbo.Loads", "TemplateId", "dbo.TemplateSets");
            DropForeignKey("dbo.PayoffSet", "LoadsId", "dbo.Loads");
            DropForeignKey("dbo.MailSmsRecipients", "UserSets_Id", "dbo.UserSets");
            DropForeignKey("dbo.MailSmsRecipients", "MailerSmserSets_Id", "dbo.MailerSmserSets");
            DropForeignKey("dbo.MailerSmserSets", "Installment_Id", "dbo.Loads");
            DropForeignKey("dbo.PayoffSet", "IncomesId", "dbo.Incomes");
            DropForeignKey("dbo.Incomes", "MoneyboxId", "dbo.MoneyboxSet");
            DropForeignKey("dbo.FactureFileTables", "FactureId", "dbo.FactureSets");
            DropForeignKey("dbo.BoughtPackagesSets", "FactureId", "dbo.FactureSets");
            DropForeignKey("dbo.PackagesDiscounts", "PackagesSets_Id", "dbo.PackagesSets");
            DropForeignKey("dbo.PackagesDiscounts", "DiscountSets_Id", "dbo.DiscountSets");
            DropForeignKey("dbo.ExerciseSets", "PackagesId", "dbo.PackagesSets");
            DropForeignKey("dbo.ExerciseLeaders", "WorkerId", "dbo.UserSets");
            DropForeignKey("dbo.ExerciseLeaders", "ExerciseId", "dbo.ExerciseSets");
            DropForeignKey("dbo.ExReportsSets", "ExerciseId", "dbo.ExerciseSets");
            DropForeignKey("dbo.ExerciseSets", "RoomsId", "dbo.RoomsSets");
            DropForeignKey("dbo.RoomsExTypes", "RoomsSets_Id", "dbo.RoomsSets");
            DropForeignKey("dbo.RoomsExTypes", "ExTypesSets_Id", "dbo.ExTypesSets");
            DropForeignKey("dbo.ExerciseSets", "ExTypesKey", "dbo.ExTypesSets");
            DropForeignKey("dbo.BoughtPackagesSets", "PackagesId", "dbo.PackagesSets");
            DropForeignKey("dbo.ItemsOnFacture", "ListOfItemsSets_Id", "dbo.ListOfItemsSets");
            DropForeignKey("dbo.ItemsOnFacture", "FactureSets_Id", "dbo.FactureSets");
            DropForeignKey("dbo.DeliveriedItems", "DeliverySets_Id", "dbo.DeliverySets");
            DropForeignKey("dbo.DeliveriedItems", "ListOfItemsSets_Id", "dbo.ListOfItemsSets");
            DropForeignKey("dbo.DeliveryFactures", "FactureSets_Id", "dbo.FactureSets");
            DropForeignKey("dbo.DeliveryFactures", "DeliverySets_Id", "dbo.DeliverySets");
            DropForeignKey("dbo.ContactSets", "ContractorId", "dbo.ContractorSets");
            DropForeignKey("dbo.FormAnswers", "FormsId", "dbo.Forms");
            DropForeignKey("dbo.FormAnswers", "FormQuestionId", "dbo.FormQuestions");
            DropForeignKey("dbo.Announcements", "TagId", "dbo.Tags");
            DropForeignKey("dbo.AddressSets", "LastEditor", "dbo.UserSets");
            DropIndex("dbo.AccountUsers", new[] { "UserSets_Id" });
            DropIndex("dbo.AccountUsers", new[] { "BankAccountSets_Id" });
            DropIndex("dbo.UsersPermissions", new[] { "PermissionsSets_Id" });
            DropIndex("dbo.UsersPermissions", new[] { "UserSets_Id" });
            DropIndex("dbo.RolePermissions", new[] { "RoleSets_Id" });
            DropIndex("dbo.RolePermissions", new[] { "PermissionsSets_Id" });
            DropIndex("dbo.UsersRoles", new[] { "UserSets_Id" });
            DropIndex("dbo.UsersRoles", new[] { "RoleSets_Id" });
            DropIndex("dbo.WorkersClubs", new[] { "WorkerId" });
            DropIndex("dbo.WorkersClubs", new[] { "ClubId" });
            DropIndex("dbo.WarehouseFactures", new[] { "WarehouseSets_Id" });
            DropIndex("dbo.WarehouseFactures", new[] { "FactureSets_Id" });
            DropIndex("dbo.MailSmsRecipients", new[] { "UserSets_Id" });
            DropIndex("dbo.MailSmsRecipients", new[] { "MailerSmserSets_Id" });
            DropIndex("dbo.PackagesDiscounts", new[] { "PackagesSets_Id" });
            DropIndex("dbo.PackagesDiscounts", new[] { "DiscountSets_Id" });
            DropIndex("dbo.ExerciseLeaders", new[] { "WorkerId" });
            DropIndex("dbo.ExerciseLeaders", new[] { "ExerciseId" });
            DropIndex("dbo.RoomsExTypes", new[] { "RoomsSets_Id" });
            DropIndex("dbo.RoomsExTypes", new[] { "ExTypesSets_Id" });
            DropIndex("dbo.ItemsOnFacture", new[] { "ListOfItemsSets_Id" });
            DropIndex("dbo.ItemsOnFacture", new[] { "FactureSets_Id" });
            DropIndex("dbo.DeliveriedItems", new[] { "DeliverySets_Id" });
            DropIndex("dbo.DeliveriedItems", new[] { "ListOfItemsSets_Id" });
            DropIndex("dbo.DeliveryFactures", new[] { "FactureSets_Id" });
            DropIndex("dbo.DeliveryFactures", new[] { "DeliverySets_Id" });
            DropIndex("dbo.UserFileTables", new[] { "UserId" });
            DropIndex("dbo.RoleSets", new[] { "LastEditor" });
            DropIndex("dbo.PermissionsSets", new[] { "LastEditor" });
            DropIndex("dbo.HelpdeskFileTables", new[] { "HelpDeskPartialHistoryId" });
            DropIndex("dbo.HelpdeskFileTables", new[] { "HelpdeskId" });
            DropIndex("dbo.HelpdeskSets", new[] { "WorkerId" });
            DropIndex("dbo.HelpdeskSets", new[] { "RecipientId" });
            DropIndex("dbo.HelpDeskPartialHistorySets", new[] { "RecipientId" });
            DropIndex("dbo.HelpDeskPartialHistorySets", new[] { "WorkerId" });
            DropIndex("dbo.HelpDeskPartialHistorySets", new[] { "HelpdeskId" });
            DropIndex("dbo.ContractSets", new[] { "LastEditor" });
            DropIndex("dbo.ContractSets", new[] { "WorkerId" });
            DropIndex("dbo.News", new[] { "WorkerId" });
            DropIndex("dbo.News", new[] { "TagId" });
            DropIndex("dbo.Resources", new[] { "LastEditor" });
            DropIndex("dbo.CountMachinesSets", new[] { "LastEditor" });
            DropIndex("dbo.CountMachinesSets", new[] { "ResourcesKey" });
            DropIndex("dbo.CountMachinesSets", new[] { "ClubKey" });
            DropIndex("dbo.Tasks", new[] { "ContractorId" });
            DropIndex("dbo.Tasks", new[] { "WorkerId" });
            DropIndex("dbo.Tasks", new[] { "DealId" });
            DropIndex("dbo.DealFileTables", new[] { "DealId" });
            DropIndex("dbo.DealComments", new[] { "CreatorId" });
            DropIndex("dbo.DealComments", new[] { "DealId" });
            DropIndex("dbo.Deals", new[] { "LastEditor" });
            DropIndex("dbo.Deals", new[] { "DealMenagerId" });
            DropIndex("dbo.Deals", new[] { "CreatorId" });
            DropIndex("dbo.Deals", new[] { "ContractorId" });
            DropIndex("dbo.Deals", new[] { "UserId" });
            DropIndex("dbo.DealActions", new[] { "DealId" });
            DropIndex("dbo.DealActions", new[] { "LastEditor" });
            DropIndex("dbo.DealActions", new[] { "CreatorId" });
            DropIndex("dbo.DealActions", new[] { "ContractorId" });
            DropIndex("dbo.DealActions", new[] { "UserId" });
            DropIndex("dbo.ContractorFileTables", new[] { "ContractorId" });
            DropIndex("dbo.MainWarehouseSets", new[] { "LastEditor" });
            DropIndex("dbo.WarehouseSets", new[] { "LastEditor" });
            DropIndex("dbo.WarehouseSets", new[] { "MainWarehoseId" });
            DropIndex("dbo.WarehouseSets", new[] { "ClubId" });
            DropIndex("dbo.Outcomes", new[] { "FactureId" });
            DropIndex("dbo.TemplateSets", new[] { "LastEditor" });
            DropIndex("dbo.MailerSmserSets", new[] { "Installment_Id" });
            DropIndex("dbo.MailerSmserSets", new[] { "EditorId" });
            DropIndex("dbo.Loads", new[] { "Worker_Id" });
            DropIndex("dbo.Loads", new[] { "TemplateId" });
            DropIndex("dbo.Loads", new[] { "FactureId" });
            DropIndex("dbo.PayoffSet", new[] { "MoneyboxId" });
            DropIndex("dbo.PayoffSet", new[] { "IncomesId" });
            DropIndex("dbo.PayoffSet", new[] { "LoadsId" });
            DropIndex("dbo.Incomes", new[] { "MoneyboxId" });
            DropIndex("dbo.Incomes", new[] { "FactureId" });
            DropIndex("dbo.Incomes", new[] { "LastEditor" });
            DropIndex("dbo.Incomes", new[] { "ContractorId" });
            DropIndex("dbo.Incomes", new[] { "UserId" });
            DropIndex("dbo.FactureFileTables", new[] { "FactureId" });
            DropIndex("dbo.DiscountSets", new[] { "LastEditor" });
            DropIndex("dbo.ExReportsSets", new[] { "LastEditor" });
            DropIndex("dbo.ExReportsSets", new[] { "UserId" });
            DropIndex("dbo.ExReportsSets", new[] { "ExerciseId" });
            DropIndex("dbo.ExTypesSets", new[] { "LastEditor" });
            DropIndex("dbo.RoomsSets", new[] { "LastEditor" });
            DropIndex("dbo.RoomsSets", new[] { "ClubId" });
            DropIndex("dbo.ExerciseSets", new[] { "LastEditor" });
            DropIndex("dbo.ExerciseSets", new[] { "ExTypesKey" });
            DropIndex("dbo.ExerciseSets", new[] { "PackagesId" });
            DropIndex("dbo.ExerciseSets", new[] { "RoomsId" });
            DropIndex("dbo.PackagesSets", new[] { "LastEditor" });
            DropIndex("dbo.BoughtPackagesSets", new[] { "FactureId" });
            DropIndex("dbo.BoughtPackagesSets", new[] { "LastEditor" });
            DropIndex("dbo.BoughtPackagesSets", new[] { "UserId" });
            DropIndex("dbo.BoughtPackagesSets", new[] { "PackagesId" });
            DropIndex("dbo.DeliverySets", new[] { "LastEditor" });
            DropIndex("dbo.ListOfItemsSets", new[] { "LastEditor" });
            DropIndex("dbo.FactureSets", new[] { "ClubId" });
            DropIndex("dbo.FactureSets", new[] { "UserId" });
            DropIndex("dbo.FactureSets", new[] { "LastEditor" });
            DropIndex("dbo.FactureSets", new[] { "UpUserId" });
            DropIndex("dbo.FactureSets", new[] { "CrUserId" });
            DropIndex("dbo.FactureSets", new[] { "ContractorId" });
            DropIndex("dbo.ContractorSets", new[] { "LastEditor" });
            DropIndex("dbo.ContractorSets", new[] { "SecondAddress" });
            DropIndex("dbo.ContractorSets", new[] { "MainAddress" });
            DropIndex("dbo.ContactSets", new[] { "LastEditor" });
            DropIndex("dbo.ContactSets", new[] { "ClubId" });
            DropIndex("dbo.ContactSets", new[] { "UserId" });
            DropIndex("dbo.ContactSets", new[] { "ContractorId" });
            DropIndex("dbo.ClubInfoSets", new[] { "LastEditor" });
            DropIndex("dbo.ClubInfoSets", new[] { "AddressId" });
            DropIndex("dbo.Devices", new[] { "ClubId" });
            DropIndex("dbo.Devices", new[] { "CreatorId" });
            DropIndex("dbo.FormDevices", new[] { "LastEditor" });
            DropIndex("dbo.FormDevices", new[] { "FormId" });
            DropIndex("dbo.FormDevices", new[] { "DeviceId" });
            DropIndex("dbo.FormQuestions", new[] { "LastEditor" });
            DropIndex("dbo.FormQuestions", new[] { "FormId" });
            DropIndex("dbo.FormAnswers", new[] { "UserId" });
            DropIndex("dbo.FormAnswers", new[] { "FormQuestionId" });
            DropIndex("dbo.FormAnswers", new[] { "FormsId" });
            DropIndex("dbo.Forms", new[] { "LastEditor" });
            DropIndex("dbo.Forms", new[] { "TagId" });
            DropIndex("dbo.Tags", new[] { "WorkerId" });
            DropIndex("dbo.Announcements", new[] { "LastEditor" });
            DropIndex("dbo.Announcements", new[] { "TagId" });
            DropIndex("dbo.UserSets", new[] { "MoneyboxId" });
            DropIndex("dbo.UserSets", new[] { "LastEditor" });
            DropIndex("dbo.UserSets", new[] { "ContractorId" });
            DropIndex("dbo.UserSets", new[] { "ReferId" });
            DropIndex("dbo.UserSets", new[] { "SecondAddress" });
            DropIndex("dbo.UserSets", new[] { "MainAddress" });
            DropIndex("dbo.BankAccountSets", new[] { "LastEditor" });
            DropIndex("dbo.BankAccountSets", new[] { "AddressId" });
            DropIndex("dbo.AddressSets", new[] { "LastEditor" });
            DropTable("dbo.AccountUsers");
            DropTable("dbo.UsersPermissions");
            DropTable("dbo.RolePermissions");
            DropTable("dbo.UsersRoles");
            DropTable("dbo.WorkersClubs");
            DropTable("dbo.WarehouseFactures");
            DropTable("dbo.MailSmsRecipients");
            DropTable("dbo.PackagesDiscounts");
            DropTable("dbo.ExerciseLeaders");
            DropTable("dbo.RoomsExTypes");
            DropTable("dbo.ItemsOnFacture");
            DropTable("dbo.DeliveriedItems");
            DropTable("dbo.DeliveryFactures");
            DropTable("dbo.UserFileTables");
            DropTable("dbo.RoleSets");
            DropTable("dbo.PermissionsSets");
            DropTable("dbo.HelpdeskFileTables");
            DropTable("dbo.HelpdeskSets");
            DropTable("dbo.HelpDeskPartialHistorySets");
            DropTable("dbo.ContractSets");
            DropTable("dbo.News");
            DropTable("dbo.Resources");
            DropTable("dbo.CountMachinesSets");
            DropTable("dbo.Tasks");
            DropTable("dbo.DealFileTables");
            DropTable("dbo.DealComments");
            DropTable("dbo.Deals");
            DropTable("dbo.DealActions");
            DropTable("dbo.ContractorFileTables");
            DropTable("dbo.MainWarehouseSets");
            DropTable("dbo.WarehouseSets");
            DropTable("dbo.Outcomes");
            DropTable("dbo.TemplateSets");
            DropTable("dbo.MailerSmserSets");
            DropTable("dbo.Loads");
            DropTable("dbo.PayoffSet");
            DropTable("dbo.MoneyboxSet");
            DropTable("dbo.Incomes");
            DropTable("dbo.FactureFileTables");
            DropTable("dbo.DiscountSets");
            DropTable("dbo.ExReportsSets");
            DropTable("dbo.ExTypesSets");
            DropTable("dbo.RoomsSets");
            DropTable("dbo.ExerciseSets");
            DropTable("dbo.PackagesSets");
            DropTable("dbo.BoughtPackagesSets");
            DropTable("dbo.DeliverySets");
            DropTable("dbo.ListOfItemsSets");
            DropTable("dbo.FactureSets");
            DropTable("dbo.ContractorSets");
            DropTable("dbo.ContactSets");
            DropTable("dbo.ClubInfoSets");
            DropTable("dbo.Devices");
            DropTable("dbo.FormDevices");
            DropTable("dbo.FormQuestions");
            DropTable("dbo.FormAnswers");
            DropTable("dbo.Forms");
            DropTable("dbo.Tags");
            DropTable("dbo.Announcements");
            DropTable("dbo.UserSets");
            DropTable("dbo.BankAccountSets");
            DropTable("dbo.AddressSets");
        }
    }
}
