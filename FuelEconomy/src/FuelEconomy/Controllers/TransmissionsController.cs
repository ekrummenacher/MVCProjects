using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FuelEconomy.Data;
using FuelEconomy.Models;

namespace FuelEconomy.Controllers
{
    public class TransmissionsController : Controller
    {
        private readonly VehicleDbContext _context;

        public TransmissionsController(VehicleDbContext context)
        {
            _context = context;    
        }

        // GET: Transmissions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transmission.ToListAsync());
        }

        // GET: Transmissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transmission = await _context.Transmission.SingleOrDefaultAsync(m => m.Id == id);
            if (transmission == null)
            {
                return NotFound();
            }

            return View(transmission);
        }

        // GET: Transmissions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transmissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label")] Transmission transmission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transmission);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(transmission);
        }

        // GET: Transmissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transmission = await _context.Transmission.SingleOrDefaultAsync(m => m.Id == id);
            if (transmission == null)
            {
                return NotFound();
            }
            return View(transmission);
        }

        // POST: Transmissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Label")] Transmission transmission)
        {
            if (id != transmission.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transmission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransmissionExists(transmission.Id))
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
            return View(transmission);
        }

        // GET: Transmissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transmission = await _context.Transmission.SingleOrDefaultAsync(m => m.Id == id);
            if (transmission == null)
            {
                return NotFound();
            }

            return View(transmission);
        }

        // POST: Transmissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transmission = await _context.Transmission.SingleOrDefaultAsync(m => m.Id == id);
            _context.Transmission.Remove(transmission);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TransmissionExists(int id)
        {
            return _context.Transmission.Any(e => e.Id == id);
        }
    }
}
