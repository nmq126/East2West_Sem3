namespace East2West.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarBrand",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CarModel",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        CarBrandId = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarBrand", t => t.CarBrandId, cascadeDelete: true)
                .Index(t => t.CarBrandId);
            
            CreateTable(
                "dbo.Car",
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
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarModel", t => t.CarModelId, cascadeDelete: true)
                .ForeignKey("dbo.CarType", t => t.CarTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Location", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.CarModelId)
                .Index(t => t.CarTypeId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.CarSchedule",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        CarId = c.String(nullable: false, maxLength: 50),
                        StartDay = c.DateTime(nullable: false),
                        EndDay = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Car", t => t.CarId, cascadeDelete: true)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.CarType",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Flight",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
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
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Location", t => t.DepartureId)
                .ForeignKey("dbo.Location", t => t.DestinationId)
                .Index(t => t.DepartureId)
                .Index(t => t.DestinationId);
            
            CreateTable(
                "dbo.Hotel",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        LocaltionId = c.String(nullable: false, maxLength: 50),
                        Rating = c.Double(nullable: false),
                        Address = c.String(nullable: false, storeType: "ntext"),
                        Price = c.String(nullable: false),
                        Description = c.String(nullable: false, storeType: "ntext"),
                        Detail = c.String(nullable: false, storeType: "ntext"),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                        Location_Id = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Location", t => t.Location_Id)
                .Index(t => t.Location_Id);
            
            CreateTable(
                "dbo.Tour",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        DepartureId = c.String(nullable: false, maxLength: 50),
                        DestinationId = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, storeType: "ntext"),
                        Detail = c.String(nullable: false, storeType: "ntext"),
                        Thumbnail = c.String(nullable: false, storeType: "ntext"),
                        Duration = c.String(nullable: false, maxLength: 50),
                        Rating = c.Double(nullable: false),
                        Policy = c.String(nullable: false, storeType: "ntext"),
                        SummarySchedule = c.String(nullable: false, storeType: "ntext"),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Location", t => t.DepartureId)
                .ForeignKey("dbo.Location", t => t.DestinationId)
                .Index(t => t.DepartureId)
                .Index(t => t.DestinationId);
            
            CreateTable(
                "dbo.TourDetail",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        TourId = c.String(nullable: false, maxLength: 50),
                        DepartureDay = c.DateTime(nullable: false),
                        AvailableSeat = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Discount = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tour", t => t.TourId, cascadeDelete: true)
                .Index(t => t.TourId);
            
            CreateTable(
                "dbo.TourSchedule",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        TourId = c.String(nullable: false, maxLength: 50),
                        ScheduleOrder = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Detail = c.String(nullable: false, storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tour", t => t.TourId, cascadeDelete: true)
                .Index(t => t.TourId);
            
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        TourId = c.String(nullable: false, maxLength: 50),
                        CarId = c.String(nullable: false, maxLength: 50),
                        Rating = c.Double(nullable: false),
                        Title = c.String(nullable: false, storeType: "ntext"),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Car", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.Tour", t => t.TourId, cascadeDelete: true)
                .Index(t => t.TourId)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.OrderCar",
                c => new
                    {
                        OrderId = c.String(nullable: false, maxLength: 50),
                        CarScheduleId = c.String(nullable: false, maxLength: 50),
                        UnitPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.CarScheduleId })
                .ForeignKey("dbo.CarSchedule", t => t.CarScheduleId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.CarScheduleId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        UserId = c.String(nullable: false, maxLength: 50),
                        RefundId = c.String(maxLength: 50),
                        TotalPrice = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.OrderTour",
                c => new
                    {
                        OrderId = c.String(nullable: false, maxLength: 50),
                        TourDetailId = c.String(nullable: false, maxLength: 50),
                        UnitPrice = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.TourDetailId })
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.TourDetail", t => t.TourDetailId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.TourDetailId);
            
            CreateTable(
                "dbo.Refund",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        Percent = c.Int(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        UserName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 250),
                        Address = c.String(nullable: false, storeType: "ntext"),
                        Thumbnail = c.String(nullable: false, storeType: "ntext"),
                        Description = c.String(nullable: false, storeType: "ntext"),
                        PasswordHash = c.String(nullable: false, maxLength: 250),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "UserId", "dbo.User");
            DropForeignKey("dbo.Refund", "Id", "dbo.Order");
            DropForeignKey("dbo.OrderTour", "TourDetailId", "dbo.TourDetail");
            DropForeignKey("dbo.OrderTour", "OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderCar", "OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderCar", "CarScheduleId", "dbo.CarSchedule");
            DropForeignKey("dbo.Feedback", "TourId", "dbo.Tour");
            DropForeignKey("dbo.Feedback", "CarId", "dbo.Car");
            DropForeignKey("dbo.TourSchedule", "TourId", "dbo.Tour");
            DropForeignKey("dbo.TourDetail", "TourId", "dbo.Tour");
            DropForeignKey("dbo.Tour", "DestinationId", "dbo.Location");
            DropForeignKey("dbo.Tour", "DepartureId", "dbo.Location");
            DropForeignKey("dbo.Hotel", "Location_Id", "dbo.Location");
            DropForeignKey("dbo.Flight", "DestinationId", "dbo.Location");
            DropForeignKey("dbo.Flight", "DepartureId", "dbo.Location");
            DropForeignKey("dbo.Car", "LocationId", "dbo.Location");
            DropForeignKey("dbo.Car", "CarTypeId", "dbo.CarType");
            DropForeignKey("dbo.CarSchedule", "CarId", "dbo.Car");
            DropForeignKey("dbo.Car", "CarModelId", "dbo.CarModel");
            DropForeignKey("dbo.CarModel", "CarBrandId", "dbo.CarBrand");
            DropIndex("dbo.Refund", new[] { "Id" });
            DropIndex("dbo.OrderTour", new[] { "TourDetailId" });
            DropIndex("dbo.OrderTour", new[] { "OrderId" });
            DropIndex("dbo.Order", new[] { "UserId" });
            DropIndex("dbo.OrderCar", new[] { "CarScheduleId" });
            DropIndex("dbo.OrderCar", new[] { "OrderId" });
            DropIndex("dbo.Feedback", new[] { "CarId" });
            DropIndex("dbo.Feedback", new[] { "TourId" });
            DropIndex("dbo.TourSchedule", new[] { "TourId" });
            DropIndex("dbo.TourDetail", new[] { "TourId" });
            DropIndex("dbo.Tour", new[] { "DestinationId" });
            DropIndex("dbo.Tour", new[] { "DepartureId" });
            DropIndex("dbo.Hotel", new[] { "Location_Id" });
            DropIndex("dbo.Flight", new[] { "DestinationId" });
            DropIndex("dbo.Flight", new[] { "DepartureId" });
            DropIndex("dbo.CarSchedule", new[] { "CarId" });
            DropIndex("dbo.Car", new[] { "LocationId" });
            DropIndex("dbo.Car", new[] { "CarTypeId" });
            DropIndex("dbo.Car", new[] { "CarModelId" });
            DropIndex("dbo.CarModel", new[] { "CarBrandId" });
            DropTable("dbo.User");
            DropTable("dbo.Refund");
            DropTable("dbo.OrderTour");
            DropTable("dbo.Order");
            DropTable("dbo.OrderCar");
            DropTable("dbo.Feedback");
            DropTable("dbo.TourSchedule");
            DropTable("dbo.TourDetail");
            DropTable("dbo.Tour");
            DropTable("dbo.Hotel");
            DropTable("dbo.Flight");
            DropTable("dbo.Location");
            DropTable("dbo.CarType");
            DropTable("dbo.CarSchedule");
            DropTable("dbo.Car");
            DropTable("dbo.CarModel");
            DropTable("dbo.CarBrand");
        }
    }
}
