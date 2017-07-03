using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AustinVenues.Data;
using AustinVenues.Models;

namespace AustinVenues.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly VenueDbContext _context;

        public FavoritesController(VenueDbContext context)
        {
            _context = context;    
        }

        private object favorites;

        // GET: Favorites
        public async Task<IActionResult> Index(string Type = "Favorites")
        {
            var user = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");

            var user_id = user.Value;
            decimal AmountTotal = 0;
            Type = Type.ToLower();
            ViewBag.Type = Type;

            if (String.IsNullOrEmpty(user_id))
            {
                return RedirectToAction("Error");
            }
            //else
            //{
            //    //var favorites = _context.Favorites.Where(f => f.UserId == user_id)
            //    //    .Include(f => f.Venue.Address)
            //    //    .Include(f => f.Venue.Website)
            //    //    .Include(f => f.Venue.Discipline.Label)
            //    //    .Include(f => f.Venue.AssetType)
            //    //    .Include(f => f.Venue.AssetType.Label)
            //    //    .ToList();
            //    var favorites = _context.Favorites.Where(f => f.UserId == user_id).Select(f => f);
            //        //.Include(f => f.Id)
            //        //.Include(f => f.VenueId)
            //        //.Include(f => f.Venue)
            //        //.Include(f => f.UserId)
            //        //.Include(f => f.Venue.Address)
            //        //.Include(f => f.Venue.Website)
            //        //.Include(f => f.Venue.Discipline.Label)
            //        //.Include(f => f.Venue.AssetType)
            //        //.Include(f => f.Venue.AssetType.Label)
            //        //.Include(f => f.Amount);
            //        //.Include(f => f.StarValue)
            //        //.ToList();

            //    AmountTotal = favorites.Sum(s => s.Amount);
            //}

            ViewBag.Title = "Favorites";

                
                //cart_donateView = favorites.Select(s => s);
                var venueDbContext = _context.Favorites.Include(f => f.Venue).Include(f => f.Venue.AssetType);
            return View(await venueDbContext.ToListAsync());
        }

        // GET: Favorites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorites = await _context.Favorites.SingleOrDefaultAsync(m => m.Id == id);
            if (favorites == null)
            {
                return NotFound();
            }

            return View(favorites);
        }

        // GET: Favorites/Create
        public IActionResult Create(int VenueId = 0)
        {
            //ViewData["VenueId"] = new SelectList(_context.Venue, "Id", "Id");
            if(VenueId <= 0)
            {
                return RedirectToAction("Index");
            }

            ViewBag.VenueId = VenueId;

            return View();
        }

        // POST: Favorites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,UserId,VenueId")] Favorites favorites)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favorites);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //ViewData["VenueId"] = new SelectList(_context.Venue, "Id", "Id", favorites.VenueId);
            return View(favorites);
        }

        // GET: Favorites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorites = await _context.Favorites.SingleOrDefaultAsync(m => m.Id == id);
            if (favorites == null)
            {
                return NotFound();
            }
            ViewData["VenueId"] = new SelectList(_context.Venue, "Id", "Id", favorites.VenueId);
            return View(favorites);
        }

        // POST: Favorites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,UserId,VenueId")] Favorites favorites)
        {
            if (id != favorites.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favorites);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavoritesExists(favorites.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["VenueId"] = new SelectList(_context.Venue, "Id", "Id", favorites.VenueId);
            return View(favorites);
        }

        // GET: Favorites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorites = await _context.Favorites.SingleOrDefaultAsync(m => m.Id == id);
            if (favorites == null)
            {
                return NotFound();
            }
            else
            {
                _context.Favorites.Remove(favorites);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            //return View(favorites);
        }

        //Helper
        public void RemoveFromFavorites(int id)
        {
            var favorites = _context.Favorites.SingleOrDefault(m => m.Id == id);
            if (favorites != null)
            {
                _context.Favorites.Remove(favorites);
                _context.SaveChangesAsync();

                return;
            }
        }

        public IActionResult RemoveFromFavoritesById(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                RemoveFromFavorites(id);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromFavoritesByUser(string user_id)
        {
            var favorites = _context.Favorites.Where(c => c.UserId == user_id);

            if (favorites == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // remove all items from cart
                foreach (var item in favorites)
                {
                    RemoveFromFavorites(item.Id);
                    //_context.SaveChangesAsync();
                }

            }

            return RedirectToAction("Index");
        }

        public IActionResult AddToFavorites(int Id)
        {
            // User is not logged in
            if (!User.Identity.IsAuthenticated)
            {
                string return_url = "/Favorites/AddToFavorites?Id=" + Id;
                return Content("<form action='login' id='favorites_frm' method='post'><input type='hidden' name='ReturnUrl' value='" + return_url + "' /></form><script>document.getElementById('favorites_frm').submit();</script>");
            }
            else
            {
                var user = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                //.Where(c => c.Type == "email").Select(c => c.Value).SingleOrDefault(); 
                //            var user_x = _userManager.GetUserAsync(user);

                var user_id = user.Value;

                // Add to cart for user
                Favorites favorites = new Models.Favorites();

                favorites.Amount = 100;
                favorites.VenueId = Id;
                favorites.UserId = user_id;


                //cart. = 
                _context.Add(favorites);
                _context.SaveChanges();

                return RedirectToAction("Index", "Favorites");
            }
        }

        
        public async Task<IActionResult> addstarvalue(int id, int StarValue)
        {
            var item = await _context.Favorites.Where(s => s.Id == id).FirstOrDefaultAsync();
            item.StarValue = StarValue;
            _context.Favorites.Update(item);
            await _context.SaveChangesAsync();
            
            return RedirectToAction("Index", "Favorites");
        }

        public async Task<IActionResult> EditAmount(int Id, decimal Amount)
        {
            if (FavoritesExists(Id))
            {
                var favorites = await _context.Favorites.SingleOrDefaultAsync(m => m.Id == Id);
                favorites.Amount = Amount;
                _context.Favorites.Update(favorites);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


        // POST: Favorites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var favorites = await _context.Favorites.SingleOrDefaultAsync(m => m.Id == id);
            _context.Favorites.Remove(favorites);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FavoritesExists(int id)
        {
            return _context.Favorites.Any(e => e.Id == id);
        }
    }
}
