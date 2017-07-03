using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AustinVenues.Models
{
    public class Venue
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressProvidedId { get; set; }
        public int CouncilDistrictId { get; set; }
        public int AssetTypeId { get; set; }
        public string AssetTypeNotes { get; set; }
        public int LiveMusicId { get; set; }
        public string Capacity { get; set; }
        public int DisciplineId { get; set; }
        public int DisciplineNotesId { get; set; }
        public string Website { get; set; }
        public string WebNotes { get; set; }
        public int Zipcode { get; set; }
        public string Address { get; set; }

        public virtual CouncilDistrict CouncilDistrict { get; set; }
        public virtual AddressProvided AddressProvided { get; set; }
        public virtual AssetType AssetType { get; set; }
        public virtual LiveMusic LiveMusic { get; set; }
        public virtual Discipline Discipline { get; set; }
        public virtual DisciplineNotes DisciplineNotes { get; set; }

        public virtual ICollection<Favorites> Favorites { get; set; }
    }

    public class CouncilDistrict
    {
        public int Id { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Venue> Venue { get; set; }
    }

    public class AddressProvided
    {
        public int Id { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Venue> Venue { get; set; }
    }


    public class AssetType
    {
        public int Id { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Venue> Venue { get; set; }
    }

    public class LiveMusic
    {
        public int Id { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Venue> Venue { get; set; }
    }

    public class Discipline
    {
        public int Id { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Venue> Venue { get; set; }
    }

    public class DisciplineNotes
    {
        public int Id { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Venue> Venue { get; set; }
    }

}
