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
    public class CouncilDistrictsController : Controller
    {
        private readonly VenueDbContext _context;

        public CouncilDistrictsController(VenueDbContext context)
        {
            _context = context;    
        }

        // GET: CouncilDistricts
        public async Task<IActionResult> Index()
        {
            return View(await _context.CouncilDistrict.ToListAsync());
        }

        // GET: CouncilDistricts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var councilDistrict = await _context.CouncilDistrict.SingleOrDefaultAsync(m => m.Id == id);
            if (councilDistrict == null)
            {
                return NotFound();
            }

            return View(councilDistrict);
        }

        // GET: CouncilDistricts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CouncilDistricts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label")] CouncilDistrict councilDistrict)
        {
            if (ModelState.IsValid)
            {
                _context.Add(councilDistrict);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(councilDistrict);
        }

        // GET: CouncilDistricts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var councilDistrict = await _context.CouncilDistrict.SingleOrDefaultAsync(m => m.Id == id);
            if (councilDistrict == null)
            {
                return NotFound();
            }
            return View(councilDistrict);
        }

        // POST: CouncilDistricts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Label")] CouncilDistrict councilDistrict)
        {
            if (id != councilDistrict.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(councilDistrict);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CouncilDistrictExists(councilDistrict.Id))
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
            return View(councilDistrict);
        }

        // GET: CouncilDistricts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var councilDistrict = await _context.CouncilDistrict.SingleOrDefaultAsync(m => m.Id == id);
            if (councilDistrict == null)
            {
                return NotFound();
            }

            return View(councilDistrict);
        }

        // POST: CouncilDistricts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var councilDistrict = await _context.CouncilDistrict.SingleOrDefaultAsync(m => m.Id == id);
            _context.CouncilDistrict.Remove(councilDistrict);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CouncilDistrictExists(int id)
        {
            return _context.CouncilDistrict.Any(e => e.Id == id);
        }
    }
}
