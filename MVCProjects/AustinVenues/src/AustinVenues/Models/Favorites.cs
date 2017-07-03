using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AustinVenues.Models;
using System.ComponentModel.DataAnnotations;

namespace AustinVenues.Models
{
    public class FavoritesList
    {
        private List<Favorites> cartCollection = new List<Favorites>();

        public virtual void AddItem(Venue venues)
        {
            Favorites favorites = cartCollection.Where(s => s.Venue.Id == venues.Id).FirstOrDefault();

            if (favorites == null)
            {
                cartCollection.Add(new Favorites
                {
                    Venue = venues
                });
            }
        }

        public virtual void RemoveItem(Venue venues) => cartCollection.RemoveAll(l => l.Venue.Id == venues.Id);

        public virtual decimal ComputeTotalValue() => cartCollection.Sum(e => e.Amount);

        public virtual void Clear() => cartCollection.Clear();

        public virtual IEnumerable<Favorites> Favorites => cartCollection;
    }

    public class Favorites
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public int VenueId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        [Display(Name = "Donation")]
        public decimal Amount { get; set; }
        [Required]
        public int StarValue { get; set; }

        //public virtual ApplicationUser User { get; set; }
        public virtual Venue Venue { get; set; }
        public virtual AssetType AssetType { get; set; }
    }
}

