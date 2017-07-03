using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AustinVenues.Data;
using AustinVenues.Models;
using AustinVenues.ViewModels;

namespace AustinVenues.Controllers
{
    public class VenuesController : Controller
    {
        private readonly VenueDbContext _context;

        public VenuesController(VenueDbContext context)
        {
            _context = context;    
        }

        // GET: Venues
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page, int? cdFilter = 0, int? addproFilter = 0, int? astypeFilter = 0, int? lmFilter = 0, int? discFilter = 0, int? discnoteFilter = 0, int? zipFilter = 0)
        {
            ViewData["CurrentSort"] = sortOrder;

            var addpro = _context.AddressProvided.Select(y => new { id = y.Id, value = y.Label }).Distinct().ToList();
            ViewBag.AddProSelectList = new SelectList(addpro, "id", "value");

            var cd = _context.CouncilDistrict.Select(y => new { id = y.Id, value = y.Label }).Distinct().ToList();
            ViewBag.CdSelectList = new SelectList(cd, "id", "value");

            var astype = _context.AssetType.Select(y => new { id = y.Id, value = y.Label }).Distinct().ToList();
            ViewBag.AsTypeSelectList = new SelectList(astype, "id", "value");

            var lm = _context.LiveMusic.Select(y => new { id = y.Id, value = y.Label }).Distinct().ToList();
            ViewBag.LmSelectList = new SelectList(lm, "id", "value");

            var disc = _context.Discipline.Select(y => new { id = y.Id, value = y.Label }).Distinct().ToList();
            ViewBag.DiscSelectList = new SelectList(disc, "id", "value");

            var discnote = _context.DisciplineNotes.Select(y => new { id = y.Id, value = y.Label }).Distinct().ToList();
            ViewBag.DiscNoteSelectList = new SelectList(discnote, "id", "value");

            var zip = _context.Venue.Select(y => new { id = y.Zipcode, value = y.Zipcode }).Distinct().ToList();
            ViewBag.ZipSelectList = new SelectList(zip, "id", "value");


            //Create an empty Event object
            //IQueryable<Venue> venues;
            IQueryable<VenuesViewModel> venuesVM;

            var all_venues = _context.Venue.Select(s => new VenuesViewModel()
            {
                Id = s.Id,
                Name = s.Name,
                AssetTypeLabel = s.AssetType.Label,
                AssetTypeId = s.AssetTypeId,
                LiveMusicLabel = s.LiveMusic.Label,
                LiveMusicId = s.LiveMusicId,
                DisciplineLabel = s.Discipline.Label,
                DisciplineId = s.DisciplineId,
                Zipcode = s.Zipcode,
                AddressProvidedLabel = s.AddressProvided.Label,
                AddressProvidedId = s.AddressProvidedId,
                Website = s.Website
            });


            var filter = from x in all_venues
                         where  x.AddressProvidedId == addproFilter || x.AssetTypeId == astypeFilter || x.LiveMusicId == lmFilter || x.DisciplineId == discFilter /*|| x.DisciplineNotesId == discnoteFilter*/
                         select x;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            if (!String.IsNullOrEmpty(searchString))
            {

                zipFilter = 0;
            }


            if (addproFilter > 0)
            {
                venuesVM = all_venues.Where(s => s.AddressProvidedId == addproFilter);
            }
            else if (astypeFilter > 0)
            {
                venuesVM = all_venues.Where(s => s.AssetTypeId == astypeFilter);
            }
            else if (lmFilter > 0)
            {
                venuesVM = all_venues.Where(s => s.LiveMusicId == lmFilter);
            }
            else if (discFilter > 0)
            {
                venuesVM = all_venues.Where(s => s.DisciplineId == discFilter);
            }
            else if (zipFilter > 0)
            {
                venuesVM = all_venues.Where(s => s.Zipcode == zipFilter);
            }
            else
            {
                // do nothing, all
                venuesVM = all_venues.Select(s => s);
            }


            int pageSize = 5;
            return View(await PaginatedList<VenuesViewModel>.CreateAsync(venuesVM.AsNoTracking(), page ?? 1, pageSize));
        }

        // GET: Venues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venue = await _context.Venue.SingleOrDefaultAsync(m => m.Id == id);
            if (venue == null)
            {
                return NotFound();
            }

            return View(venue);
        }

        public PartialViewResult PartialDetails(int? id)
        {
            PartialDetailsViewModel ps = new PartialDetailsViewModel();
            var venue_details = _context.Venue.Where(m => m.Id == id).Select(s => new PartialDetailsViewModel()
            {
                Id = s.Id,
                AssetTypeNotes = s.AssetTypeNotes,
                Capactiy = s.Capacity,
                DisciplineNotesLabel = s.DisciplineNotes.Label,
                WebNotes = s.WebNotes,
                Address = s.Address,
            });

            ps = venue_details.SingleOrDefault();


            return PartialView(ps);
        }

        // GET: Venues/Create
        public IActionResult Create()
        {
            ViewData["AddressProvidedId"] = new SelectList(_context.Set<AddressProvided>(), "Id", "Id");
            ViewData["AssetTypeId"] = new SelectList(_context.Set<AssetType>(), "Id", "Id");
            ViewData["CouncilDistrictId"] = new SelectList(_context.Set<CouncilDistrict>(), "Id", "Id");
            ViewData["DisciplineId"] = new SelectList(_context.Set<Discipline>(), "Id", "Id");
            ViewData["DisciplineNotesId"] = new SelectList(_context.Set<DisciplineNotes>(), "Id", "Id");
            ViewData["LiveMusicId"] = new SelectList(_context.Set<LiveMusic>(), "Id", "Id");
            return View();
        }

        // POST: Venues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Address,AddressProvidedId,AssetTypeId,AssetTypeNotes,Capacity,CouncilDistrictId,DisciplineId,DisciplineNotesId,LiveMusicId,Name,WebNotes,Website,Zipcode")] Venue venue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venue);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["AddressProvidedId"] = new SelectList(_context.Set<AddressProvided>(), "Id", "Id", venue.AddressProvidedId);
            ViewData["AssetTypeId"] = new SelectList(_context.Set<AssetType>(), "Id", "Id", venue.AssetTypeId);
            ViewData["CouncilDistrictId"] = new SelectList(_context.Set<CouncilDistrict>(), "Id", "Id", venue.CouncilDistrictId);
            ViewData["DisciplineId"] = new SelectList(_context.Set<Discipline>(), "Id", "Id", venue.DisciplineId);
            ViewData["DisciplineNotesId"] = new SelectList(_context.Set<DisciplineNotes>(), "Id", "Id", venue.DisciplineNotesId);
            ViewData["LiveMusicId"] = new SelectList(_context.Set<LiveMusic>(), "Id", "Id", venue.LiveMusicId);
            return View(venue);
        }

        // GET: Venues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venue = await _context.Venue.SingleOrDefaultAsync(m => m.Id == id);
            if (venue == null)
            {
                return NotFound();
            }
            ViewData["AddressProvidedId"] = new SelectList(_context.Set<AddressProvided>(), "Id", "Id", venue.AddressProvidedId);
            ViewData["AssetTypeId"] = new SelectList(_context.Set<AssetType>(), "Id", "Id", venue.AssetTypeId);
            ViewData["CouncilDistrictId"] = new SelectList(_context.Set<CouncilDistrict>(), "Id", "Id", venue.CouncilDistrictId);
            ViewData["DisciplineId"] = new SelectList(_context.Set<Discipline>(), "Id", "Id", venue.DisciplineId);
            ViewData["DisciplineNotesId"] = new SelectList(_context.Set<DisciplineNotes>(), "Id", "Id", venue.DisciplineNotesId);
            ViewData["LiveMusicId"] = new SelectList(_context.Set<LiveMusic>(), "Id", "Id", venue.LiveMusicId);
            return View(venue);
        }

        // POST: Venues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Address,AddressProvidedId,AssetTypeId,AssetTypeNotes,Capacity,CouncilDistrictId,DisciplineId,DisciplineNotesId,LiveMusicId,Name,WebNotes,Website,Zipcode")] Venue venue)
        {
            if (id != venue.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VenueExists(venue.Id))
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
            ViewData["AddressProvidedId"] = new SelectList(_context.Set<AddressProvided>(), "Id", "Id", venue.AddressProvidedId);
            ViewData["AssetTypeId"] = new SelectList(_context.Set<AssetType>(), "Id", "Id", venue.AssetTypeId);
            ViewData["CouncilDistrictId"] = new SelectList(_context.Set<CouncilDistrict>(), "Id", "Id", venue.CouncilDistrictId);
            ViewData["DisciplineId"] = new SelectList(_context.Set<Discipline>(), "Id", "Id", venue.DisciplineId);
            ViewData["DisciplineNotesId"] = new SelectList(_context.Set<DisciplineNotes>(), "Id", "Id", venue.DisciplineNotesId);
            ViewData["LiveMusicId"] = new SelectList(_context.Set<LiveMusic>(), "Id", "Id", venue.LiveMusicId);
            return View(venue);
        }

        // GET: Venues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venue = await _context.Venue.SingleOrDefaultAsync(m => m.Id == id);
            if (venue == null)
            {
                return NotFound();
            }

            return View(venue);
        }

        // POST: Venues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venue = await _context.Venue.SingleOrDefaultAsync(m => m.Id == id);
            _context.Venue.Remove(venue);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool VenueExists(int id)
        {
            return _context.Venue.Any(e => e.Id == id);
        }
    }
}
