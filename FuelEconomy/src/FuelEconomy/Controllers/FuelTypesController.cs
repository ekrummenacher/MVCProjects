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
    public class FuelTypesController : Controller
    {
        private readonly VehicleDbContext _context;

        public FuelTypesController(VehicleDbContext context)
        {
            _context = context;    
        }

        // GET: FuelTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FuelType.ToListAsync());
        }

        // GET: FuelTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelType = await _context.FuelType.SingleOrDefaultAsync(m => m.Id == id);
            if (fuelType == null)
            {
                return NotFound();
            }

            return View(fuelType);
        }

        // GET: FuelTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FuelTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label")] FuelType fuelType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fuelType);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(fuelType);
        }

        // GET: FuelTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelType = await _context.FuelType.SingleOrDefaultAsync(m => m.Id == id);
            if (fuelType == null)
            {
                return NotFound();
            }
            return View(fuelType);
        }

        // POST: FuelTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Label")] FuelType fuelType)
        {
            if (id != fuelType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fuelType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuelTypeExists(fuelType.Id))
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
            return View(fuelType);
        }

        // GET: FuelTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelType = await _context.FuelType.SingleOrDefaultAsync(m => m.Id == id);
            if (fuelType == null)
            {
                return NotFound();
            }

            return View(fuelType);
        }

        // POST: FuelTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fuelType = await _context.FuelType.SingleOrDefaultAsync(m => m.Id == id);
            _context.FuelType.Remove(fuelType);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FuelTypeExists(int id)
        {
            return _context.FuelType.Any(e => e.Id == id);
        }
    }
}
