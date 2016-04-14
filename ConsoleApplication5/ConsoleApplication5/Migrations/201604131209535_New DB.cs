namespace ConsoleApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
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
                .ForeignKey("dbo.User", t => t.LastEditor)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.BankAccount",
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
                .ForeignKey("dbo.User", t => t.LastEditor)
                .ForeignKey("dbo.Address", t => t.AddressId)
                .Index(t => t.AddressId)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.User",
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
                .ForeignKey("dbo.Contractor", t => t.ContractorId)
                .ForeignKey("dbo.User", t => t.LastEditor)
                .ForeignKey("dbo.User", t => t.ReferId)
                .ForeignKey("dbo.Address", t => t.MainAddress)
                .ForeignKey("dbo.Address", t => t.SecondAddress)
                .Index(t => t.MainAddress)
                .Index(t => t.SecondAddress)
                .Index(t => t.ReferId)
                .Index(t => t.ContractorId)
                .Index(t => t.LastEditor)
                .Index(t => t.MoneyboxId);
            
            CreateTable(
                "dbo.Announcement",
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
                .ForeignKey("dbo.User", t => t.LastEditor)
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
                .ForeignKey("dbo.User", t => t.WorkerId)
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
                .ForeignKey("dbo.User", t => t.LastEditor)
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
                .ForeignKey("dbo.User", t => t.UserId)
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
                .ForeignKey("dbo.User", t => t.LastEditor)
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
                .ForeignKey("dbo.User", t => t.LastEditor)
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
                .ForeignKey("dbo.Club", t => t.ClubId)
                .ForeignKey("dbo.User", t => t.CreatorId)
                .Index(t => t.CreatorId)
                .Index(t => t.ClubId);
            
            CreateTable(
                "dbo.Club",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AddressId = c.Int(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.LastEditor)
                .ForeignKey("dbo.Address", t => t.AddressId)
                .Index(t => t.AddressId)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.Contact",
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
                .ForeignKey("dbo.Contractor", t => t.ContractorId)
                .ForeignKey("dbo.Club", t => t.ClubId)
                .ForeignKey("dbo.User", t => t.LastEditor)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.ContractorId)
                .Index(t => t.UserId)
                .Index(t => t.ClubId)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.Contractor",
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
                .ForeignKey("dbo.User", t => t.LastEditor)
                .ForeignKey("dbo.Address", t => t.MainAddress)
                .ForeignKey("dbo.Address", t => t.SecondAddress)
                .Index(t => t.MainAddress)
                .Index(t => t.SecondAddress)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.Facture",
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
                .ForeignKey("dbo.Contractor", t => t.ContractorId)
                .ForeignKey("dbo.Club", t => t.ClubId)
                .ForeignKey("dbo.User", t => t.CrUserId)
                .ForeignKey("dbo.User", t => t.LastEditor)
                .ForeignKey("dbo.User", t => t.UserId)
                .ForeignKey("dbo.User", t => t.UpUserId)
                .Index(t => t.ContractorId)
                .Index(t => t.CrUserId)
                .Index(t => t.UpUserId)
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
                .ForeignKey("dbo.User", t => t.LastEditor)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.Delivery",
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
                .ForeignKey("dbo.User", t => t.LastEditor)
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
                .ForeignKey("dbo.Facture", t => t.FactureId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.LastEditor)
                .ForeignKey("dbo.User", t => t.UserId)
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
                .ForeignKey("dbo.User", t => t.LastEditor)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.Exercise",
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
                .ForeignKey("dbo.User", t => t.LastEditor)
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
                .ForeignKey("dbo.Club", t => t.ClubId)
                .ForeignKey("dbo.User", t => t.LastEditor)
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
                .ForeignKey("dbo.User", t => t.LastEditor)
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
                .ForeignKey("dbo.Exercise", t => t.ExerciseId)
                .ForeignKey("dbo.User", t => t.UserId)
                .ForeignKey("dbo.User", t => t.LastEditor)
                .Index(t => t.ExerciseId)
                .Index(t => t.UserId)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.Discount",
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
                .ForeignKey("dbo.User", t => t.LastEditor)
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
                .ForeignKey("dbo.Facture", t => t.FactureId)
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
                .ForeignKey("dbo.Facture", t => t.FactureId)
                .ForeignKey("dbo.Contractor", t => t.ContractorId)
                .ForeignKey("dbo.User", t => t.UserId)
                .ForeignKey("dbo.User", t => t.LastEditor)
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
                        LastEditor = c.Int(),
                        Worker_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Template", t => t.TemplateId)
                .ForeignKey("dbo.User", t => t.Worker_Id)
                .ForeignKey("dbo.Facture", t => t.FactureId)
                .Index(t => t.FactureId)
                .Index(t => t.TemplateId)
                .Index(t => t.Worker_Id);
            
            CreateTable(
                "dbo.MailerSmser",
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
                .ForeignKey("dbo.User", t => t.EditorId)
                .Index(t => t.EditorId)
                .Index(t => t.Installment_Id);
            
            CreateTable(
                "dbo.Template",
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
                .ForeignKey("dbo.User", t => t.LastEditor)
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
                .ForeignKey("dbo.Facture", t => t.FactureId)
                .Index(t => t.FactureId);
            
            CreateTable(
                "dbo.Warehouse",
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
                .ForeignKey("dbo.MainWarehouse", t => t.MainWarehoseId)
                .ForeignKey("dbo.Club", t => t.ClubId)
                .ForeignKey("dbo.User", t => t.LastEditor)
                .Index(t => t.ClubId)
                .Index(t => t.MainWarehoseId)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.MainWarehouse",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TypeOf = c.Short(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.LastEditor)
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
                .ForeignKey("dbo.Contractor", t => t.ContractorId)
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
                .ForeignKey("dbo.Deal", t => t.DealId)
                .ForeignKey("dbo.Contractor", t => t.ContractorId)
                .ForeignKey("dbo.User", t => t.UserId)
                .ForeignKey("dbo.User", t => t.CreatorId)
                .ForeignKey("dbo.User", t => t.LastEditor)
                .Index(t => t.UserId)
                .Index(t => t.ContractorId)
                .Index(t => t.CreatorId)
                .Index(t => t.LastEditor)
                .Index(t => t.DealId);
            
            CreateTable(
                "dbo.Deal",
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
                .ForeignKey("dbo.Contractor", t => t.ContractorId)
                .ForeignKey("dbo.User", t => t.CreatorId)
                .ForeignKey("dbo.User", t => t.LastEditor)
                .ForeignKey("dbo.User", t => t.DealMenagerId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ContractorId)
                .Index(t => t.CreatorId)
                .Index(t => t.DealMenagerId)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.DealComment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Text = c.String(nullable: false),
                        DealId = c.Int(nullable: false),
                        CreatorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deal", t => t.DealId)
                .ForeignKey("dbo.User", t => t.CreatorId)
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
                .ForeignKey("dbo.Deal", t => t.DealId)
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
                .ForeignKey("dbo.Deal", t => t.DealId)
                .ForeignKey("dbo.Contractor", t => t.ContractorId)
                .ForeignKey("dbo.User", t => t.WorkerId)
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
                .ForeignKey("dbo.Club", t => t.ClubKey)
                .ForeignKey("dbo.User", t => t.LastEditor)
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
                .ForeignKey("dbo.User", t => t.LastEditor)
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
                .ForeignKey("dbo.User", t => t.WorkerId)
                .Index(t => t.TagId)
                .Index(t => t.WorkerId);
            
            CreateTable(
                "dbo.Contract",
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
                .ForeignKey("dbo.User", t => t.WorkerId)
                .ForeignKey("dbo.User", t => t.LastEditor)
                .Index(t => t.WorkerId)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.HelpDeskPartialHistory",
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
                .ForeignKey("dbo.Helpdesk", t => t.HelpdeskId)
                .ForeignKey("dbo.User", t => t.WorkerId)
                .ForeignKey("dbo.User", t => t.RecipientId)
                .Index(t => t.HelpdeskId)
                .Index(t => t.WorkerId)
                .Index(t => t.RecipientId);
            
            CreateTable(
                "dbo.Helpdesk",
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
                .ForeignKey("dbo.User", t => t.WorkerId)
                .ForeignKey("dbo.User", t => t.RecipientId)
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
                .ForeignKey("dbo.Helpdesk", t => t.HelpdeskId)
                .ForeignKey("dbo.HelpDeskPartialHistory", t => t.HelpDeskPartialHistoryId)
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
                .ForeignKey("dbo.User", t => t.LastEditor)
                .Index(t => t.LastEditor);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.LastEditor)
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
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.DeliveryFactures",
                c => new
                    {
                        DeliverySets_Id = c.Int(nullable: false),
                        FactureSets_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DeliverySets_Id, t.FactureSets_Id })
                .ForeignKey("dbo.Delivery", t => t.DeliverySets_Id, cascadeDelete: true)
                .ForeignKey("dbo.Facture", t => t.FactureSets_Id, cascadeDelete: true)
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
                .ForeignKey("dbo.ListOfItems", t => t.ListOfItemsSets_Id, cascadeDelete: true)
                .ForeignKey("dbo.Delivery", t => t.DeliverySets_Id, cascadeDelete: true)
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
                .ForeignKey("dbo.Facture", t => t.FactureSets_Id, cascadeDelete: true)
                .ForeignKey("dbo.ListOfItems", t => t.ListOfItemsSets_Id, cascadeDelete: true)
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
                .ForeignKey("dbo.ExTypes", t => t.ExTypesSets_Id, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomsSets_Id, cascadeDelete: true)
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
                .ForeignKey("dbo.Exercise", t => t.ExerciseId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.WorkerId, cascadeDelete: true)
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
                .ForeignKey("dbo.Discount", t => t.DiscountSets_Id, cascadeDelete: true)
                .ForeignKey("dbo.Packages", t => t.PackagesSets_Id, cascadeDelete: true)
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
                .ForeignKey("dbo.MailerSmser", t => t.MailerSmserSets_Id, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserSets_Id, cascadeDelete: true)
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
                .ForeignKey("dbo.Facture", t => t.FactureSets_Id, cascadeDelete: true)
                .ForeignKey("dbo.Warehouse", t => t.WarehouseSets_Id, cascadeDelete: true)
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
                .ForeignKey("dbo.Club", t => t.ClubId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.WorkerId, cascadeDelete: true)
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
                .ForeignKey("dbo.Role", t => t.RoleSets_Id, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserSets_Id, cascadeDelete: true)
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
                .ForeignKey("dbo.Permissions", t => t.PermissionsSets_Id, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleSets_Id, cascadeDelete: true)
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
                .ForeignKey("dbo.User", t => t.UserSets_Id, cascadeDelete: true)
                .ForeignKey("dbo.Permissions", t => t.PermissionsSets_Id, cascadeDelete: true)
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
                .ForeignKey("dbo.BankAccount", t => t.BankAccountSets_Id, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserSets_Id, cascadeDelete: true)
                .Index(t => t.BankAccountSets_Id)
                .Index(t => t.UserSets_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "SecondAddress", "dbo.Address");
            DropForeignKey("dbo.Contractor", "SecondAddress", "dbo.Address");
            DropForeignKey("dbo.User", "MainAddress", "dbo.Address");
            DropForeignKey("dbo.Contractor", "MainAddress", "dbo.Address");
            DropForeignKey("dbo.Club", "AddressId", "dbo.Address");
            DropForeignKey("dbo.BankAccount", "AddressId", "dbo.Address");
            DropForeignKey("dbo.AccountUsers", "UserSets_Id", "dbo.User");
            DropForeignKey("dbo.AccountUsers", "BankAccountSets_Id", "dbo.BankAccount");
            DropForeignKey("dbo.Warehouse", "LastEditor", "dbo.User");
            DropForeignKey("dbo.User", "ReferId", "dbo.User");
            DropForeignKey("dbo.UserFileTables", "UserId", "dbo.User");
            DropForeignKey("dbo.User", "LastEditor", "dbo.User");
            DropForeignKey("dbo.Template", "LastEditor", "dbo.User");
            DropForeignKey("dbo.Tasks", "WorkerId", "dbo.User");
            DropForeignKey("dbo.Tags", "WorkerId", "dbo.User");
            DropForeignKey("dbo.Rooms", "LastEditor", "dbo.User");
            DropForeignKey("dbo.Role", "LastEditor", "dbo.User");
            DropForeignKey("dbo.Resources", "LastEditor", "dbo.User");
            DropForeignKey("dbo.Permissions", "LastEditor", "dbo.User");
            DropForeignKey("dbo.UsersPermissions", "PermissionsSets_Id", "dbo.Permissions");
            DropForeignKey("dbo.UsersPermissions", "UserSets_Id", "dbo.User");
            DropForeignKey("dbo.RolePermissions", "RoleSets_Id", "dbo.Role");
            DropForeignKey("dbo.RolePermissions", "PermissionsSets_Id", "dbo.Permissions");
            DropForeignKey("dbo.UsersRoles", "UserSets_Id", "dbo.User");
            DropForeignKey("dbo.UsersRoles", "RoleSets_Id", "dbo.Role");
            DropForeignKey("dbo.Packages", "LastEditor", "dbo.User");
            DropForeignKey("dbo.News", "WorkerId", "dbo.User");
            DropForeignKey("dbo.MainWarehouse", "LastEditor", "dbo.User");
            DropForeignKey("dbo.MailerSmser", "EditorId", "dbo.User");
            DropForeignKey("dbo.ListOfItems", "LastEditor", "dbo.User");
            DropForeignKey("dbo.Incomes", "LastEditor", "dbo.User");
            DropForeignKey("dbo.Incomes", "UserId", "dbo.User");
            DropForeignKey("dbo.Helpdesk", "RecipientId", "dbo.User");
            DropForeignKey("dbo.HelpDeskPartialHistory", "RecipientId", "dbo.User");
            DropForeignKey("dbo.Helpdesk", "WorkerId", "dbo.User");
            DropForeignKey("dbo.HelpDeskPartialHistory", "WorkerId", "dbo.User");
            DropForeignKey("dbo.HelpdeskFileTables", "HelpDeskPartialHistoryId", "dbo.HelpDeskPartialHistory");
            DropForeignKey("dbo.HelpdeskFileTables", "HelpdeskId", "dbo.Helpdesk");
            DropForeignKey("dbo.HelpDeskPartialHistory", "HelpdeskId", "dbo.Helpdesk");
            DropForeignKey("dbo.FormQuestions", "LastEditor", "dbo.User");
            DropForeignKey("dbo.Forms", "LastEditor", "dbo.User");
            DropForeignKey("dbo.FormDevices", "LastEditor", "dbo.User");
            DropForeignKey("dbo.FormAnswers", "UserId", "dbo.User");
            DropForeignKey("dbo.Facture", "UpUserId", "dbo.User");
            DropForeignKey("dbo.Facture", "UserId", "dbo.User");
            DropForeignKey("dbo.Facture", "LastEditor", "dbo.User");
            DropForeignKey("dbo.Facture", "CrUserId", "dbo.User");
            DropForeignKey("dbo.ExTypes", "LastEditor", "dbo.User");
            DropForeignKey("dbo.ExerciseReports", "LastEditor", "dbo.User");
            DropForeignKey("dbo.ExerciseReports", "UserId", "dbo.User");
            DropForeignKey("dbo.Exercise", "LastEditor", "dbo.User");
            DropForeignKey("dbo.Discount", "LastEditor", "dbo.User");
            DropForeignKey("dbo.Devices", "CreatorId", "dbo.User");
            DropForeignKey("dbo.Delivery", "LastEditor", "dbo.User");
            DropForeignKey("dbo.Deal", "UserId", "dbo.User");
            DropForeignKey("dbo.Deal", "DealMenagerId", "dbo.User");
            DropForeignKey("dbo.Deal", "LastEditor", "dbo.User");
            DropForeignKey("dbo.Deal", "CreatorId", "dbo.User");
            DropForeignKey("dbo.DealComment", "CreatorId", "dbo.User");
            DropForeignKey("dbo.DealActions", "LastEditor", "dbo.User");
            DropForeignKey("dbo.DealActions", "CreatorId", "dbo.User");
            DropForeignKey("dbo.DealActions", "UserId", "dbo.User");
            DropForeignKey("dbo.CountMachines", "LastEditor", "dbo.User");
            DropForeignKey("dbo.Contractor", "LastEditor", "dbo.User");
            DropForeignKey("dbo.Contract", "LastEditor", "dbo.User");
            DropForeignKey("dbo.Contract", "WorkerId", "dbo.User");
            DropForeignKey("dbo.Contact", "UserId", "dbo.User");
            DropForeignKey("dbo.Contact", "LastEditor", "dbo.User");
            DropForeignKey("dbo.Club", "LastEditor", "dbo.User");
            DropForeignKey("dbo.BoughtPackages", "UserId", "dbo.User");
            DropForeignKey("dbo.BoughtPackages", "LastEditor", "dbo.User");
            DropForeignKey("dbo.BankAccount", "LastEditor", "dbo.User");
            DropForeignKey("dbo.Announcement", "LastEditor", "dbo.User");
            DropForeignKey("dbo.News", "TagId", "dbo.Tags");
            DropForeignKey("dbo.Forms", "TagId", "dbo.Tags");
            DropForeignKey("dbo.FormQuestions", "FormId", "dbo.Forms");
            DropForeignKey("dbo.FormDevices", "FormId", "dbo.Forms");
            DropForeignKey("dbo.FormDevices", "DeviceId", "dbo.Devices");
            DropForeignKey("dbo.WorkersClubs", "WorkerId", "dbo.User");
            DropForeignKey("dbo.WorkersClubs", "ClubId", "dbo.Club");
            DropForeignKey("dbo.CountMachines", "ClubKey", "dbo.Club");
            DropForeignKey("dbo.CountMachines", "ResourcesKey", "dbo.Resources");
            DropForeignKey("dbo.Devices", "ClubId", "dbo.Club");
            DropForeignKey("dbo.Warehouse", "ClubId", "dbo.Club");
            DropForeignKey("dbo.Rooms", "ClubId", "dbo.Club");
            DropForeignKey("dbo.Facture", "ClubId", "dbo.Club");
            DropForeignKey("dbo.Contact", "ClubId", "dbo.Club");
            DropForeignKey("dbo.Tasks", "ContractorId", "dbo.Contractor");
            DropForeignKey("dbo.Incomes", "ContractorId", "dbo.Contractor");
            DropForeignKey("dbo.Deal", "ContractorId", "dbo.Contractor");
            DropForeignKey("dbo.DealActions", "ContractorId", "dbo.Contractor");
            DropForeignKey("dbo.Tasks", "DealId", "dbo.Deal");
            DropForeignKey("dbo.DealFileTables", "DealId", "dbo.Deal");
            DropForeignKey("dbo.DealComment", "DealId", "dbo.Deal");
            DropForeignKey("dbo.DealActions", "DealId", "dbo.Deal");
            DropForeignKey("dbo.User", "ContractorId", "dbo.Contractor");
            DropForeignKey("dbo.ContractorFileTables", "ContractorId", "dbo.Contractor");
            DropForeignKey("dbo.Facture", "ContractorId", "dbo.Contractor");
            DropForeignKey("dbo.WarehouseFactures", "WarehouseSets_Id", "dbo.Warehouse");
            DropForeignKey("dbo.WarehouseFactures", "FactureSets_Id", "dbo.Facture");
            DropForeignKey("dbo.Warehouse", "MainWarehoseId", "dbo.MainWarehouse");
            DropForeignKey("dbo.Outcomes", "FactureId", "dbo.Facture");
            DropForeignKey("dbo.Loads", "FactureId", "dbo.Facture");
            DropForeignKey("dbo.Incomes", "FactureId", "dbo.Facture");
            DropForeignKey("dbo.User", "MoneyboxId", "dbo.Moneybox");
            DropForeignKey("dbo.Payoff", "MoneyboxId", "dbo.Moneybox");
            DropForeignKey("dbo.Loads", "Worker_Id", "dbo.User");
            DropForeignKey("dbo.Loads", "TemplateId", "dbo.Template");
            DropForeignKey("dbo.Payoff", "LoadsId", "dbo.Loads");
            DropForeignKey("dbo.MailSmsRecipients", "UserSets_Id", "dbo.User");
            DropForeignKey("dbo.MailSmsRecipients", "MailerSmserSets_Id", "dbo.MailerSmser");
            DropForeignKey("dbo.MailerSmser", "Installment_Id", "dbo.Loads");
            DropForeignKey("dbo.Payoff", "IncomesId", "dbo.Incomes");
            DropForeignKey("dbo.Incomes", "MoneyboxId", "dbo.Moneybox");
            DropForeignKey("dbo.FactureFileTables", "FactureId", "dbo.Facture");
            DropForeignKey("dbo.BoughtPackages", "FactureId", "dbo.Facture");
            DropForeignKey("dbo.PackagesDiscounts", "PackagesSets_Id", "dbo.Packages");
            DropForeignKey("dbo.PackagesDiscounts", "DiscountSets_Id", "dbo.Discount");
            DropForeignKey("dbo.Exercise", "PackagesId", "dbo.Packages");
            DropForeignKey("dbo.ExerciseLeaders", "WorkerId", "dbo.User");
            DropForeignKey("dbo.ExerciseLeaders", "ExerciseId", "dbo.Exercise");
            DropForeignKey("dbo.ExerciseReports", "ExerciseId", "dbo.Exercise");
            DropForeignKey("dbo.Exercise", "RoomsId", "dbo.Rooms");
            DropForeignKey("dbo.RoomsExTypes", "RoomsSets_Id", "dbo.Rooms");
            DropForeignKey("dbo.RoomsExTypes", "ExTypesSets_Id", "dbo.ExTypes");
            DropForeignKey("dbo.Exercise", "ExTypesKey", "dbo.ExTypes");
            DropForeignKey("dbo.BoughtPackages", "PackagesId", "dbo.Packages");
            DropForeignKey("dbo.ItemsOnFacture", "ListOfItemsSets_Id", "dbo.ListOfItems");
            DropForeignKey("dbo.ItemsOnFacture", "FactureSets_Id", "dbo.Facture");
            DropForeignKey("dbo.DeliveriedItems", "DeliverySets_Id", "dbo.Delivery");
            DropForeignKey("dbo.DeliveriedItems", "ListOfItemsSets_Id", "dbo.ListOfItems");
            DropForeignKey("dbo.DeliveryFactures", "FactureSets_Id", "dbo.Facture");
            DropForeignKey("dbo.DeliveryFactures", "DeliverySets_Id", "dbo.Delivery");
            DropForeignKey("dbo.Contact", "ContractorId", "dbo.Contractor");
            DropForeignKey("dbo.FormAnswers", "FormsId", "dbo.Forms");
            DropForeignKey("dbo.FormAnswers", "FormQuestionId", "dbo.FormQuestions");
            DropForeignKey("dbo.Announcement", "TagId", "dbo.Tags");
            DropForeignKey("dbo.Address", "LastEditor", "dbo.User");
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
            DropIndex("dbo.Role", new[] { "LastEditor" });
            DropIndex("dbo.Permissions", new[] { "LastEditor" });
            DropIndex("dbo.HelpdeskFileTables", new[] { "HelpDeskPartialHistoryId" });
            DropIndex("dbo.HelpdeskFileTables", new[] { "HelpdeskId" });
            DropIndex("dbo.Helpdesk", new[] { "WorkerId" });
            DropIndex("dbo.Helpdesk", new[] { "RecipientId" });
            DropIndex("dbo.HelpDeskPartialHistory", new[] { "RecipientId" });
            DropIndex("dbo.HelpDeskPartialHistory", new[] { "WorkerId" });
            DropIndex("dbo.HelpDeskPartialHistory", new[] { "HelpdeskId" });
            DropIndex("dbo.Contract", new[] { "LastEditor" });
            DropIndex("dbo.Contract", new[] { "WorkerId" });
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
            DropIndex("dbo.DealComment", new[] { "CreatorId" });
            DropIndex("dbo.DealComment", new[] { "DealId" });
            DropIndex("dbo.Deal", new[] { "LastEditor" });
            DropIndex("dbo.Deal", new[] { "DealMenagerId" });
            DropIndex("dbo.Deal", new[] { "CreatorId" });
            DropIndex("dbo.Deal", new[] { "ContractorId" });
            DropIndex("dbo.Deal", new[] { "UserId" });
            DropIndex("dbo.DealActions", new[] { "DealId" });
            DropIndex("dbo.DealActions", new[] { "LastEditor" });
            DropIndex("dbo.DealActions", new[] { "CreatorId" });
            DropIndex("dbo.DealActions", new[] { "ContractorId" });
            DropIndex("dbo.DealActions", new[] { "UserId" });
            DropIndex("dbo.ContractorFileTables", new[] { "ContractorId" });
            DropIndex("dbo.MainWarehouse", new[] { "LastEditor" });
            DropIndex("dbo.Warehouse", new[] { "LastEditor" });
            DropIndex("dbo.Warehouse", new[] { "MainWarehoseId" });
            DropIndex("dbo.Warehouse", new[] { "ClubId" });
            DropIndex("dbo.Outcomes", new[] { "FactureId" });
            DropIndex("dbo.Template", new[] { "LastEditor" });
            DropIndex("dbo.MailerSmser", new[] { "Installment_Id" });
            DropIndex("dbo.MailerSmser", new[] { "EditorId" });
            DropIndex("dbo.Loads", new[] { "Worker_Id" });
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
            DropIndex("dbo.Discount", new[] { "LastEditor" });
            DropIndex("dbo.ExerciseReports", new[] { "LastEditor" });
            DropIndex("dbo.ExerciseReports", new[] { "UserId" });
            DropIndex("dbo.ExerciseReports", new[] { "ExerciseId" });
            DropIndex("dbo.ExTypes", new[] { "LastEditor" });
            DropIndex("dbo.Rooms", new[] { "LastEditor" });
            DropIndex("dbo.Rooms", new[] { "ClubId" });
            DropIndex("dbo.Exercise", new[] { "LastEditor" });
            DropIndex("dbo.Exercise", new[] { "ExTypesKey" });
            DropIndex("dbo.Exercise", new[] { "PackagesId" });
            DropIndex("dbo.Exercise", new[] { "RoomsId" });
            DropIndex("dbo.Packages", new[] { "LastEditor" });
            DropIndex("dbo.BoughtPackages", new[] { "FactureId" });
            DropIndex("dbo.BoughtPackages", new[] { "LastEditor" });
            DropIndex("dbo.BoughtPackages", new[] { "UserId" });
            DropIndex("dbo.BoughtPackages", new[] { "PackagesId" });
            DropIndex("dbo.Delivery", new[] { "LastEditor" });
            DropIndex("dbo.ListOfItems", new[] { "LastEditor" });
            DropIndex("dbo.Facture", new[] { "ClubId" });
            DropIndex("dbo.Facture", new[] { "UserId" });
            DropIndex("dbo.Facture", new[] { "LastEditor" });
            DropIndex("dbo.Facture", new[] { "UpUserId" });
            DropIndex("dbo.Facture", new[] { "CrUserId" });
            DropIndex("dbo.Facture", new[] { "ContractorId" });
            DropIndex("dbo.Contractor", new[] { "LastEditor" });
            DropIndex("dbo.Contractor", new[] { "SecondAddress" });
            DropIndex("dbo.Contractor", new[] { "MainAddress" });
            DropIndex("dbo.Contact", new[] { "LastEditor" });
            DropIndex("dbo.Contact", new[] { "ClubId" });
            DropIndex("dbo.Contact", new[] { "UserId" });
            DropIndex("dbo.Contact", new[] { "ContractorId" });
            DropIndex("dbo.Club", new[] { "LastEditor" });
            DropIndex("dbo.Club", new[] { "AddressId" });
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
            DropIndex("dbo.Announcement", new[] { "LastEditor" });
            DropIndex("dbo.Announcement", new[] { "TagId" });
            DropIndex("dbo.User", new[] { "MoneyboxId" });
            DropIndex("dbo.User", new[] { "LastEditor" });
            DropIndex("dbo.User", new[] { "ContractorId" });
            DropIndex("dbo.User", new[] { "ReferId" });
            DropIndex("dbo.User", new[] { "SecondAddress" });
            DropIndex("dbo.User", new[] { "MainAddress" });
            DropIndex("dbo.BankAccount", new[] { "LastEditor" });
            DropIndex("dbo.BankAccount", new[] { "AddressId" });
            DropIndex("dbo.Address", new[] { "LastEditor" });
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
            DropTable("dbo.Role");
            DropTable("dbo.Permissions");
            DropTable("dbo.HelpdeskFileTables");
            DropTable("dbo.Helpdesk");
            DropTable("dbo.HelpDeskPartialHistory");
            DropTable("dbo.Contract");
            DropTable("dbo.News");
            DropTable("dbo.Resources");
            DropTable("dbo.CountMachines");
            DropTable("dbo.Tasks");
            DropTable("dbo.DealFileTables");
            DropTable("dbo.DealComment");
            DropTable("dbo.Deal");
            DropTable("dbo.DealActions");
            DropTable("dbo.ContractorFileTables");
            DropTable("dbo.MainWarehouse");
            DropTable("dbo.Warehouse");
            DropTable("dbo.Outcomes");
            DropTable("dbo.Template");
            DropTable("dbo.MailerSmser");
            DropTable("dbo.Loads");
            DropTable("dbo.Payoff");
            DropTable("dbo.Moneybox");
            DropTable("dbo.Incomes");
            DropTable("dbo.FactureFileTables");
            DropTable("dbo.Discount");
            DropTable("dbo.ExerciseReports");
            DropTable("dbo.ExTypes");
            DropTable("dbo.Rooms");
            DropTable("dbo.Exercise");
            DropTable("dbo.Packages");
            DropTable("dbo.BoughtPackages");
            DropTable("dbo.Delivery");
            DropTable("dbo.ListOfItems");
            DropTable("dbo.Facture");
            DropTable("dbo.Contractor");
            DropTable("dbo.Contact");
            DropTable("dbo.Club");
            DropTable("dbo.Devices");
            DropTable("dbo.FormDevices");
            DropTable("dbo.FormQuestions");
            DropTable("dbo.FormAnswers");
            DropTable("dbo.Forms");
            DropTable("dbo.Tags");
            DropTable("dbo.Announcement");
            DropTable("dbo.User");
            DropTable("dbo.BankAccount");
            DropTable("dbo.Address");
        }
    }
}
