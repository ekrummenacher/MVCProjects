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
    public class AddressProvidedController : Controller
    {
        private readonly VenueDbContext _context;

        public AddressProvidedController(VenueDbContext context)
        {
            _context = context;    
        }

        // GET: AddressProvided
        public async Task<IActionResult> Index()
        {
            return View(await _context.AddressProvided.ToListAsync());
        }

        // GET: AddressProvided/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressProvided = await _context.AddressProvided.SingleOrDefaultAsync(m => m.Id == id);
            if (addressProvided == null)
            {
                return NotFound();
            }

            return View(addressProvided);
        }

        // GET: AddressProvided/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddressProvided/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label")] AddressProvided addressProvided)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addressProvided);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(addressProvided);
        }

        // GET: AddressProvided/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressProvided = await _context.AddressProvided.SingleOrDefaultAsync(m => m.Id == id);
            if (addressProvided == null)
            {
                return NotFound();
            }
            return View(addressProvided);
        }

        // POST: AddressProvided/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Label")] AddressProvided addressProvided)
        {
            if (id != addressProvided.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addressProvided);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressProvidedExists(addressProvided.Id))
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
            return View(addressProvided);
        }

        // GET: AddressProvided/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressProvided = await _context.AddressProvided.SingleOrDefaultAsync(m => m.Id == id);
            if (addressProvided == null)
            {
                return NotFound();
            }

            return View(addressProvided);
        }

        // POST: AddressProvided/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addressProvided = await _context.AddressProvided.SingleOrDefaultAsync(m => m.Id == id);
            _context.AddressProvided.Remove(addressProvided);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AddressProvidedExists(int id)
        {
            return _context.AddressProvided.Any(e => e.Id == id);
        }
    }
}
