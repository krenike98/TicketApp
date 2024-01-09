using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace TicketApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "line",
                columns: table => new
                {
                    LineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DeparturePlace = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    ArrivalPlace = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsReservedSeated = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsSupplementTicketNeeded = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    NumberOfCarriages = table.Column<int>(type: "int", nullable: true),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.LineId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Pwd = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Adress = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    IsAdmin = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.UserId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "departuretime",
                columns: table => new
                {
                    DepartureTimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LineId = table.Column<int>(type: "int", nullable: false),
                    Departure = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.LineId, x.DepartureTimeId });
                    table.UniqueConstraint("AK_departuretime_DepartureTimeId", x => x.DepartureTimeId);
                    table.ForeignKey(
                        name: "LineIdInDeparture",
                        column: x => x.LineId,
                        principalTable: "line",
                        principalColumn: "LineId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    LineId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DepartureTimeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.LineId, x.UserId });
                    table.ForeignKey(
                        name: "DepartureTimeId",
                        column: x => x.DepartureTimeId,
                        principalTable: "departuretime",
                        principalColumn: "DepartureTimeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "LineId",
                        column: x => x.LineId,
                        principalTable: "line",
                        principalColumn: "LineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "DepartureTimeId",
                table: "departuretime",
                column: "DepartureTimeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "DepartureTimeId_idx",
                table: "order",
                column: "DepartureTimeId");

            migrationBuilder.CreateIndex(
                name: "UserId_idx",
                table: "order",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "departuretime");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "line");
        }
    }
}
