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
    public class CarController : Controller
    {
        private readonly BookCarContext _context;

        public CarController(BookCarContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
          return View(await _context.Cars.ToListAsync());
        }
        public async Task<IActionResult> AddBook(int? id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var value = HttpContext.Session.GetString("Id");

                CarBook buyBook = new CarBook();
                var book = _context.Cars.Where(x => x.Id == id).FirstOrDefault();
                buyBook.CarName = book.CarName;
                buyBook.CarModel = book.CarModel;
                buyBook.CarAge = book.CarAge;
                buyBook.CarPrice = book.CarPrice;
                buyBook.UserId = Convert.ToInt32(value);
                _context.Add(buyBook);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "UserCars");
            }
            else
                return RedirectToAction("UserLogin", "Logins");
        }

    }
}
