namespace East2West.Migrations
{
    using East2West.Data;
    using East2West.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<East2West.Data.DBContext>
    {
        private DBContext db = new DBContext();

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        //LOCAL_1 = LocationID
        //TOUR_1 = TouID
        //TOURDT_1 = TourDetailId
        //TOURSD_1 = TourScheduleId
        //CARBR_1 = CarBrandId
        //CARMD_1 = CarModelId
        //CARTP_1 = CarTypeId
        //CAR_1 = CarId
        //HT_1 = HotelId
        //FL_1 = FlightId
        protected override void Seed(East2West.Data.DBContext context)
        {
        }
    }
}