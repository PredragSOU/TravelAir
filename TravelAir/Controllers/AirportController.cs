using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelAir.Data;
using TravelAir.Models;
using TravelAir.ViewModels;

namespace TravelAir.Controllers
{
    public class AirportController : Controller
    {
        private readonly TravelAirDbContext _context;

        public AirportController(TravelAirDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var airports = await _context.Airports.Include(a => a.City).ToListAsync();

            return View(airports);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Cities = new SelectList(_context.Cities, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VM_Airport vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Airport airport = new Airport()
            {
                Name = vm.Name,
                Address = vm.Address,
                IATA_Code = vm.IATA_Code,
                CityId = vm.CityId
            };

            await _context.Airports.AddAsync(airport);  
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var airport = await _context.Airports.FirstOrDefaultAsync(a => a.Id == id);

            if (airport == null)
                return View();

            _context.Remove(airport);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Cities = new SelectList(_context.Cities, "Id", "Name");

            var airport = await _context.Airports.FirstOrDefaultAsync(a => a.Id == id);

            return View(airport);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, VM_Airport vm)
        {
            var airport = await _context.Airports.FirstOrDefaultAsync(a => a.Id == id);

            if(airport != null)
            {
                airport.Name = vm.Name;
                airport.Address = vm.Address;
                airport.IATA_Code = vm.IATA_Code;
                airport.CityId = vm.CityId;

                _context.Update(airport);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
