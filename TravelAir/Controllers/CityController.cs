using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelAir.Data;
using TravelAir.Models;
using TravelAir.ViewModels;

namespace TravelAir.Controllers
{
    public class CityController : Controller
    {
        private readonly TravelAirDbContext _context;

        public CityController(TravelAirDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var cities = await _context.Cities.Include(c => c.Country).ToListAsync();
            return View(cities);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Countries = new SelectList (_context.Countries, "Id", "Name" );
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VM_City vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            City city = new City(){
                Name = vm.Name,
                Abbreviation = vm.Abbreviation,
                CountryId = vm.CountryId
            };

            await _context.AddAsync(city);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var city = await _context.Cities.FirstOrDefaultAsync(c => c.Id == id);

            if(city == null)
                return View();

            _context.Remove(city);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Countries = new SelectList(_context.Countries, "Id", "Name");

            var city = _context.Cities.FirstOrDefault(c => c.Id == id);

            return View(city);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, VM_City vm)
        {
            var city = await _context.Cities.FirstOrDefaultAsync(c => c.Id == id);

            if(city != null)
            {
                city.Name = vm.Name;
                city.Abbreviation = vm.Abbreviation;
                city.CountryId = vm.CountryId;

                _context.Update(city);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View();
        }



    }
}
