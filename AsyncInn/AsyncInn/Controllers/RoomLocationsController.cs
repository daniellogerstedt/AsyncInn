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
    public class RoomLocationsController : Controller
    {
        private readonly AsyncInnDBContext _context;

        public RoomLocationsController(AsyncInnDBContext context)
        {
            _context = context;
        }

        // GET: RoomLocations
        public async Task<IActionResult> Index()
        {
            var asyncInnDBContext = _context.RoomLocations.Include(r => r.Location).Include(r => r.Room);
            return View(await asyncInnDBContext.ToListAsync());
        }

        // GET: RoomLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomLocation = await _context.RoomLocations
                .Include(r => r.Location)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.RoomLocationId == id);
            if (roomLocation == null)
            {
                return NotFound();
            }

            return View(roomLocation);
        }

        // GET: RoomLocations/Create
        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationId");
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId");
            return View();
        }

        // POST: RoomLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomLocationId,RoomId,LocationId,Price,PetFriendly")] RoomLocation roomLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationId", roomLocation.LocationId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId", roomLocation.RoomId);
            return View(roomLocation);
        }

        // GET: RoomLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomLocation = await _context.RoomLocations.FindAsync(id);
            if (roomLocation == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationId", roomLocation.LocationId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId", roomLocation.RoomId);
            return View(roomLocation);
        }

        // POST: RoomLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomLocationId,RoomId,LocationId,Price,PetFriendly")] RoomLocation roomLocation)
        {
            if (id != roomLocation.RoomLocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomLocationExists(roomLocation.RoomLocationId))
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
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationId", roomLocation.LocationId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId", roomLocation.RoomId);
            return View(roomLocation);
        }

        // GET: RoomLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomLocation = await _context.RoomLocations
                .Include(r => r.Location)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.RoomLocationId == id);
            if (roomLocation == null)
            {
                return NotFound();
            }

            return View(roomLocation);
        }

        // POST: RoomLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomLocation = await _context.RoomLocations.FindAsync(id);
            _context.RoomLocations.Remove(roomLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomLocationExists(int id)
        {
            return _context.RoomLocations.Any(e => e.RoomLocationId == id);
        }
    }
}
