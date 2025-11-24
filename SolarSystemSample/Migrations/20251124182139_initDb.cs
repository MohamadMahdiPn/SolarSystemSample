using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarSystemSample.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SolarSystems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StarName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StarType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StarDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StarSize = table.Column<int>(type: "int", nullable: false),
                    StarColor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolarSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SolarSystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Label = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Distance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearLength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DayLength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrbitRadius = table.Column<int>(type: "int", nullable: false),
                    OrbitDurationSeconds = table.Column<double>(type: "float", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planets_SolarSystems_SolarSystemId",
                        column: x => x.SolarSystemId,
                        principalTable: "SolarSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Moons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Label = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Distance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearLength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DayLength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrbitRadius = table.Column<int>(type: "int", nullable: false),
                    OrbitDurationSeconds = table.Column<double>(type: "float", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moons_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Moons_PlanetId",
                table: "Moons",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_Planets_SolarSystemId",
                table: "Planets",
                column: "SolarSystemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moons");

            migrationBuilder.DropTable(
                name: "Planets");

            migrationBuilder.DropTable(
                name: "SolarSystems");
        }
    }
}
