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
    public class VehicleClassesController : Controller
    {
        private readonly VehicleDbContext _context;

        public VehicleClassesController(VehicleDbContext context)
        {
            _context = context;    
        }

        // GET: VehicleClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehicleClass.ToListAsync());
        }

        // GET: VehicleClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleClass = await _context.VehicleClass.SingleOrDefaultAsync(m => m.Id == id);
            if (vehicleClass == null)
            {
                return NotFound();
            }

            return View(vehicleClass);
        }

        // GET: VehicleClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label")] VehicleClass vehicleClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleClass);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vehicleClass);
        }

        // GET: VehicleClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleClass = await _context.VehicleClass.SingleOrDefaultAsync(m => m.Id == id);
            if (vehicleClass == null)
            {
                return NotFound();
            }
            return View(vehicleClass);
        }

        // POST: VehicleClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Label")] VehicleClass vehicleClass)
        {
            if (id != vehicleClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleClassExists(vehicleClass.Id))
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
            return View(vehicleClass);
        }

        // GET: VehicleClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleClass = await _context.VehicleClass.SingleOrDefaultAsync(m => m.Id == id);
            if (vehicleClass == null)
            {
                return NotFound();
            }

            return View(vehicleClass);
        }

        // POST: VehicleClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleClass = await _context.VehicleClass.SingleOrDefaultAsync(m => m.Id == id);
            _context.VehicleClass.Remove(vehicleClass);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool VehicleClassExists(int id)
        {
            return _context.VehicleClass.Any(e => e.Id == id);
        }
    }
}
