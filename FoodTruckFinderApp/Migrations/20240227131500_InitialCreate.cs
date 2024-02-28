using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTruckFinderApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodTrucks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNN = table.Column<int>(type: "int", nullable: false),
                    X = table.Column<double>(type: "float", nullable: false),
                    Y = table.Column<double>(type: "float", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    PriorPermit = table.Column<bool>(type: "bit", nullable: false),
                    Applicant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacilityType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    blocklot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    block = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    permit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodItems = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Schedule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dayshours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NOISent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Approved = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Received = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTrucks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodTrucks");
        }
    }
}
