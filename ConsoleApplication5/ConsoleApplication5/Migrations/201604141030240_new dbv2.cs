namespace ConsoleApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdbv2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
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
                .ForeignKey("dbo.Users", t => t.LastEditor)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.BankAccounts",
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
                .ForeignKey("dbo.Users", t => t.LastEditor)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .Index(t => t.AddressId)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.Users",
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
                .ForeignKey("dbo.Moneybox", t => t.MoneyboxId)
                .ForeignKey("dbo.Contractors", t => t.ContractorId)
                .ForeignKey("dbo.Users", t => t.LastEditor)
                .ForeignKey("dbo.Users", t => t.ReferId)
                .ForeignKey("dbo.Addresses", t => t.MainAddress)
                .ForeignKey("dbo.Addresses", t => t.SecondAddress)
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
                .ForeignKey("dbo.Users", t => t.LastEditor)
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
                .ForeignKey("dbo.Users", t => t.WorkerId)
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
                .ForeignKey("dbo.Users", t => t.LastEditor)
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
                .ForeignKey("dbo.Users", t => t.UserId)
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
                .ForeignKey("dbo.Users", t => t.LastEditor)
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
                .ForeignKey("dbo.Users", t => t.LastEditor)
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
                .ForeignKey("dbo.Clubs", t => t.ClubId)
                .ForeignKey("dbo.Users", t => t.CreatorId)
                .Index(t => t.CreatorId)
                .Index(t => t.ClubId);
            
            CreateTable(
                "dbo.Clubs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AddressId = c.Int(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.LastEditor)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .Index(t => t.AddressId)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.Contacts",
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
                .ForeignKey("dbo.Contractors", t => t.ContractorId)
                .ForeignKey("dbo.Clubs", t => t.ClubId)
                .ForeignKey("dbo.Users", t => t.LastEditor)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.ContractorId)
                .Index(t => t.UserId)
                .Index(t => t.ClubId)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.Contractors",
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
                .ForeignKey("dbo.Users", t => t.LastEditor)
                .ForeignKey("dbo.Addresses", t => t.MainAddress)
                .ForeignKey("dbo.Addresses", t => t.SecondAddress)
                .Index(t => t.MainAddress)
                .Index(t => t.SecondAddress)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.Factures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OpDate = c.DateTime(nullable: false),
                        FactureNumber = c.String(nullable: false),
                        NumberSeries = c.String(nullable: false),
                        CrDate = c.DateTime(nullable: false),
                        Category = c.Short(nullable: false),
                        ContractorId = c.Int(),
                        CreatorId = c.Int(nullable: false),
                        UpdateUserId = c.Int(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(nullable: false),
                        InstallmentCount = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        IsPaid = c.Boolean(nullable: false),
                        UserId = c.Int(),
                        ClubId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contractors", t => t.ContractorId)
                .ForeignKey("dbo.Clubs", t => t.ClubId)
                .ForeignKey("dbo.Users", t => t.CreatorId)
                .ForeignKey("dbo.Users", t => t.LastEditor)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UpdateUserId)
                .Index(t => t.ContractorId)
                .Index(t => t.CreatorId)
                .Index(t => t.UpdateUserId)
                .Index(t => t.LastEditor)
                .Index(t => t.UserId)
                .Index(t => t.ClubId);
            
            CreateTable(
                "dbo.ListOfItems",
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
                .ForeignKey("dbo.Users", t => t.LastEditor)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.Deliveries",
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
                .ForeignKey("dbo.Users", t => t.LastEditor)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.BoughtPackages",
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
                .ForeignKey("dbo.Packages", t => t.PackagesId)
                .ForeignKey("dbo.Factures", t => t.FactureId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.LastEditor)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.PackagesId)
                .Index(t => t.UserId)
                .Index(t => t.LastEditor)
                .Index(t => t.FactureId);
            
            CreateTable(
                "dbo.Packages",
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
                .ForeignKey("dbo.Users", t => t.LastEditor)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.Exercises",
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
                .ForeignKey("dbo.ExTypes", t => t.ExTypesKey)
                .ForeignKey("dbo.Rooms", t => t.RoomsId)
                .ForeignKey("dbo.Packages", t => t.PackagesId)
                .ForeignKey("dbo.Users", t => t.LastEditor)
                .Index(t => t.RoomsId)
                .Index(t => t.PackagesId)
                .Index(t => t.ExTypesKey)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.Rooms",
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
                .ForeignKey("dbo.Clubs", t => t.ClubId)
                .ForeignKey("dbo.Users", t => t.LastEditor)
                .Index(t => t.ClubId)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.ExTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.LastEditor)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.ExerciseReports",
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
                .ForeignKey("dbo.Exercises", t => t.ExerciseId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Users", t => t.LastEditor)
                .Index(t => t.ExerciseId)
                .Index(t => t.UserId)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.Discounts",
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
                .ForeignKey("dbo.Users", t => t.LastEditor)
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
                .ForeignKey("dbo.Factures", t => t.FactureId)
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
                .ForeignKey("dbo.Moneybox", t => t.MoneyboxId)
                .ForeignKey("dbo.Factures", t => t.FactureId)
                .ForeignKey("dbo.Contractors", t => t.ContractorId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Users", t => t.LastEditor)
                .Index(t => t.UserId)
                .Index(t => t.ContractorId)
                .Index(t => t.LastEditor)
                .Index(t => t.FactureId)
                .Index(t => t.MoneyboxId);
            
            CreateTable(
                "dbo.Moneybox",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(nullable: false),
                        NumberOfUsers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payoff",
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
                .ForeignKey("dbo.Moneybox", t => t.MoneyboxId)
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
                        LastEditor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Templates", t => t.TemplateId)
                .ForeignKey("dbo.Factures", t => t.FactureId)
                .ForeignKey("dbo.Users", t => t.LastEditor)
                .Index(t => t.FactureId)
                .Index(t => t.TemplateId)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.MailerSmsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SendDate = c.DateTime(),
                        Text = c.String(nullable: false),
                        Send = c.Boolean(nullable: false),
                        EditorId = c.Int(nullable: false),
                        Type = c.Short(nullable: false),
                        LoadsId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Loads", t => t.LoadsId)
                .ForeignKey("dbo.Users", t => t.EditorId)
                .Index(t => t.EditorId)
                .Index(t => t.LoadsId);
            
            CreateTable(
                "dbo.Templates",
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
                .ForeignKey("dbo.Users", t => t.LastEditor)
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
                .ForeignKey("dbo.Factures", t => t.FactureId)
                .Index(t => t.FactureId);
            
            CreateTable(
                "dbo.Warehouses",
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
                .ForeignKey("dbo.MainWarehouses", t => t.MainWarehoseId)
                .ForeignKey("dbo.Clubs", t => t.ClubId)
                .ForeignKey("dbo.Users", t => t.LastEditor)
                .Index(t => t.ClubId)
                .Index(t => t.MainWarehoseId)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.MainWarehouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TypeOf = c.Short(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.LastEditor)
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
                .ForeignKey("dbo.Contractors", t => t.ContractorId)
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
                .ForeignKey("dbo.Contractors", t => t.ContractorId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Users", t => t.CreatorId)
                .ForeignKey("dbo.Users", t => t.LastEditor)
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
                        MenagerId = c.Int(nullable: false),
                        LastEditor = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contractors", t => t.ContractorId)
                .ForeignKey("dbo.Users", t => t.CreatorId)
                .ForeignKey("dbo.Users", t => t.LastEditor)
                .ForeignKey("dbo.Users", t => t.MenagerId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.UserId)
                .Index(t => t.ContractorId)
                .Index(t => t.CreatorId)
                .Index(t => t.MenagerId)
                .Index(t => t.LastEditor)
                .Index(t => t.User_Id);
            
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
                .ForeignKey("dbo.Users", t => t.CreatorId)
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
                .ForeignKey("dbo.Contractors", t => t.ContractorId)
                .ForeignKey("dbo.Users", t => t.WorkerId)
                .Index(t => t.DealId)
                .Index(t => t.WorkerId)
                .Index(t => t.ContractorId);
            
            CreateTable(
                "dbo.CountMachines",
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
                .ForeignKey("dbo.Clubs", t => t.ClubKey)
                .ForeignKey("dbo.Users", t => t.LastEditor)
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
                .ForeignKey("dbo.Users", t => t.LastEditor)
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
                .ForeignKey("dbo.Users", t => t.WorkerId)
                .Index(t => t.TagId)
                .Index(t => t.WorkerId);
            
            CreateTable(
                "dbo.Contracts",
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
                .ForeignKey("dbo.Users", t => t.WorkerId)
                .ForeignKey("dbo.Users", t => t.LastEditor)
                .Index(t => t.WorkerId)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.HelpDeskPartialHistories",
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
                .ForeignKey("dbo.Helpdesks", t => t.HelpdeskId)
                .ForeignKey("dbo.Users", t => t.WorkerId)
                .ForeignKey("dbo.Users", t => t.RecipientId)
                .Index(t => t.HelpdeskId)
                .Index(t => t.WorkerId)
                .Index(t => t.RecipientId);
            
            CreateTable(
                "dbo.Helpdesks",
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
                .ForeignKey("dbo.Users", t => t.WorkerId)
                .ForeignKey("dbo.Users", t => t.RecipientId)
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
                .ForeignKey("dbo.Helpdesks", t => t.HelpdeskId)
                .ForeignKey("dbo.HelpDeskPartialHistories", t => t.HelpDeskPartialHistoryId)
                .Index(t => t.HelpdeskId)
                .Index(t => t.HelpDeskPartialHistoryId);
            
            CreateTable(
                "dbo.Permissions",
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
                .ForeignKey("dbo.Users", t => t.LastEditor)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.LastEditor)
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
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.DeliveryFactures",
                c => new
                    {
                        Delivery_Id = c.Int(nullable: false),
                        Facture_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Delivery_Id, t.Facture_Id })
                .ForeignKey("dbo.Deliveries", t => t.Delivery_Id, cascadeDelete: true)
                .ForeignKey("dbo.Factures", t => t.Facture_Id, cascadeDelete: true)
                .Index(t => t.Delivery_Id)
                .Index(t => t.Facture_Id);
            
            CreateTable(
                "dbo.DeliveriedItems",
                c => new
                    {
                        ListOfItems_Id = c.Int(nullable: false),
                        Delivery_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ListOfItems_Id, t.Delivery_Id })
                .ForeignKey("dbo.ListOfItems", t => t.ListOfItems_Id, cascadeDelete: true)
                .ForeignKey("dbo.Deliveries", t => t.Delivery_Id, cascadeDelete: true)
                .Index(t => t.ListOfItems_Id)
                .Index(t => t.Delivery_Id);
            
            CreateTable(
                "dbo.ItemsOnFacture",
                c => new
                    {
                        Facture_Id = c.Int(nullable: false),
                        ListOfItems_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Facture_Id, t.ListOfItems_Id })
                .ForeignKey("dbo.Factures", t => t.Facture_Id, cascadeDelete: true)
                .ForeignKey("dbo.ListOfItems", t => t.ListOfItems_Id, cascadeDelete: true)
                .Index(t => t.Facture_Id)
                .Index(t => t.ListOfItems_Id);
            
            CreateTable(
                "dbo.RoomsExTypes",
                c => new
                    {
                        ExTypes_Id = c.Int(nullable: false),
                        Rooms_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ExTypes_Id, t.Rooms_Id })
                .ForeignKey("dbo.ExTypes", t => t.ExTypes_Id, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.Rooms_Id, cascadeDelete: true)
                .Index(t => t.ExTypes_Id)
                .Index(t => t.Rooms_Id);
            
            CreateTable(
                "dbo.ExerciseLeaders",
                c => new
                    {
                        ExerciseId = c.Int(nullable: false),
                        WorkerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ExerciseId, t.WorkerId })
                .ForeignKey("dbo.Exercises", t => t.ExerciseId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.WorkerId, cascadeDelete: true)
                .Index(t => t.ExerciseId)
                .Index(t => t.WorkerId);
            
            CreateTable(
                "dbo.PackagesDiscounts",
                c => new
                    {
                        Discount_Id = c.Int(nullable: false),
                        Packages_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Discount_Id, t.Packages_Id })
                .ForeignKey("dbo.Discounts", t => t.Discount_Id, cascadeDelete: true)
                .ForeignKey("dbo.Packages", t => t.Packages_Id, cascadeDelete: true)
                .Index(t => t.Discount_Id)
                .Index(t => t.Packages_Id);
            
            CreateTable(
                "dbo.MailSmsRecipients",
                c => new
                    {
                        MailerSmser_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MailerSmser_Id, t.User_Id })
                .ForeignKey("dbo.MailerSmsers", t => t.MailerSmser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.MailerSmser_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.WarehouseFactures",
                c => new
                    {
                        Facture_Id = c.Int(nullable: false),
                        Warehouse_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Facture_Id, t.Warehouse_Id })
                .ForeignKey("dbo.Factures", t => t.Facture_Id, cascadeDelete: true)
                .ForeignKey("dbo.Warehouses", t => t.Warehouse_Id, cascadeDelete: true)
                .Index(t => t.Facture_Id)
                .Index(t => t.Warehouse_Id);
            
            CreateTable(
                "dbo.WorkersClubs",
                c => new
                    {
                        ClubId = c.Int(nullable: false),
                        WorkerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ClubId, t.WorkerId })
                .ForeignKey("dbo.Clubs", t => t.ClubId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.WorkerId, cascadeDelete: true)
                .Index(t => t.ClubId)
                .Index(t => t.WorkerId);
            
            CreateTable(
                "dbo.UsersRoles",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.User_Id })
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.RolePermissions",
                c => new
                    {
                        Permissions_Id = c.Int(nullable: false),
                        Role_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Permissions_Id, t.Role_Id })
                .ForeignKey("dbo.Permissions", t => t.Permissions_Id, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .Index(t => t.Permissions_Id)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.UsersPermissions",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Permissions_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Permissions_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Permissions", t => t.Permissions_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Permissions_Id);
            
            CreateTable(
                "dbo.AccountUsers",
                c => new
                    {
                        BankAccount_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BankAccount_Id, t.User_Id })
                .ForeignKey("dbo.BankAccounts", t => t.BankAccount_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.BankAccount_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "SecondAddress", "dbo.Addresses");
            DropForeignKey("dbo.Contractors", "SecondAddress", "dbo.Addresses");
            DropForeignKey("dbo.Users", "MainAddress", "dbo.Addresses");
            DropForeignKey("dbo.Contractors", "MainAddress", "dbo.Addresses");
            DropForeignKey("dbo.Clubs", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.BankAccounts", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.AccountUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.AccountUsers", "BankAccount_Id", "dbo.BankAccounts");
            DropForeignKey("dbo.Warehouses", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.Users", "ReferId", "dbo.Users");
            DropForeignKey("dbo.UserFileTables", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.Deals", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Templates", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.Tasks", "WorkerId", "dbo.Users");
            DropForeignKey("dbo.Tags", "WorkerId", "dbo.Users");
            DropForeignKey("dbo.Rooms", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.Roles", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.Resources", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.Permissions", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.UsersPermissions", "Permissions_Id", "dbo.Permissions");
            DropForeignKey("dbo.UsersPermissions", "User_Id", "dbo.Users");
            DropForeignKey("dbo.RolePermissions", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.RolePermissions", "Permissions_Id", "dbo.Permissions");
            DropForeignKey("dbo.UsersRoles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UsersRoles", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Packages", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.News", "WorkerId", "dbo.Users");
            DropForeignKey("dbo.MainWarehouses", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.MailerSmsers", "EditorId", "dbo.Users");
            DropForeignKey("dbo.Loads", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.ListOfItems", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.Incomes", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.Incomes", "UserId", "dbo.Users");
            DropForeignKey("dbo.Helpdesks", "RecipientId", "dbo.Users");
            DropForeignKey("dbo.HelpDeskPartialHistories", "RecipientId", "dbo.Users");
            DropForeignKey("dbo.Helpdesks", "WorkerId", "dbo.Users");
            DropForeignKey("dbo.HelpDeskPartialHistories", "WorkerId", "dbo.Users");
            DropForeignKey("dbo.HelpdeskFileTables", "HelpDeskPartialHistoryId", "dbo.HelpDeskPartialHistories");
            DropForeignKey("dbo.HelpdeskFileTables", "HelpdeskId", "dbo.Helpdesks");
            DropForeignKey("dbo.HelpDeskPartialHistories", "HelpdeskId", "dbo.Helpdesks");
            DropForeignKey("dbo.FormQuestions", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.Forms", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.FormDevices", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.FormAnswers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Factures", "UpdateUserId", "dbo.Users");
            DropForeignKey("dbo.Factures", "UserId", "dbo.Users");
            DropForeignKey("dbo.Factures", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.Factures", "CreatorId", "dbo.Users");
            DropForeignKey("dbo.ExTypes", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.ExerciseReports", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.ExerciseReports", "UserId", "dbo.Users");
            DropForeignKey("dbo.Exercises", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.Discounts", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.Devices", "CreatorId", "dbo.Users");
            DropForeignKey("dbo.Deliveries", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.Deals", "UserId", "dbo.Users");
            DropForeignKey("dbo.Deals", "MenagerId", "dbo.Users");
            DropForeignKey("dbo.Deals", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.Deals", "CreatorId", "dbo.Users");
            DropForeignKey("dbo.DealComments", "CreatorId", "dbo.Users");
            DropForeignKey("dbo.DealActions", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.DealActions", "CreatorId", "dbo.Users");
            DropForeignKey("dbo.DealActions", "UserId", "dbo.Users");
            DropForeignKey("dbo.CountMachines", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.Contractors", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.Contracts", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.Contracts", "WorkerId", "dbo.Users");
            DropForeignKey("dbo.Contacts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Contacts", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.Clubs", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.BoughtPackages", "UserId", "dbo.Users");
            DropForeignKey("dbo.BoughtPackages", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.BankAccounts", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.Announcements", "LastEditor", "dbo.Users");
            DropForeignKey("dbo.News", "TagId", "dbo.Tags");
            DropForeignKey("dbo.Forms", "TagId", "dbo.Tags");
            DropForeignKey("dbo.FormQuestions", "FormId", "dbo.Forms");
            DropForeignKey("dbo.FormDevices", "FormId", "dbo.Forms");
            DropForeignKey("dbo.FormDevices", "DeviceId", "dbo.Devices");
            DropForeignKey("dbo.WorkersClubs", "WorkerId", "dbo.Users");
            DropForeignKey("dbo.WorkersClubs", "ClubId", "dbo.Clubs");
            DropForeignKey("dbo.CountMachines", "ClubKey", "dbo.Clubs");
            DropForeignKey("dbo.CountMachines", "ResourcesKey", "dbo.Resources");
            DropForeignKey("dbo.Devices", "ClubId", "dbo.Clubs");
            DropForeignKey("dbo.Warehouses", "ClubId", "dbo.Clubs");
            DropForeignKey("dbo.Rooms", "ClubId", "dbo.Clubs");
            DropForeignKey("dbo.Factures", "ClubId", "dbo.Clubs");
            DropForeignKey("dbo.Contacts", "ClubId", "dbo.Clubs");
            DropForeignKey("dbo.Tasks", "ContractorId", "dbo.Contractors");
            DropForeignKey("dbo.Incomes", "ContractorId", "dbo.Contractors");
            DropForeignKey("dbo.Deals", "ContractorId", "dbo.Contractors");
            DropForeignKey("dbo.DealActions", "ContractorId", "dbo.Contractors");
            DropForeignKey("dbo.Tasks", "DealId", "dbo.Deals");
            DropForeignKey("dbo.DealFileTables", "DealId", "dbo.Deals");
            DropForeignKey("dbo.DealComments", "DealId", "dbo.Deals");
            DropForeignKey("dbo.DealActions", "DealId", "dbo.Deals");
            DropForeignKey("dbo.Users", "ContractorId", "dbo.Contractors");
            DropForeignKey("dbo.ContractorFileTables", "ContractorId", "dbo.Contractors");
            DropForeignKey("dbo.Factures", "ContractorId", "dbo.Contractors");
            DropForeignKey("dbo.WarehouseFactures", "Warehouse_Id", "dbo.Warehouses");
            DropForeignKey("dbo.WarehouseFactures", "Facture_Id", "dbo.Factures");
            DropForeignKey("dbo.Warehouses", "MainWarehoseId", "dbo.MainWarehouses");
            DropForeignKey("dbo.Outcomes", "FactureId", "dbo.Factures");
            DropForeignKey("dbo.Loads", "FactureId", "dbo.Factures");
            DropForeignKey("dbo.Incomes", "FactureId", "dbo.Factures");
            DropForeignKey("dbo.Users", "MoneyboxId", "dbo.Moneybox");
            DropForeignKey("dbo.Payoff", "MoneyboxId", "dbo.Moneybox");
            DropForeignKey("dbo.Loads", "TemplateId", "dbo.Templates");
            DropForeignKey("dbo.Payoff", "LoadsId", "dbo.Loads");
            DropForeignKey("dbo.MailerSmsers", "LoadsId", "dbo.Loads");
            DropForeignKey("dbo.MailSmsRecipients", "User_Id", "dbo.Users");
            DropForeignKey("dbo.MailSmsRecipients", "MailerSmser_Id", "dbo.MailerSmsers");
            DropForeignKey("dbo.Payoff", "IncomesId", "dbo.Incomes");
            DropForeignKey("dbo.Incomes", "MoneyboxId", "dbo.Moneybox");
            DropForeignKey("dbo.FactureFileTables", "FactureId", "dbo.Factures");
            DropForeignKey("dbo.BoughtPackages", "FactureId", "dbo.Factures");
            DropForeignKey("dbo.PackagesDiscounts", "Packages_Id", "dbo.Packages");
            DropForeignKey("dbo.PackagesDiscounts", "Discount_Id", "dbo.Discounts");
            DropForeignKey("dbo.Exercises", "PackagesId", "dbo.Packages");
            DropForeignKey("dbo.ExerciseLeaders", "WorkerId", "dbo.Users");
            DropForeignKey("dbo.ExerciseLeaders", "ExerciseId", "dbo.Exercises");
            DropForeignKey("dbo.ExerciseReports", "ExerciseId", "dbo.Exercises");
            DropForeignKey("dbo.Exercises", "RoomsId", "dbo.Rooms");
            DropForeignKey("dbo.RoomsExTypes", "Rooms_Id", "dbo.Rooms");
            DropForeignKey("dbo.RoomsExTypes", "ExTypes_Id", "dbo.ExTypes");
            DropForeignKey("dbo.Exercises", "ExTypesKey", "dbo.ExTypes");
            DropForeignKey("dbo.BoughtPackages", "PackagesId", "dbo.Packages");
            DropForeignKey("dbo.ItemsOnFacture", "ListOfItems_Id", "dbo.ListOfItems");
            DropForeignKey("dbo.ItemsOnFacture", "Facture_Id", "dbo.Factures");
            DropForeignKey("dbo.DeliveriedItems", "Delivery_Id", "dbo.Deliveries");
            DropForeignKey("dbo.DeliveriedItems", "ListOfItems_Id", "dbo.ListOfItems");
            DropForeignKey("dbo.DeliveryFactures", "Facture_Id", "dbo.Factures");
            DropForeignKey("dbo.DeliveryFactures", "Delivery_Id", "dbo.Deliveries");
            DropForeignKey("dbo.Contacts", "ContractorId", "dbo.Contractors");
            DropForeignKey("dbo.FormAnswers", "FormsId", "dbo.Forms");
            DropForeignKey("dbo.FormAnswers", "FormQuestionId", "dbo.FormQuestions");
            DropForeignKey("dbo.Announcements", "TagId", "dbo.Tags");
            DropForeignKey("dbo.Addresses", "LastEditor", "dbo.Users");
            DropIndex("dbo.AccountUsers", new[] { "User_Id" });
            DropIndex("dbo.AccountUsers", new[] { "BankAccount_Id" });
            DropIndex("dbo.UsersPermissions", new[] { "Permissions_Id" });
            DropIndex("dbo.UsersPermissions", new[] { "User_Id" });
            DropIndex("dbo.RolePermissions", new[] { "Role_Id" });
            DropIndex("dbo.RolePermissions", new[] { "Permissions_Id" });
            DropIndex("dbo.UsersRoles", new[] { "User_Id" });
            DropIndex("dbo.UsersRoles", new[] { "Role_Id" });
            DropIndex("dbo.WorkersClubs", new[] { "WorkerId" });
            DropIndex("dbo.WorkersClubs", new[] { "ClubId" });
            DropIndex("dbo.WarehouseFactures", new[] { "Warehouse_Id" });
            DropIndex("dbo.WarehouseFactures", new[] { "Facture_Id" });
            DropIndex("dbo.MailSmsRecipients", new[] { "User_Id" });
            DropIndex("dbo.MailSmsRecipients", new[] { "MailerSmser_Id" });
            DropIndex("dbo.PackagesDiscounts", new[] { "Packages_Id" });
            DropIndex("dbo.PackagesDiscounts", new[] { "Discount_Id" });
            DropIndex("dbo.ExerciseLeaders", new[] { "WorkerId" });
            DropIndex("dbo.ExerciseLeaders", new[] { "ExerciseId" });
            DropIndex("dbo.RoomsExTypes", new[] { "Rooms_Id" });
            DropIndex("dbo.RoomsExTypes", new[] { "ExTypes_Id" });
            DropIndex("dbo.ItemsOnFacture", new[] { "ListOfItems_Id" });
            DropIndex("dbo.ItemsOnFacture", new[] { "Facture_Id" });
            DropIndex("dbo.DeliveriedItems", new[] { "Delivery_Id" });
            DropIndex("dbo.DeliveriedItems", new[] { "ListOfItems_Id" });
            DropIndex("dbo.DeliveryFactures", new[] { "Facture_Id" });
            DropIndex("dbo.DeliveryFactures", new[] { "Delivery_Id" });
            DropIndex("dbo.UserFileTables", new[] { "UserId" });
            DropIndex("dbo.Roles", new[] { "LastEditor" });
            DropIndex("dbo.Permissions", new[] { "LastEditor" });
            DropIndex("dbo.HelpdeskFileTables", new[] { "HelpDeskPartialHistoryId" });
            DropIndex("dbo.HelpdeskFileTables", new[] { "HelpdeskId" });
            DropIndex("dbo.Helpdesks", new[] { "WorkerId" });
            DropIndex("dbo.Helpdesks", new[] { "RecipientId" });
            DropIndex("dbo.HelpDeskPartialHistories", new[] { "RecipientId" });
            DropIndex("dbo.HelpDeskPartialHistories", new[] { "WorkerId" });
            DropIndex("dbo.HelpDeskPartialHistories", new[] { "HelpdeskId" });
            DropIndex("dbo.Contracts", new[] { "LastEditor" });
            DropIndex("dbo.Contracts", new[] { "WorkerId" });
            DropIndex("dbo.News", new[] { "WorkerId" });
            DropIndex("dbo.News", new[] { "TagId" });
            DropIndex("dbo.Resources", new[] { "LastEditor" });
            DropIndex("dbo.CountMachines", new[] { "LastEditor" });
            DropIndex("dbo.CountMachines", new[] { "ResourcesKey" });
            DropIndex("dbo.CountMachines", new[] { "ClubKey" });
            DropIndex("dbo.Tasks", new[] { "ContractorId" });
            DropIndex("dbo.Tasks", new[] { "WorkerId" });
            DropIndex("dbo.Tasks", new[] { "DealId" });
            DropIndex("dbo.DealFileTables", new[] { "DealId" });
            DropIndex("dbo.DealComments", new[] { "CreatorId" });
            DropIndex("dbo.DealComments", new[] { "DealId" });
            DropIndex("dbo.Deals", new[] { "User_Id" });
            DropIndex("dbo.Deals", new[] { "LastEditor" });
            DropIndex("dbo.Deals", new[] { "MenagerId" });
            DropIndex("dbo.Deals", new[] { "CreatorId" });
            DropIndex("dbo.Deals", new[] { "ContractorId" });
            DropIndex("dbo.Deals", new[] { "UserId" });
            DropIndex("dbo.DealActions", new[] { "DealId" });
            DropIndex("dbo.DealActions", new[] { "LastEditor" });
            DropIndex("dbo.DealActions", new[] { "CreatorId" });
            DropIndex("dbo.DealActions", new[] { "ContractorId" });
            DropIndex("dbo.DealActions", new[] { "UserId" });
            DropIndex("dbo.ContractorFileTables", new[] { "ContractorId" });
            DropIndex("dbo.MainWarehouses", new[] { "LastEditor" });
            DropIndex("dbo.Warehouses", new[] { "LastEditor" });
            DropIndex("dbo.Warehouses", new[] { "MainWarehoseId" });
            DropIndex("dbo.Warehouses", new[] { "ClubId" });
            DropIndex("dbo.Outcomes", new[] { "FactureId" });
            DropIndex("dbo.Templates", new[] { "LastEditor" });
            DropIndex("dbo.MailerSmsers", new[] { "LoadsId" });
            DropIndex("dbo.MailerSmsers", new[] { "EditorId" });
            DropIndex("dbo.Loads", new[] { "LastEditor" });
            DropIndex("dbo.Loads", new[] { "TemplateId" });
            DropIndex("dbo.Loads", new[] { "FactureId" });
            DropIndex("dbo.Payoff", new[] { "MoneyboxId" });
            DropIndex("dbo.Payoff", new[] { "IncomesId" });
            DropIndex("dbo.Payoff", new[] { "LoadsId" });
            DropIndex("dbo.Incomes", new[] { "MoneyboxId" });
            DropIndex("dbo.Incomes", new[] { "FactureId" });
            DropIndex("dbo.Incomes", new[] { "LastEditor" });
            DropIndex("dbo.Incomes", new[] { "ContractorId" });
            DropIndex("dbo.Incomes", new[] { "UserId" });
            DropIndex("dbo.FactureFileTables", new[] { "FactureId" });
            DropIndex("dbo.Discounts", new[] { "LastEditor" });
            DropIndex("dbo.ExerciseReports", new[] { "LastEditor" });
            DropIndex("dbo.ExerciseReports", new[] { "UserId" });
            DropIndex("dbo.ExerciseReports", new[] { "ExerciseId" });
            DropIndex("dbo.ExTypes", new[] { "LastEditor" });
            DropIndex("dbo.Rooms", new[] { "LastEditor" });
            DropIndex("dbo.Rooms", new[] { "ClubId" });
            DropIndex("dbo.Exercises", new[] { "LastEditor" });
            DropIndex("dbo.Exercises", new[] { "ExTypesKey" });
            DropIndex("dbo.Exercises", new[] { "PackagesId" });
            DropIndex("dbo.Exercises", new[] { "RoomsId" });
            DropIndex("dbo.Packages", new[] { "LastEditor" });
            DropIndex("dbo.BoughtPackages", new[] { "FactureId" });
            DropIndex("dbo.BoughtPackages", new[] { "LastEditor" });
            DropIndex("dbo.BoughtPackages", new[] { "UserId" });
            DropIndex("dbo.BoughtPackages", new[] { "PackagesId" });
            DropIndex("dbo.Deliveries", new[] { "LastEditor" });
            DropIndex("dbo.ListOfItems", new[] { "LastEditor" });
            DropIndex("dbo.Factures", new[] { "ClubId" });
            DropIndex("dbo.Factures", new[] { "UserId" });
            DropIndex("dbo.Factures", new[] { "LastEditor" });
            DropIndex("dbo.Factures", new[] { "UpdateUserId" });
            DropIndex("dbo.Factures", new[] { "CreatorId" });
            DropIndex("dbo.Factures", new[] { "ContractorId" });
            DropIndex("dbo.Contractors", new[] { "LastEditor" });
            DropIndex("dbo.Contractors", new[] { "SecondAddress" });
            DropIndex("dbo.Contractors", new[] { "MainAddress" });
            DropIndex("dbo.Contacts", new[] { "LastEditor" });
            DropIndex("dbo.Contacts", new[] { "ClubId" });
            DropIndex("dbo.Contacts", new[] { "UserId" });
            DropIndex("dbo.Contacts", new[] { "ContractorId" });
            DropIndex("dbo.Clubs", new[] { "LastEditor" });
            DropIndex("dbo.Clubs", new[] { "AddressId" });
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
            DropIndex("dbo.Users", new[] { "MoneyboxId" });
            DropIndex("dbo.Users", new[] { "LastEditor" });
            DropIndex("dbo.Users", new[] { "ContractorId" });
            DropIndex("dbo.Users", new[] { "ReferId" });
            DropIndex("dbo.Users", new[] { "SecondAddress" });
            DropIndex("dbo.Users", new[] { "MainAddress" });
            DropIndex("dbo.BankAccounts", new[] { "LastEditor" });
            DropIndex("dbo.BankAccounts", new[] { "AddressId" });
            DropIndex("dbo.Addresses", new[] { "LastEditor" });
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
            DropTable("dbo.Roles");
            DropTable("dbo.Permissions");
            DropTable("dbo.HelpdeskFileTables");
            DropTable("dbo.Helpdesks");
            DropTable("dbo.HelpDeskPartialHistories");
            DropTable("dbo.Contracts");
            DropTable("dbo.News");
            DropTable("dbo.Resources");
            DropTable("dbo.CountMachines");
            DropTable("dbo.Tasks");
            DropTable("dbo.DealFileTables");
            DropTable("dbo.DealComments");
            DropTable("dbo.Deals");
            DropTable("dbo.DealActions");
            DropTable("dbo.ContractorFileTables");
            DropTable("dbo.MainWarehouses");
            DropTable("dbo.Warehouses");
            DropTable("dbo.Outcomes");
            DropTable("dbo.Templates");
            DropTable("dbo.MailerSmsers");
            DropTable("dbo.Loads");
            DropTable("dbo.Payoff");
            DropTable("dbo.Moneybox");
            DropTable("dbo.Incomes");
            DropTable("dbo.FactureFileTables");
            DropTable("dbo.Discounts");
            DropTable("dbo.ExerciseReports");
            DropTable("dbo.ExTypes");
            DropTable("dbo.Rooms");
            DropTable("dbo.Exercises");
            DropTable("dbo.Packages");
            DropTable("dbo.BoughtPackages");
            DropTable("dbo.Deliveries");
            DropTable("dbo.ListOfItems");
            DropTable("dbo.Factures");
            DropTable("dbo.Contractors");
            DropTable("dbo.Contacts");
            DropTable("dbo.Clubs");
            DropTable("dbo.Devices");
            DropTable("dbo.FormDevices");
            DropTable("dbo.FormQuestions");
            DropTable("dbo.FormAnswers");
            DropTable("dbo.Forms");
            DropTable("dbo.Tags");
            DropTable("dbo.Announcements");
            DropTable("dbo.Users");
            DropTable("dbo.BankAccounts");
            DropTable("dbo.Addresses");
        }
    }
}
