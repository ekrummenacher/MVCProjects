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
    public class LiveMusicsController : Controller
    {
        private readonly VenueDbContext _context;

        public LiveMusicsController(VenueDbContext context)
        {
            _context = context;    
        }

        // GET: LiveMusics
        public async Task<IActionResult> Index()
        {
            return View(await _context.LiveMusic.ToListAsync());
        }

        // GET: LiveMusics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liveMusic = await _context.LiveMusic.SingleOrDefaultAsync(m => m.Id == id);
            if (liveMusic == null)
            {
                return NotFound();
            }

            return View(liveMusic);
        }

        // GET: LiveMusics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LiveMusics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label")] LiveMusic liveMusic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(liveMusic);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(liveMusic);
        }

        // GET: LiveMusics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liveMusic = await _context.LiveMusic.SingleOrDefaultAsync(m => m.Id == id);
            if (liveMusic == null)
            {
                return NotFound();
            }
            return View(liveMusic);
        }

        // POST: LiveMusics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Label")] LiveMusic liveMusic)
        {
            if (id != liveMusic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(liveMusic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LiveMusicExists(liveMusic.Id))
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
            return View(liveMusic);
        }

        // GET: LiveMusics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liveMusic = await _context.LiveMusic.SingleOrDefaultAsync(m => m.Id == id);
            if (liveMusic == null)
            {
                return NotFound();
            }

            return View(liveMusic);
        }

        // POST: LiveMusics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var liveMusic = await _context.LiveMusic.SingleOrDefaultAsync(m => m.Id == id);
            _context.LiveMusic.Remove(liveMusic);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool LiveMusicExists(int id)
        {
            return _context.LiveMusic.Any(e => e.Id == id);
        }
    }
}
