using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;

namespace AsyncInn.Controllers
{
    public class RoomLocationAmenitiesController : Controller
    {
        private readonly AsyncInnDBContext _context;

        public RoomLocationAmenitiesController(AsyncInnDBContext context)
        {
            _context = context;
        }

        // GET: RoomLocationAmenities
        public async Task<IActionResult> Index()
        {
            var asyncInnDBContext = _context.RoomLocationAmenities.Include(r => r.Amenities).Include(r => r.Location);
            return View(await asyncInnDBContext.ToListAsync());
        }

        // GET: RoomLocationAmenities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomLocationAmenities = await _context.RoomLocationAmenities
                .Include(r => r.Amenities)
                .Include(r => r.Location)
                .FirstOrDefaultAsync(m => m.RoomLocationId == id);
            if (roomLocationAmenities == null)
            {
                return NotFound();
            }

            return View(roomLocationAmenities);
        }

        // GET: RoomLocationAmenities/Create
        public IActionResult Create()
        {
            ViewData["AmenityPackageId"] = new SelectList(_context.AmenityPackages, "AmenityPackageId", "AmenityPackageId");
            ViewData["RoomLocationId"] = new SelectList(_context.RoomLocations, "RoomLocationId", "RoomLocationId");
            return View();
        }

        // POST: RoomLocationAmenities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomLocationId,AmenityPackageId")] RoomLocationAmenities roomLocationAmenities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomLocationAmenities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AmenityPackageId"] = new SelectList(_context.AmenityPackages, "AmenityPackageId", "AmenityPackageId", roomLocationAmenities.AmenityPackageId);
            ViewData["RoomLocationId"] = new SelectList(_context.RoomLocations, "RoomLocationId", "RoomLocationId", roomLocationAmenities.RoomLocationId);
            return View(roomLocationAmenities);
        }

        // GET: RoomLocationAmenities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomLocationAmenities = await _context.RoomLocationAmenities.FindAsync(id);
            if (roomLocationAmenities == null)
            {
                return NotFound();
            }
            ViewData["AmenityPackageId"] = new SelectList(_context.AmenityPackages, "AmenityPackageId", "AmenityPackageId", roomLocationAmenities.AmenityPackageId);
            ViewData["RoomLocationId"] = new SelectList(_context.RoomLocations, "RoomLocationId", "RoomLocationId", roomLocationAmenities.RoomLocationId);
            return View(roomLocationAmenities);
        }

        // POST: RoomLocationAmenities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomLocationId,AmenityPackageId")] RoomLocationAmenities roomLocationAmenities)
        {
            if (id != roomLocationAmenities.RoomLocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomLocationAmenities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomLocationAmenitiesExists(roomLocationAmenities.RoomLocationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AmenityPackageId"] = new SelectList(_context.AmenityPackages, "AmenityPackageId", "AmenityPackageId", roomLocationAmenities.AmenityPackageId);
            ViewData["RoomLocationId"] = new SelectList(_context.RoomLocations, "RoomLocationId", "RoomLocationId", roomLocationAmenities.RoomLocationId);
            return View(roomLocationAmenities);
        }

        // GET: RoomLocationAmenities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomLocationAmenities = await _context.RoomLocationAmenities
                .Include(r => r.Amenities)
                .Include(r => r.Location)
                .FirstOrDefaultAsync(m => m.RoomLocationId == id);
            if (roomLocationAmenities == null)
            {
                return NotFound();
            }

            return View(roomLocationAmenities);
        }

        // POST: RoomLocationAmenities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomLocationAmenities = await _context.RoomLocationAmenities.FindAsync(id);
            _context.RoomLocationAmenities.Remove(roomLocationAmenities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomLocationAmenitiesExists(int id)
        {
            return _context.RoomLocationAmenities.Any(e => e.RoomLocationId == id);
        }
    }
}
