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
    public class CustomersController : Controller
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


            var customers = from c in _context.Customers
                           select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(c => c.Name.Contains(searchString));
            }


            //switch (sortOrder)
            //{
            //    case "name_desc":
            //        souvenirs = souvenirs.OrderByDescending(s => s.Name);
            //        break;
            //    case "CategoryID":
            //        souvenirs = souvenirs.OrderBy(s => s.CategoryID);
            //        break;
            //    case "categoryID_desc":
            //        souvenirs = souvenirs.OrderByDescending(s => s.CategoryID);
            //        break;
            //    default:
            //        souvenirs = souvenirs.OrderBy(s => s.Name);
            //        break;
            //}

            int pageSize = 15;
            return View(await PaginatedList<Customer>.CreateAsync(customers.AsNoTracking(), pageNumber ?? 1, pageSize));
            //return View(await souvenirs.AsNoTracking().ToListAsync());
            //return View(await _context.Souvenirs.ToListAsync());
        }

        private readonly SouvenirshopContext _context;

        public CustomersController(SouvenirshopContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .SingleOrDefaultAsync(m => m.CustomerID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }


        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }
        // Post: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,PhoneNumber,EmailAddress,Address,Enabled")] Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(customer);
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
            return View(customer);
        }

        // GET: Customer/Edit
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
            var customerToUpdate = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerID == id);
            if (await TryUpdateModelAsync<Customer>(
                customerToUpdate,
                "",
                c => c.Name, c => c.PhoneNumber, c => c.EmailAddress, c => c.Address,c => c.Enabled))
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
            return View(customerToUpdate);
        }

        // GET: Souvenir/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .SingleOrDefaultAsync(m => m.CustomerID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Souvenir/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(m => m.CustomerID == id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
