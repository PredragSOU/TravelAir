using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAir.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.CreateTable(
                name: "CabinClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabinClasses", x => x.Id);
                });



            migrationBuilder.CreateTable(
                name: "FlightOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Length = table.Column<TimeSpan>(type: "time", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CabinClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightOffers_CabinClasses_CabinClassId",
                        column: x => x.CabinClassId,
                        principalTable: "CabinClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserFlightOffers",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FlightOfferId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserFlightOffers", x => new { x.AppUserId, x.FlightOfferId });
                    table.ForeignKey(
                        name: "FK_AppUserFlightOffers_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserFlightOffers_FlightOffers_FlightOfferId",
                        column: x => x.FlightOfferId,
                        principalTable: "FlightOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserFlightOffers_FlightOfferId",
                table: "AppUserFlightOffers",
                column: "FlightOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightOffers_CabinClassId",
                table: "FlightOffers",
                column: "CabinClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserFlightOffers");

            migrationBuilder.DropTable(
                name: "FlightOffers");


            migrationBuilder.DropTable(
                name: "CabinClasses");
        }
    }
}
