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
    public class DisciplineNotesController : Controller
    {
        private readonly VenueDbContext _context;

        public DisciplineNotesController(VenueDbContext context)
        {
            _context = context;    
        }

        // GET: DisciplineNotes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DisciplineNotes.ToListAsync());
        }

        // GET: DisciplineNotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciplineNotes = await _context.DisciplineNotes.SingleOrDefaultAsync(m => m.Id == id);
            if (disciplineNotes == null)
            {
                return NotFound();
            }

            return View(disciplineNotes);
        }

        // GET: DisciplineNotes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DisciplineNotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label")] DisciplineNotes disciplineNotes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disciplineNotes);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(disciplineNotes);
        }

        // GET: DisciplineNotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciplineNotes = await _context.DisciplineNotes.SingleOrDefaultAsync(m => m.Id == id);
            if (disciplineNotes == null)
            {
                return NotFound();
            }
            return View(disciplineNotes);
        }

        // POST: DisciplineNotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Label")] DisciplineNotes disciplineNotes)
        {
            if (id != disciplineNotes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disciplineNotes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisciplineNotesExists(disciplineNotes.Id))
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
            return View(disciplineNotes);
        }

        // GET: DisciplineNotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciplineNotes = await _context.DisciplineNotes.SingleOrDefaultAsync(m => m.Id == id);
            if (disciplineNotes == null)
            {
                return NotFound();
            }

            return View(disciplineNotes);
        }

        // POST: DisciplineNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disciplineNotes = await _context.DisciplineNotes.SingleOrDefaultAsync(m => m.Id == id);
            _context.DisciplineNotes.Remove(disciplineNotes);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DisciplineNotesExists(int id)
        {
            return _context.DisciplineNotes.Any(e => e.Id == id);
        }
    }
}
