using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FuelEconomy.Migrations
{
    public partial class VehicleDbAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cylinders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cylinders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drive",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drive", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuelType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Make",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Make", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transmission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleClass",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityMilage = table.Column<decimal>(nullable: false),
                    CylindersId = table.Column<int>(nullable: false),
                    Displacement = table.Column<decimal>(nullable: false),
                    DriveId = table.Column<int>(nullable: false),
                    FuelCost = table.Column<decimal>(nullable: false),
                    FuelTypeID = table.Column<int>(nullable: false),
                    HighwayMilage = table.Column<decimal>(nullable: false),
                    MakeId = table.Column<int>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    TransmissionId = table.Column<int>(nullable: false),
                    VehicleClassId = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_Cylinders_CylindersId",
                        column: x => x.CylindersId,
                        principalTable: "Cylinders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_Drive_DriveId",
                        column: x => x.DriveId,
                        principalTable: "Drive",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_FuelType_FuelTypeID",
                        column: x => x.FuelTypeID,
                        principalTable: "FuelType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_Make_MakeId",
                        column: x => x.MakeId,
                        principalTable: "Make",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_Transmission_TransmissionId",
                        column: x => x.TransmissionId,
                        principalTable: "Transmission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleClass_VehicleClassId",
                        column: x => x.VehicleClassId,
                        principalTable: "VehicleClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_CylindersId",
                table: "Vehicle",
                column: "CylindersId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_DriveId",
                table: "Vehicle",
                column: "DriveId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_FuelTypeID",
                table: "Vehicle",
                column: "FuelTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_MakeId",
                table: "Vehicle",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_TransmissionId",
                table: "Vehicle",
                column: "TransmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleClassId",
                table: "Vehicle",
                column: "VehicleClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Cylinders");

            migrationBuilder.DropTable(
                name: "Drive");

            migrationBuilder.DropTable(
                name: "FuelType");

            migrationBuilder.DropTable(
                name: "Make");

            migrationBuilder.DropTable(
                name: "Transmission");

            migrationBuilder.DropTable(
                name: "VehicleClass");
        }
    }
}
