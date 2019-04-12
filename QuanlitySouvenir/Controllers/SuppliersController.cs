using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanlitySouvenir.Data;
using QuanlitySouvenir.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuanlitySouvenir.Controllers
{
    public class SuppliersController : Controller
    {
        // GET: /<controller>/
        public async Task<IActionResult> Index(
        string sortOrder,
        string searchString,
        string currentFilter,
        int? pageNumber
        )
        {
            ViewData["CurrentSort"] = sortOrder;

            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";


            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;


            var suppliers = from c in _context.Suppliers
                            select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                suppliers = suppliers.Where(c => c.Name.Contains(searchString));
            }

            int pageSize = 15;
            return View(await PaginatedList<Supplier>.CreateAsync(suppliers.AsNoTracking(), pageNumber ?? 1, pageSize));
            //return View(await souvenirs.AsNoTracking().ToListAsync());
            //return View(await _context.Souvenirs.ToListAsync());
        }

        private readonly SouvenirshopContext _context;

        public SuppliersController(SouvenirshopContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers
                .SingleOrDefaultAsync(m => m.SupplierID == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }


        // GET: Suppliers/Create
        public IActionResult Create()
        {
            return View();
        }
        // Post: Suppliers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,PhoneNumber,EmailAddress")] Supplier supplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(supplier);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(supplier);
        }

        // GET: supplier/Edit
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var supplierToUpdate = await _context.Suppliers.FirstOrDefaultAsync(c => c.SupplierID == id);
            if (await TryUpdateModelAsync<Supplier>(
                supplierToUpdate,
                "",
                c => c.Name, c => c.PhoneNumber, c => c.EmailAddress))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(supplierToUpdate);
        }

        // GET: Souvenir/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers
                .SingleOrDefaultAsync(m => m.SupplierID == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // POST: Souvenir/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplier = await _context.Suppliers.SingleOrDefaultAsync(m => m.SupplierID == id);
            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

