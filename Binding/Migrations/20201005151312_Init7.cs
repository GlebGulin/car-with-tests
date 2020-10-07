using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Binding.Migrations
{
    public partial class Init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "modelcars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ModelName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modelcars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Colour = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    DateTimeNewCar = table.Column<DateTime>(nullable: false),
                    ModelcarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cars_modelcars_ModelcarId",
                        column: x => x.ModelcarId,
                        principalTable: "modelcars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "modelcars",
                columns: new[] { "Id", "ModelName" },
                values: new object[] { 1, "BMW" });

            migrationBuilder.InsertData(
                table: "modelcars",
                columns: new[] { "Id", "ModelName" },
                values: new object[] { 2, "Opel" });

            migrationBuilder.InsertData(
                table: "modelcars",
                columns: new[] { "Id", "ModelName" },
                values: new object[] { 3, "Renault" });

            migrationBuilder.InsertData(
                table: "cars",
                columns: new[] { "Id", "Colour", "DateTimeNewCar", "ModelcarId", "Price", "Quantity" },
                values: new object[] { 1, "#957365", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 15000m, 20 });

            migrationBuilder.InsertData(
                table: "cars",
                columns: new[] { "Id", "Colour", "DateTimeNewCar", "ModelcarId", "Price", "Quantity" },
                values: new object[] { 2, "#39bdea", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 150000m, 10 });

            migrationBuilder.InsertData(
                table: "cars",
                columns: new[] { "Id", "Colour", "DateTimeNewCar", "ModelcarId", "Price", "Quantity" },
                values: new object[] { 3, "#32110d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 25000m, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_cars_ModelcarId",
                table: "cars",
                column: "ModelcarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "modelcars");
        }
    }
}
