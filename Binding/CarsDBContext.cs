using Microsoft.EntityFrameworkCore;
using Models;
using System;

namespace Binding
{
    public class CarsDBContext : DbContext
    {
        public DbSet<Car> cars { get; set; }
        public DbSet<Modelcar> modelcars { get; set; }
        public CarsDBContext(DbContextOptions<CarsDBContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Modelcar>().HasData(
                new Modelcar
                {
                    Id = 1,
                    ModelName = "BMW"
                },
                new Modelcar
                {
                    Id = 2,
                    ModelName = "Opel"
                },
                new Modelcar
                {
                    Id = 3,
                    ModelName = "Renault"
                }

            );
            modelBuilder.Entity<Car>().HasData(
               new Car
               {
                   Id = 1,
                   Colour = "#957365",
                   Quantity = 20,
                   Price = 15000,
                   DateTimeNewCar = new DateTime(),
                   ModelcarId = 1
                
               },
               new Car
               {
                   Id = 2,
                   Colour = "#39bdea",
                   Quantity = 10,
                   Price = 150000,
                   DateTimeNewCar = new DateTime(),
                   ModelcarId = 2
               },
               new Car
               {
                   Id = 3,
                   Colour = "#32110d",
                   Quantity = 5,
                   Price = 25000,
                   DateTimeNewCar = new DateTime(),
                   ModelcarId = 3
               }


          );

        }
    }
}
