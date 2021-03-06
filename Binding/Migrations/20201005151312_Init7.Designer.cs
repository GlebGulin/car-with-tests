﻿// <auto-generated />
using System;
using Binding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Binding.Migrations
{
    [DbContext(typeof(CarsDBContext))]
    [Migration("20201005151312_Init7")]
    partial class Init7
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Colour");

                    b.Property<DateTime>("DateTimeNewCar");

                    b.Property<int>("ModelcarId");

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("ModelcarId");

                    b.ToTable("cars");

                    b.HasData(
                        new { Id = 1, Colour = "#957365", DateTimeNewCar = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), ModelcarId = 1, Price = 15000m, Quantity = 20 },
                        new { Id = 2, Colour = "#39bdea", DateTimeNewCar = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), ModelcarId = 2, Price = 150000m, Quantity = 10 },
                        new { Id = 3, Colour = "#32110d", DateTimeNewCar = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), ModelcarId = 3, Price = 25000m, Quantity = 5 }
                    );
                });

            modelBuilder.Entity("Models.Modelcar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ModelName");

                    b.HasKey("Id");

                    b.ToTable("modelcars");

                    b.HasData(
                        new { Id = 1, ModelName = "BMW" },
                        new { Id = 2, ModelName = "Opel" },
                        new { Id = 3, ModelName = "Renault" }
                    );
                });

            modelBuilder.Entity("Models.Car", b =>
                {
                    b.HasOne("Models.Modelcar", "ModelOfCar")
                        .WithMany()
                        .HasForeignKey("ModelcarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
