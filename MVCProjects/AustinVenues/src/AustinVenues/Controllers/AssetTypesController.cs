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
    public class AssetTypesController : Controller
    {
        private readonly VenueDbContext _context;

        public AssetTypesController(VenueDbContext context)
        {
            _context = context;    
        }

        // GET: AssetTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AssetType.ToListAsync());
        }

        // GET: AssetTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetType = await _context.AssetType.SingleOrDefaultAsync(m => m.Id == id);
            if (assetType == null)
            {
                return NotFound();
            }

            return View(assetType);
        }

        // GET: AssetTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AssetTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label")] AssetType assetType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assetType);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(assetType);
        }

        // GET: AssetTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetType = await _context.AssetType.SingleOrDefaultAsync(m => m.Id == id);
            if (assetType == null)
            {
                return NotFound();
            }
            return View(assetType);
        }

        // POST: AssetTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Label")] AssetType assetType)
        {
            if (id != assetType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assetType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetTypeExists(assetType.Id))
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
            return View(assetType);
        }

        // GET: AssetTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetType = await _context.AssetType.SingleOrDefaultAsync(m => m.Id == id);
            if (assetType == null)
            {
                return NotFound();
            }

            return View(assetType);
        }

        // POST: AssetTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assetType = await _context.AssetType.SingleOrDefaultAsync(m => m.Id == id);
            _context.AssetType.Remove(assetType);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AssetTypeExists(int id)
        {
            return _context.AssetType.Any(e => e.Id == id);
        }
    }
}
