namespace East2West.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bigupdatedb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarBrands",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        CarBrandId = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarBrands", t => t.CarBrandId, cascadeDelete: true)
                .Index(t => t.CarBrandId);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        CarModelId = c.String(nullable: false, maxLength: 50),
                        CarTypeId = c.String(nullable: false, maxLength: 50),
                        LocationId = c.String(nullable: false, maxLength: 50),
                        Thumbnail = c.String(nullable: false, storeType: "ntext"),
                        LisencePlate = c.String(nullable: false, maxLength: 50),
                        HasAirConditioner = c.Boolean(nullable: false),
                        SeatCapacity = c.Int(nullable: false),
                        PricePerDay = c.Double(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarModels", t => t.CarModelId, cascadeDelete: true)
                .ForeignKey("dbo.CarTypes", t => t.CarTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.CarModelId)
                .Index(t => t.CarTypeId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.CarSchedules",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        CarId = c.String(nullable: false, maxLength: 50),
                        StartDay = c.DateTime(nullable: false, storeType: "date"),
                        EndDay = c.DateTime(nullable: false, storeType: "date"),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.CarTypes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        Thumbnail = c.String(nullable: false, storeType: "ntext"),
                        IsRoundTicket = c.Boolean(nullable: false),
                        DepartureId = c.String(nullable: false, maxLength: 50),
                        DestinationId = c.String(nullable: false, maxLength: 50),
                        DepartureAt = c.DateTime(nullable: false),
                        Duration = c.String(nullable: false, maxLength: 50),
                        Price = c.Double(nullable: false),
                        ReturnAt = c.DateTime(nullable: false),
                        Detail = c.String(nullable: false, storeType: "ntext"),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.DepartureId)
                .ForeignKey("dbo.Locations", t => t.DestinationId)
                .Index(t => t.DepartureId)
                .Index(t => t.DestinationId);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        Thumbnail = c.String(nullable: false, storeType: "ntext"),
                        LocationId = c.String(nullable: false, maxLength: 50),
                        Rating = c.Double(nullable: false),
                        Name = c.String(nullable: false, storeType: "ntext"),
                        Address = c.String(nullable: false, storeType: "ntext"),
                        Price = c.Double(nullable: false),
                        Description = c.String(nullable: false, storeType: "ntext"),
                        Detail = c.String(nullable: false, storeType: "ntext"),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Tours",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        TourCategoryId = c.String(nullable: false, maxLength: 50),
                        DepartureId = c.String(nullable: false, maxLength: 50),
                        DestinationId = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, storeType: "ntext"),
                        Detail = c.String(nullable: false, storeType: "ntext"),
                        Thumbnail = c.String(nullable: false, storeType: "ntext"),
                        Duration = c.Int(nullable: false),
                        Rating = c.Double(nullable: false),
                        Policy = c.String(nullable: false, storeType: "ntext"),
                        SummarySchedule = c.String(nullable: false, storeType: "ntext"),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.DepartureId)
                .ForeignKey("dbo.Locations", t => t.DestinationId)
                .ForeignKey("dbo.TourCategories", t => t.TourCategoryId, cascadeDelete: true)
                .Index(t => t.TourCategoryId)
                .Index(t => t.DepartureId)
                .Index(t => t.DestinationId);
            
            CreateTable(
                "dbo.TourCategories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TourDetails",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        TourId = c.String(nullable: false, maxLength: 50),
                        DepartureDay = c.DateTime(nullable: false, storeType: "date"),
                        AvailableSeat = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Discount = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tours", t => t.TourId, cascadeDelete: true)
                .Index(t => t.TourId);
            
            CreateTable(
                "dbo.TourSchedules",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        TourId = c.String(nullable: false, maxLength: 50),
                        ScheduleOrder = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250),
                        Detail = c.String(nullable: false, storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tours", t => t.TourId, cascadeDelete: true)
                .Index(t => t.TourId);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        OrderId = c.String(nullable: false, maxLength: 50),
                        Rating = c.Double(nullable: false),
                        Title = c.String(nullable: false, storeType: "ntext"),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        UserId = c.String(nullable: false, maxLength: 128),
                        RefundId = c.String(maxLength: 50),
                        TotalPrice = c.Double(nullable: false),
                        Type = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.OrderCars",
                c => new
                    {
                        OrderId = c.String(nullable: false, maxLength: 50),
                        CarScheduleId = c.String(nullable: false, maxLength: 50),
                        UnitPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.CarScheduleId })
                .ForeignKey("dbo.CarSchedules", t => t.CarScheduleId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.CarScheduleId);
            
            CreateTable(
                "dbo.OrderTours",
                c => new
                    {
                        OrderId = c.String(nullable: false, maxLength: 50),
                        TourDetailId = c.String(nullable: false, maxLength: 50),
                        UnitPrice = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.TourDetailId })
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.TourDetails", t => t.TourDetailId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.TourDetailId);
            
            CreateTable(
                "dbo.Refunds",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        Percent = c.Int(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(),
                        Address = c.String(nullable: false, storeType: "ntext"),
                        Thumbnail = c.String(nullable: false, storeType: "ntext"),
                        Description = c.String(nullable: false, storeType: "ntext"),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Feedbacks", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Refunds", "Id", "dbo.Orders");
            DropForeignKey("dbo.OrderTours", "TourDetailId", "dbo.TourDetails");
            DropForeignKey("dbo.OrderTours", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderCars", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderCars", "CarScheduleId", "dbo.CarSchedules");
            DropForeignKey("dbo.TourSchedules", "TourId", "dbo.Tours");
            DropForeignKey("dbo.TourDetails", "TourId", "dbo.Tours");
            DropForeignKey("dbo.Tours", "TourCategoryId", "dbo.TourCategories");
            DropForeignKey("dbo.Tours", "DestinationId", "dbo.Locations");
            DropForeignKey("dbo.Tours", "DepartureId", "dbo.Locations");
            DropForeignKey("dbo.Hotels", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Flights", "DestinationId", "dbo.Locations");
            DropForeignKey("dbo.Flights", "DepartureId", "dbo.Locations");
            DropForeignKey("dbo.Cars", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Cars", "CarTypeId", "dbo.CarTypes");
            DropForeignKey("dbo.CarSchedules", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Cars", "CarModelId", "dbo.CarModels");
            DropForeignKey("dbo.CarModels", "CarBrandId", "dbo.CarBrands");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Refunds", new[] { "Id" });
            DropIndex("dbo.OrderTours", new[] { "TourDetailId" });
            DropIndex("dbo.OrderTours", new[] { "OrderId" });
            DropIndex("dbo.OrderCars", new[] { "CarScheduleId" });
            DropIndex("dbo.OrderCars", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Feedbacks", new[] { "OrderId" });
            DropIndex("dbo.TourSchedules", new[] { "TourId" });
            DropIndex("dbo.TourDetails", new[] { "TourId" });
            DropIndex("dbo.Tours", new[] { "DestinationId" });
            DropIndex("dbo.Tours", new[] { "DepartureId" });
            DropIndex("dbo.Tours", new[] { "TourCategoryId" });
            DropIndex("dbo.Hotels", new[] { "LocationId" });
            DropIndex("dbo.Flights", new[] { "DestinationId" });
            DropIndex("dbo.Flights", new[] { "DepartureId" });
            DropIndex("dbo.CarSchedules", new[] { "CarId" });
            DropIndex("dbo.Cars", new[] { "LocationId" });
            DropIndex("dbo.Cars", new[] { "CarTypeId" });
            DropIndex("dbo.Cars", new[] { "CarModelId" });
            DropIndex("dbo.CarModels", new[] { "CarBrandId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Refunds");
            DropTable("dbo.OrderTours");
            DropTable("dbo.OrderCars");
            DropTable("dbo.Orders");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.TourSchedules");
            DropTable("dbo.TourDetails");
            DropTable("dbo.TourCategories");
            DropTable("dbo.Tours");
            DropTable("dbo.Hotels");
            DropTable("dbo.Flights");
            DropTable("dbo.Locations");
            DropTable("dbo.CarTypes");
            DropTable("dbo.CarSchedules");
            DropTable("dbo.Cars");
            DropTable("dbo.CarModels");
            DropTable("dbo.CarBrands");
        }
    }
}
