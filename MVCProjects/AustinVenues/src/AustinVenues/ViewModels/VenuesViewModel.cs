using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AustinVenues.Models;
using System.ComponentModel.DataAnnotations;

namespace AustinVenues.ViewModels
{
    public class VenuesViewModel
    {
        private IQueryable<Venue> venues;

        public VenuesViewModel()
        {
        }

        public int Id { get; set; }

        [Display(Name = "Venue Name")]
        public string Name { get; set; }

        [Display(Name = "Venue Type")]
        public string AssetTypeLabel { get; set; }
        public int AssetTypeId { get; set; }

        [Display(Name = "Live Music")]
        public string LiveMusicLabel { get; set; }
        public int LiveMusicId { get; set; }

        [Display(Name = "Entertainment Type")]
        public string DisciplineLabel { get; set; }
        public int DisciplineId { get; set; }

        public int Zipcode { get; set; }

        [Display(Name = "Address Provided")]
        public string AddressProvidedLabel { get; set; }
        public int AddressProvidedId { get; set; }

        public string Website { get; set; }

        public virtual AssetType AssetType { get; set; }
        public virtual LiveMusic LiveMusic { get; set; }
        public virtual Discipline Discipline { get; set; }
        public virtual AddressProvided AddressProvided { get; set; }
    }
}
