using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;

namespace AsyncInn.Controllers
{
    public class AmenityPackagesController : Controller
    {
        private readonly IAmenityPackageManager _context;

        public AmenityPackagesController(IAmenityPackageManager context)
        {
            _context = context;
        }

        // GET: AmenityPackages
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAmenityPackages());
        }

        // GET: AmenityPackages/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var amenityPackage = await _context.GetAmenityPackage(id);
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
                await _context.CreateAmenityPackage(amenityPackage);
                return RedirectToAction(nameof(Index));
            }
            return View(amenityPackage);
        }

        // GET: AmenityPackages/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var amenityPackage = await _context.GetAmenityPackage(id);
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
                    _context.UpdateAmenityPackage(id, amenityPackage);
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
        public async Task<IActionResult> Delete(int id)
        {
            var amenityPackage = await _context.GetAmenityPackage(id);
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
            var amenityPackage = await _context.GetAmenityPackage(id);
            _context.DeleteAmenityPackage(amenityPackage);
            return RedirectToAction(nameof(Index));
        }

        private bool AmenityPackageExists(int id)
        {
            var amenityPackage = _context.GetAmenityPackage(id);
            if (amenityPackage != null) return true;
            return false;
        }
    }
}
