using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AustinVenues.Migrations
{
    public partial class AddAssetTypeFav : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PartialDetailsViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    AssetTypeNotes = table.Column<string>(nullable: true),
                    Capactiy = table.Column<string>(nullable: true),
                    DisciplineNotesId = table.Column<int>(nullable: false),
                    DisciplineNotesLabel = table.Column<string>(nullable: true),
                    WebNotes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartialDetailsViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartialDetailsViewModel_DisciplineNotes_DisciplineNotesId",
                        column: x => x.DisciplineNotesId,
                        principalTable: "DisciplineNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<int>(
                name: "AssetTypeId",
                table: "Favorites",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_AssetTypeId",
                table: "Favorites",
                column: "AssetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PartialDetailsViewModel_DisciplineNotesId",
                table: "PartialDetailsViewModel",
                column: "DisciplineNotesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_AssetType_AssetTypeId",
                table: "Favorites",
                column: "AssetTypeId",
                principalTable: "AssetType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_AssetType_AssetTypeId",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_AssetTypeId",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "AssetTypeId",
                table: "Favorites");

            migrationBuilder.DropTable(
                name: "PartialDetailsViewModel");
        }
    }
}
