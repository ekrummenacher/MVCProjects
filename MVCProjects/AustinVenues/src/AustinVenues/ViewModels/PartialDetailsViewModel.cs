using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AustinVenues.Models;
using System.ComponentModel.DataAnnotations;

namespace AustinVenues.ViewModels
{
    public class PartialDetailsViewModel
    {
        private IQueryable<Venue> venues;
        
        public PartialDetailsViewModel()
        {
        }

        public int Id { get; set; }

        [Display(Name = "Venue Type Details")]
        public string AssetTypeNotes { get; set; }

        public string Capactiy { get; set; }

        [Display(Name = "Entertainment Details")]
        public string DisciplineNotesLabel { get; set; }
        public int DisciplineNotesId { get; set; }

        [Display(Name = "Description")]
        public string WebNotes { get; set; }

        public string Address { get; set; }
        
        public virtual DisciplineNotes DisciplineNotes { get; set; }
    }

}
