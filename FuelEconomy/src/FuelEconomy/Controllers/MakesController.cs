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
    public class MakesController : Controller
    {
        private readonly VehicleDbContext _context;

        public MakesController(VehicleDbContext context)
        {
            _context = context;    
        }

        // GET: Makes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Make.ToListAsync());
        }

        // GET: Makes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var make = await _context.Make.SingleOrDefaultAsync(m => m.Id == id);
            if (make == null)
            {
                return NotFound();
            }

            return View(make);
        }

        // GET: Makes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Makes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label")] Make make)
        {
            if (ModelState.IsValid)
            {
                _context.Add(make);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(make);
        }

        // GET: Makes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var make = await _context.Make.SingleOrDefaultAsync(m => m.Id == id);
            if (make == null)
            {
                return NotFound();
            }
            return View(make);
        }

        // POST: Makes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Label")] Make make)
        {
            if (id != make.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(make);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MakeExists(make.Id))
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
            return View(make);
        }

        // GET: Makes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var make = await _context.Make.SingleOrDefaultAsync(m => m.Id == id);
            if (make == null)
            {
                return NotFound();
            }

            return View(make);
        }

        // POST: Makes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var make = await _context.Make.SingleOrDefaultAsync(m => m.Id == id);
            _context.Make.Remove(make);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MakeExists(int id)
        {
            return _context.Make.Any(e => e.Id == id);
        }
    }
}
