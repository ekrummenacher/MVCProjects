using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FuelEconomy.Data;
using FuelEconomy.Models;
using FuelEconomy.ViewModels;

namespace FuelEconomy.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly VehicleDbContext _context;

        public VehiclesController(VehicleDbContext context)
        {
            _context = context;    
        }

        // GET: Vehicles
        public async Task<IActionResult> Index(string searchString, string currentFilter, string sortOrder, int? page, int? fyFilter = 0, int? cycFilter = 0, int? driveFilter = 0, int? ftFilter = 0, int? makeFilter = 0, int? transFilter = 0, int? vcFilter = 0)
        {
            // FY 
            var fy = _context.Vehicle.Select(y => new { id = y.Year, value = y.Year }).Distinct().ToList();
            ViewBag.FySelectList = new SelectList(fy, "id", "value");

            // Cylinders
            var cyc = _context.Cylinders.Select(y => new { id = y.Id, value = y.Label }).Distinct().ToList();
            ViewBag.CycSelectList = new SelectList(cyc, "id", "value");

            //Drives
            var drive = _context.Drive.Select(y => new { id = y.Id, value = y.Label }).Distinct().ToList();
            ViewBag.DriveSelectList = new SelectList(drive, "id", "value");

            //FuelTypes
            var ft = _context.FuelType.Select(y => new { id = y.Id, value = y.Label }).Distinct().ToList();
            ViewBag.FtSelectList = new SelectList(ft, "id", "value");

            //Makes
            var make = _context.Make.Select(y => new { id = y.Id, value = y.Label }).Distinct().ToList();
            ViewBag.MakeSelectList = new SelectList(make, "id", "value");

            //Transmissions
            var trans = _context.Transmission.Select(y => new { id = y.Id, value = y.Label }).Distinct().ToList();
            ViewBag.TransSelectList = new SelectList(trans, "id", "value");

            //VehicleClass
            var vc = _context.VehicleClass.Select(y => new { id = y.Id, value = y.Label }).Distinct().ToList();
            ViewBag.VCSelectList = new SelectList(vc, "id", "value");

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            // Create an empty Event object
            IQueryable<VehicleViewModel> vehicles;

            var all_vehicles = _context.Vehicle.Select(v => new VehicleViewModel()
            {
                Id = v.Id,
                CylindersLabel = v.Cylinders.Label,
                CylindersId = v.CylindersId,
                Displacement = v.Displacement,
                DriveLabel = v.Drive.Label,
                DriveId = v.DriveId,
                FuelCost = v.FuelCost,
                FuelTypeLabel = v.FuelType.Label,
                FuelTypeID = v.FuelTypeID,
                MakeLabel = v.Make.Label,
                MakeId = v.MakeId,
                Model = v.Model,
                TransmissionLabel = v.Transmission.Label,
                TransmissionId = v.TransmissionId,
                CityMilage = v.CityMilage,
                HighwayMilage = v.HighwayMilage,
                VehicleClassLabel = v.VehicleClass.Label,
                VehicleClassId = v.VehicleClassId,
                Year = v.Year
            });

            //var all_vehicles = _context.Vehicle.Include(v => v.Cylinders)
            //    .Include(v => v.Drive)
            //    .Include(v => v.FuelType)
            //    .Include(v => v.Make)
            //    .Include(v => v.Transmission)
            //    .Include(v => v.VehicleClass)
            //    .Select(v => v);

            //var filter = from x in all_vehicles
            //                 //where x.CylindersId in (Select Id from Cylinders where Id == cycFilter)
            //             where x.Year == fyFilter || x.CylindersId == cycFilter || x.DriveId == driveFilter || x.FuelTypeID == ftFilter || x.MakeId == makeFilter || x.TransmissionId == transFilter || x.VehicleClassId == vcFilter
            //             select x;

            if (!String.IsNullOrEmpty(searchString))
            {
                fyFilter = 0;

                all_vehicles = all_vehicles.Where(v => v.Model.Contains(searchString));
            }

            if (fyFilter > 0)
            {
                vehicles = all_vehicles.Where(s => s.Year == fyFilter);
            }
            else if (cycFilter > 0)
            {
                vehicles = all_vehicles.Where(s => s.CylindersId == cycFilter);
            }
            else if (driveFilter > 0)
            {
                vehicles = all_vehicles.Where(s => s.DriveId == driveFilter);
            }
            else if (ftFilter > 0)
            {
                vehicles = all_vehicles.Where(s => s.FuelTypeID == ftFilter);
            }
            else if (makeFilter > 0)
            {
                vehicles = all_vehicles.Where(s => s.MakeId == makeFilter);
            }
            else if (transFilter > 0)
            {
                vehicles = all_vehicles.Where(s => s.TransmissionId == transFilter);
            }
            else if (vcFilter > 0)
            {
                vehicles = all_vehicles.Where(s => s.VehicleClassId == vcFilter);
            }
            else
            {
                // do nothing, all
                vehicles = all_vehicles.Select(s => s);
            }

            ////return View(vehicles.ToList());
            //return View(filter.ToList());

            //var vehicleDbContext = _context.Vehicle.Include(v => v.Cylinders).Include(v => v.Drive).Include(v => v.FuelType).Include(v => v.Make).Include(v => v.Transmission).Include(v => v.VehicleClass);
            //return View(await vehicleDbContext.ToListAsync());
            int pageSize = 10;
            return View(await PaginatedList<VehicleViewModel>.CreateAsync(vehicles.AsNoTracking(), page ?? 1, pageSize));
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.SingleOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            ViewData["CylindersId"] = new SelectList(_context.Cylinders, "Id", "Id");
            ViewData["DriveId"] = new SelectList(_context.Drive, "Id", "Id");
            ViewData["FuelTypeID"] = new SelectList(_context.FuelType, "Id", "Id");
            ViewData["MakeId"] = new SelectList(_context.Make, "Id", "Id");
            ViewData["TransmissionId"] = new SelectList(_context.Transmission, "Id", "Id");
            ViewData["VehicleClassId"] = new SelectList(_context.VehicleClass, "Id", "Id");
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CityMilage,CylindersId,Displacement,DriveId,FuelCost,FuelTypeID,HighwayMilage,MakeId,Model,TransmissionId,VehicleClassId,Year")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CylindersId"] = new SelectList(_context.Cylinders, "Id", "Id", vehicle.CylindersId);
            ViewData["DriveId"] = new SelectList(_context.Drive, "Id", "Id", vehicle.DriveId);
            ViewData["FuelTypeID"] = new SelectList(_context.FuelType, "Id", "Id", vehicle.FuelTypeID);
            ViewData["MakeId"] = new SelectList(_context.Make, "Id", "Id", vehicle.MakeId);
            ViewData["TransmissionId"] = new SelectList(_context.Transmission, "Id", "Id", vehicle.TransmissionId);
            ViewData["VehicleClassId"] = new SelectList(_context.VehicleClass, "Id", "Id", vehicle.VehicleClassId);
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.SingleOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }
            ViewData["CylindersId"] = new SelectList(_context.Cylinders, "Id", "Id", vehicle.CylindersId);
            ViewData["DriveId"] = new SelectList(_context.Drive, "Id", "Id", vehicle.DriveId);
            ViewData["FuelTypeID"] = new SelectList(_context.FuelType, "Id", "Id", vehicle.FuelTypeID);
            ViewData["MakeId"] = new SelectList(_context.Make, "Id", "Id", vehicle.MakeId);
            ViewData["TransmissionId"] = new SelectList(_context.Transmission, "Id", "Id", vehicle.TransmissionId);
            ViewData["VehicleClassId"] = new SelectList(_context.VehicleClass, "Id", "Id", vehicle.VehicleClassId);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CityMilage,CylindersId,Displacement,DriveId,FuelCost,FuelTypeID,HighwayMilage,MakeId,Model,TransmissionId,VehicleClassId,Year")] Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.Id))
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
            ViewData["CylindersId"] = new SelectList(_context.Cylinders, "Id", "Id", vehicle.CylindersId);
            ViewData["DriveId"] = new SelectList(_context.Drive, "Id", "Id", vehicle.DriveId);
            ViewData["FuelTypeID"] = new SelectList(_context.FuelType, "Id", "Id", vehicle.FuelTypeID);
            ViewData["MakeId"] = new SelectList(_context.Make, "Id", "Id", vehicle.MakeId);
            ViewData["TransmissionId"] = new SelectList(_context.Transmission, "Id", "Id", vehicle.TransmissionId);
            ViewData["VehicleClassId"] = new SelectList(_context.VehicleClass, "Id", "Id", vehicle.VehicleClassId);
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.SingleOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _context.Vehicle.SingleOrDefaultAsync(m => m.Id == id);
            _context.Vehicle.Remove(vehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicle.Any(e => e.Id == id);
        }
    }
}
