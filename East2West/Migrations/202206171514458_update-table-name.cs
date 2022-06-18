namespace East2West.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetablename : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CarBrand", newName: "CarBrands");
            RenameTable(name: "dbo.CarModel", newName: "CarModels");
            RenameTable(name: "dbo.Car", newName: "Cars");
            RenameTable(name: "dbo.CarSchedule", newName: "CarSchedules");
            RenameTable(name: "dbo.CarType", newName: "CarTypes");
            RenameTable(name: "dbo.Location", newName: "Locations");
            RenameTable(name: "dbo.Flight", newName: "Flights");
            RenameTable(name: "dbo.Hotel", newName: "Hotels");
            RenameTable(name: "dbo.Tour", newName: "Tours");
            RenameTable(name: "dbo.TourDetail", newName: "TourDetails");
            RenameTable(name: "dbo.TourSchedule", newName: "TourSchedules");
            RenameTable(name: "dbo.Feedback", newName: "Feedbacks");
            RenameTable(name: "dbo.OrderCar", newName: "OrderCars");
            RenameTable(name: "dbo.Order", newName: "Orders");
            RenameTable(name: "dbo.OrderTour", newName: "OrderTours");
            RenameTable(name: "dbo.Refund", newName: "Refunds");
            RenameTable(name: "dbo.User", newName: "Users");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Users", newName: "User");
            RenameTable(name: "dbo.Refunds", newName: "Refund");
            RenameTable(name: "dbo.OrderTours", newName: "OrderTour");
            RenameTable(name: "dbo.Orders", newName: "Order");
            RenameTable(name: "dbo.OrderCars", newName: "OrderCar");
            RenameTable(name: "dbo.Feedbacks", newName: "Feedback");
            RenameTable(name: "dbo.TourSchedules", newName: "TourSchedule");
            RenameTable(name: "dbo.TourDetails", newName: "TourDetail");
            RenameTable(name: "dbo.Tours", newName: "Tour");
            RenameTable(name: "dbo.Hotels", newName: "Hotel");
            RenameTable(name: "dbo.Flights", newName: "Flight");
            RenameTable(name: "dbo.Locations", newName: "Location");
            RenameTable(name: "dbo.CarTypes", newName: "CarType");
            RenameTable(name: "dbo.CarSchedules", newName: "CarSchedule");
            RenameTable(name: "dbo.Cars", newName: "Car");
            RenameTable(name: "dbo.CarModels", newName: "CarModel");
            RenameTable(name: "dbo.CarBrands", newName: "CarBrand");
        }
    }
}
