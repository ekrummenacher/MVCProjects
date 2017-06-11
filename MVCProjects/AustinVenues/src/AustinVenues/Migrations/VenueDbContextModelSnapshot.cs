using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AustinVenues.Data;

namespace AustinVenues.Migrations
{
    [DbContext(typeof(VenueDbContext))]
    partial class VenueDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AustinVenues.Models.AddressProvided", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label");

                    b.HasKey("Id");

                    b.ToTable("AddressProvided");
                });

            modelBuilder.Entity("AustinVenues.Models.AssetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label");

                    b.HasKey("Id");

                    b.ToTable("AssetType");
                });

            modelBuilder.Entity("AustinVenues.Models.CouncilDistrict", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label");

                    b.HasKey("Id");

                    b.ToTable("CouncilDistrict");
                });

            modelBuilder.Entity("AustinVenues.Models.Discipline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label");

                    b.HasKey("Id");

                    b.ToTable("Discipline");
                });

            modelBuilder.Entity("AustinVenues.Models.DisciplineNotes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label");

                    b.HasKey("Id");

                    b.ToTable("DisciplineNotes");
                });

            modelBuilder.Entity("AustinVenues.Models.LiveMusic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label");

                    b.HasKey("Id");

                    b.ToTable("LiveMusic");
                });

            modelBuilder.Entity("AustinVenues.Models.Venue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int>("AddressProvidedId");

                    b.Property<int>("AssetTypeId");

                    b.Property<string>("AssetTypeNotes");

                    b.Property<string>("Capacity");

                    b.Property<int>("CouncilDistrictId");

                    b.Property<int>("DisciplineId");

                    b.Property<int>("DisciplineNotesId");

                    b.Property<int>("LiveMusicId");

                    b.Property<string>("Name");

                    b.Property<string>("WebNotes");

                    b.Property<string>("Website");

                    b.Property<int>("Zipcode");

                    b.HasKey("Id");

                    b.HasIndex("AddressProvidedId");

                    b.HasIndex("AssetTypeId");

                    b.HasIndex("CouncilDistrictId");

                    b.HasIndex("DisciplineId");

                    b.HasIndex("DisciplineNotesId");

                    b.HasIndex("LiveMusicId");

                    b.ToTable("Venue");
                });

            modelBuilder.Entity("AustinVenues.Models.Venue", b =>
                {
                    b.HasOne("AustinVenues.Models.AddressProvided", "AddressProvided")
                        .WithMany("Venue")
                        .HasForeignKey("AddressProvidedId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AustinVenues.Models.AssetType", "AssetType")
                        .WithMany("Venue")
                        .HasForeignKey("AssetTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AustinVenues.Models.CouncilDistrict", "CouncilDistrict")
                        .WithMany("Venue")
                        .HasForeignKey("CouncilDistrictId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AustinVenues.Models.Discipline", "Discipline")
                        .WithMany("Venue")
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AustinVenues.Models.DisciplineNotes", "DisciplineNotes")
                        .WithMany("Venue")
                        .HasForeignKey("DisciplineNotesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AustinVenues.Models.LiveMusic", "LiveMusic")
                        .WithMany("Venue")
                        .HasForeignKey("LiveMusicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
