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
    public class SouvenirController : Controller
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
            ViewData["CategorySortParm"] = sortOrder == "CategoryID" ? "categoryID_desc" : "CategoryID";
           

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;


            var souvenirs = from s in _context.Souvenirs
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                souvenirs = souvenirs.Where(s => s.Name.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "name_desc":
                    souvenirs = souvenirs.OrderByDescending(s => s.Name);
                    break;
                case "CategoryID":
                    souvenirs = souvenirs.OrderBy(s => s.CategoryID);
                    break;
                case "categoryID_desc":
                    souvenirs = souvenirs.OrderByDescending(s => s.CategoryID);
                    break;
                default:
                    souvenirs = souvenirs.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 15;
            return View(await PaginatedList<Souvenir>.CreateAsync(souvenirs.AsNoTracking(), pageNumber ?? 1, pageSize));
            //return View(await souvenirs.AsNoTracking().ToListAsync());
            //return View(await _context.Souvenirs.ToListAsync());
        }

        private readonly SouvenirshopContext _context;

        public SouvenirController(SouvenirshopContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var souvenir = await _context.Souvenirs
                .SingleOrDefaultAsync(m => m.SouvenirID == id);
            if (souvenir == null)
            {
                return NotFound();
            }

            return View(souvenir);
        }


        // GET: Souvenir/Create
        public IActionResult Create()
        {
            return View();
        }
        // Post: Souvenir/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Price,Description,Image,SupplierID,CategoryID")] Souvenir souvenir)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(souvenir);
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
            return View(souvenir);
        }

        // GET: Souvenir/Edit
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
            var souvenirToUpdate = await _context.Souvenirs.FirstOrDefaultAsync(s => s.SouvenirID == id);
            if (await TryUpdateModelAsync<Souvenir>(
                souvenirToUpdate,
                "",
                s => s.Name, s => s.Price, s => s.Description, s => s.Image,s => s.CategoryID, s => s.SupplierID))
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
            return View(souvenirToUpdate);
        }

        // GET: Souvenir/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Souvenirs
                .SingleOrDefaultAsync(m => m.SouvenirID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Souvenir/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Souvenirs.SingleOrDefaultAsync(m => m.SouvenirID == id);
            _context.Souvenirs.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
