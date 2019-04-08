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
    public class AmenityPackagesController : Controller
    {
        private readonly AsyncInnDBContext _context;

        public AmenityPackagesController(AsyncInnDBContext context)
        {
            _context = context;
        }

        // GET: AmenityPackages
        public async Task<IActionResult> Index()
        {
            return View(await _context.AmenityPackages.ToListAsync());
        }

        // GET: AmenityPackages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amenityPackage = await _context.AmenityPackages
                .FirstOrDefaultAsync(m => m.AmenityPackageId == id);
            if (amenityPackage == null)
            {
                return NotFound();
            }

            return View(amenityPackage);
        }

        // GET: AmenityPackages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AmenityPackages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AmenityPackageId,Name,Cost,AC,OceanView,MountainView,Minibar,PrivateBeach,Hottub,Penthouse,Valet,ContinentalBreakfast,Coffee")] AmenityPackage amenityPackage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(amenityPackage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(amenityPackage);
        }

        // GET: AmenityPackages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amenityPackage = await _context.AmenityPackages.FindAsync(id);
            if (amenityPackage == null)
            {
                return NotFound();
            }
            return View(amenityPackage);
        }

        // POST: AmenityPackages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AmenityPackageId,Name,Cost,AC,OceanView,MountainView,Minibar,PrivateBeach,Hottub,Penthouse,Valet,ContinentalBreakfast,Coffee")] AmenityPackage amenityPackage)
        {
            if (id != amenityPackage.AmenityPackageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(amenityPackage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmenityPackageExists(amenityPackage.AmenityPackageId))
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
            return View(amenityPackage);
        }

        // GET: AmenityPackages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amenityPackage = await _context.AmenityPackages
                .FirstOrDefaultAsync(m => m.AmenityPackageId == id);
            if (amenityPackage == null)
            {
                return NotFound();
            }

            return View(amenityPackage);
        }

        // POST: AmenityPackages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var amenityPackage = await _context.AmenityPackages.FindAsync(id);
            _context.AmenityPackages.Remove(amenityPackage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AmenityPackageExists(int id)
        {
            return _context.AmenityPackages.Any(e => e.AmenityPackageId == id);
        }
    }
}
