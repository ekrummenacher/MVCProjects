using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AustinVenues.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressProvided",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressProvided", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CouncilDistrict",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouncilDistrict", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discipline",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discipline", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DisciplineNotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplineNotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LiveMusic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveMusic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    AddressProvidedId = table.Column<int>(nullable: false),
                    AssetTypeId = table.Column<int>(nullable: false),
                    AssetTypeNotes = table.Column<string>(nullable: true),
                    Capacity = table.Column<string>(nullable: true),
                    CouncilDistrictId = table.Column<int>(nullable: false),
                    DisciplineId = table.Column<int>(nullable: false),
                    DisciplineNotesId = table.Column<int>(nullable: false),
                    LiveMusicId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    WebNotes = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Zipcode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venue_AddressProvided_AddressProvidedId",
                        column: x => x.AddressProvidedId,
                        principalTable: "AddressProvided",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venue_AssetType_AssetTypeId",
                        column: x => x.AssetTypeId,
                        principalTable: "AssetType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venue_CouncilDistrict_CouncilDistrictId",
                        column: x => x.CouncilDistrictId,
                        principalTable: "CouncilDistrict",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venue_Discipline_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Discipline",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venue_DisciplineNotes_DisciplineNotesId",
                        column: x => x.DisciplineNotesId,
                        principalTable: "DisciplineNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venue_LiveMusic_LiveMusicId",
                        column: x => x.LiveMusicId,
                        principalTable: "LiveMusic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Venue_AddressProvidedId",
                table: "Venue",
                column: "AddressProvidedId");

            migrationBuilder.CreateIndex(
                name: "IX_Venue_AssetTypeId",
                table: "Venue",
                column: "AssetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Venue_CouncilDistrictId",
                table: "Venue",
                column: "CouncilDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Venue_DisciplineId",
                table: "Venue",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_Venue_DisciplineNotesId",
                table: "Venue",
                column: "DisciplineNotesId");

            migrationBuilder.CreateIndex(
                name: "IX_Venue_LiveMusicId",
                table: "Venue",
                column: "LiveMusicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Venue");

            migrationBuilder.DropTable(
                name: "AddressProvided");

            migrationBuilder.DropTable(
                name: "AssetType");

            migrationBuilder.DropTable(
                name: "CouncilDistrict");

            migrationBuilder.DropTable(
                name: "Discipline");

            migrationBuilder.DropTable(
                name: "DisciplineNotes");

            migrationBuilder.DropTable(
                name: "LiveMusic");
        }
    }
}
