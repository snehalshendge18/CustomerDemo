using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomerDemo;
using CustomerDemo.Models;

namespace CustomerDemo.Controllers
{
    public class CustomerFirstClassesTempController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerFirstClassesTempController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CustomerFirstClassesTemp
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerClass.ToListAsync());
        }

        // GET: CustomerFirstClassesTemp/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerFirstClass = await _context.CustomerClass
                .FirstOrDefaultAsync(m => m.CustmomerID == id);
            if (customerFirstClass == null)
            {
                return NotFound();
            }

            return View(customerFirstClass);
        }

        // GET: CustomerFirstClassesTemp/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerFirstClassesTemp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustmomerID,Product,Amount,Address,Contact")] CustomerFirstClass customerFirstClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerFirstClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerFirstClass);
        }

        // GET: CustomerFirstClassesTemp/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerFirstClass = await _context.CustomerClass.FindAsync(id);
            if (customerFirstClass == null)
            {
                return NotFound();
            }
            return View(customerFirstClass);
        }

        // POST: CustomerFirstClassesTemp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustmomerID,Product,Amount,Address,Contact")] CustomerFirstClass customerFirstClass)
        {
            if (id != customerFirstClass.CustmomerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerFirstClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerFirstClassExists(customerFirstClass.CustmomerID))
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
            return View(customerFirstClass);
        }

        // GET: CustomerFirstClassesTemp/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerFirstClass = await _context.CustomerClass
                .FirstOrDefaultAsync(m => m.CustmomerID == id);
            if (customerFirstClass == null)
            {
                return NotFound();
            }

            return View(customerFirstClass);
        }

        // POST: CustomerFirstClassesTemp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerFirstClass = await _context.CustomerClass.FindAsync(id);
            _context.CustomerClass.Remove(customerFirstClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerFirstClassExists(int id)
        {
            return _context.CustomerClass.Any(e => e.CustmomerID == id);
        }
    }
}
