using AustinVenues.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AustinVenues.Services
{
    public class FavoritesService
    {
        private readonly VenueDbContext _context;

        public FavoritesService(VenueDbContext context)
        {
            _context = context;
        }

        public int GetFavoritesCount(System.Security.Claims.Claim user)
        {
            //var user = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            var user_id = user.Value;

            var c_count = _context.Favorites.Where(c => c.UserId == user_id).Select(c => c).Count();

            return c_count;
        }
    }
}
