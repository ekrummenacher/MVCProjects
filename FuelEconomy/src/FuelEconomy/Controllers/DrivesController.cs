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
    public class DrivesController : Controller
    {
        private readonly VehicleDbContext _context;

        public DrivesController(VehicleDbContext context)
        {
            _context = context;    
        }

        // GET: Drives
        public async Task<IActionResult> Index()
        {
            return View(await _context.Drive.ToListAsync());
        }

        // GET: Drives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drive = await _context.Drive.SingleOrDefaultAsync(m => m.Id == id);
            if (drive == null)
            {
                return NotFound();
            }

            return View(drive);
        }

        // GET: Drives/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Drives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label")] Drive drive)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drive);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(drive);
        }

        // GET: Drives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drive = await _context.Drive.SingleOrDefaultAsync(m => m.Id == id);
            if (drive == null)
            {
                return NotFound();
            }
            return View(drive);
        }

        // POST: Drives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Label")] Drive drive)
        {
            if (id != drive.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drive);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriveExists(drive.Id))
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
            return View(drive);
        }

        // GET: Drives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drive = await _context.Drive.SingleOrDefaultAsync(m => m.Id == id);
            if (drive == null)
            {
                return NotFound();
            }

            return View(drive);
        }

        // POST: Drives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drive = await _context.Drive.SingleOrDefaultAsync(m => m.Id == id);
            _context.Drive.Remove(drive);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DriveExists(int id)
        {
            return _context.Drive.Any(e => e.Id == id);
        }
    }
}
