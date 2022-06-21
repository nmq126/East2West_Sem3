using East2West.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace East2West.Data
{
    public class DBContext :  IdentityDbContext<User>
    {
        public DBContext()
            : base("name=DBContext")
        {
        }
        public DbSet<Car> Cars { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<TourSchedule> TourSchedules { get; set; }
        public DbSet<TourDetail> TourDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderCar> OrderCars { get; set; }
        public DbSet<OrderTour> OrderTours { get; set; }
        public DbSet<Refund> Refunds { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>()
                        .HasRequired(x => x.LocationDeparture)
                        .WithMany(x => x.FlightsDeparture)
                        .HasForeignKey(x => x.DepartureId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Flight>()
                        .HasRequired(x => x.LocationDestination)
                        .WithMany(x => x.FlightsDestination)
                        .HasForeignKey(x => x.DestinationId)
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<Tour>()
                       .HasRequired(x => x.LocationDeparture)
                       .WithMany(x => x.ToursDeparture)
                       .HasForeignKey(x => x.DepartureId)
                       .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tour>()
                        .HasRequired(x => x.LocationDestination)
                        .WithMany(x => x.ToursDestination)
                        .HasForeignKey(x => x.DestinationId)
                        .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}