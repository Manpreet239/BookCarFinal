using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookCar.Data;
using BookCar.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BookCar.Controllers
{
        public class CarsController : Controller
        {
            private readonly BookCarContext _context;

            public CarsController(BookCarContext context)
            {
                _context = context;
            }

            // GET: Cars
            public async Task<IActionResult> Index()
            {
            if (HttpContext.Session.GetString("Id") != null || HttpContext.Session.GetString("Name") != null)
            {
                var value = HttpContext.Session.GetString("Id");
                var name = HttpContext.Session.GetString("Name");
                var login = _context.Login.Where(x => x.Id == Convert.ToInt32(value)).FirstOrDefault();

                if (name == "Admin@admin.com")
                {
                    return View(await _context.Cars.ToListAsync());
                    }
                    else
                    {
                    if (_context.Cars.ToList().Count == 0)
                    {
                        return RedirectToAction(nameof(CarNotFound));
                    }
                    else
                    return RedirectToAction("Index", "Car");
                    }
            }
            else
                return RedirectToAction("UserLogin", "Logins");
            }

            // GET: Cars/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Cars = await _context.Cars
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Cars == null)
                {
                    return NotFound();
                }

                return View(Cars);
            }
        public IActionResult CarNotFound()
        {
            return View();
        }
        
        // GET: Cars/Create
        public IActionResult Create()
            {
            var CarPrices = _context.Cars.ToList();
            CarPrices.Insert(0, new Cars { Id = 0, CarName = "Select Car" });
            ViewBag.ListCarPrices = CarPrices;
            return View();
            }

            // POST: Cars/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,CarName,CarModel,CarAge,CarPrice")] Cars Cars)
            {
                if (ModelState.IsValid)
                {
                    //Cars.UserId = Convert.ToInt32(HttpContext.Session.GetString("Id"));
                    _context.Add(Cars);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(Cars);
            }

            // GET: Cars/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Cars = await _context.Cars.FindAsync(id);
                if (Cars == null)
                {
                    return NotFound();
                }
                return View(Cars);
            }

            // POST: Cars/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,CarName,CarModel,CarAge,CarPrice")] Cars Cars)
            {
                if (id != Cars.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(Cars);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CarsExists(Cars.Id))
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
                return View(Cars);
            }

            // GET: Cars/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Cars = await _context.Cars
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Cars == null)
                {
                    return NotFound();
                }

                return View(Cars);
            }

            // POST: Cars/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var Cars = await _context.Cars.FindAsync(id);
                _context.Cars.Remove(Cars);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool CarsExists(int id)
            {
                return _context.Cars.Any(e => e.Id == id);
            }
        }
    }
