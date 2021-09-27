using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetShopAtlantico.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PetOwner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetOwner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PetName = table.Column<string>(type: "TEXT", nullable: false),
                    Breed = table.Column<string>(type: "TEXT", nullable: true),
                    Picture = table.Column<bool>(type: "INTEGER", nullable: false),
                    OwnerName = table.Column<string>(type: "TEXT", nullable: false),
                    PetOwnerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pet_PetOwner_PetOwnerId",
                        column: x => x.PetOwnerId,
                        principalTable: "PetOwner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accommodation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HospitalizationMotive = table.Column<string>(type: "TEXT", nullable: false),
                    HealthState = table.Column<string>(type: "TEXT", nullable: true),
                    AccommodationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsNotVacant = table.Column<bool>(type: "INTEGER", nullable: false),
                    PetId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accommodation_Pet_PetId",
                        column: x => x.PetId,
                        principalTable: "Pet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accommodation_PetId",
                table: "Accommodation",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_PetOwnerId",
                table: "Pet",
                column: "PetOwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accommodation");

            migrationBuilder.DropTable(
                name: "Pet");

            migrationBuilder.DropTable(
                name: "PetOwner");
        }
    }
}
