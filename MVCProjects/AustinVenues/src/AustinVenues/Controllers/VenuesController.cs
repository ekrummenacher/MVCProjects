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
    public class VenuesController : Controller
    {
        private readonly VenueDbContext _context;

        public VenuesController(VenueDbContext context)
        {
            _context = context;    
        }

        // GET: Venues
        public async Task<IActionResult> Index()
        {
            var venueDbContext = _context.Venue.Include(v => v.AddressProvided).Include(v => v.AssetType).Include(v => v.CouncilDistrict).Include(v => v.Discipline).Include(v => v.DisciplineNotes).Include(v => v.LiveMusic);
            return View(await venueDbContext.ToListAsync());
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
