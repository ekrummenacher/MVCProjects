using AustinVenues.Models;
using AustinVenues.Controllers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AustinVenues.ViewModels;

namespace AustinVenues.Data
{
    public class VenueDbContext : DbContext
    {
        public VenueDbContext(DbContextOptions<VenueDbContext> options)
            : base(options)
        {
        }

        public DbSet<Venue> Venue { get; set; }
        public DbSet<AddressProvided> AddressProvided { get; set; }
        public DbSet<CouncilDistrict> CouncilDistrict { get; set; }
        public DbSet<AssetType> AssetType { get; set; }
        public DbSet<LiveMusic> LiveMusic { get; set; }
        public DbSet<Discipline> Discipline { get; set; }
        public DbSet<DisciplineNotes> DisciplineNotes { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<PartialDetailsViewModel> PartialDetailsViewModel { get; set; }
    }
}

