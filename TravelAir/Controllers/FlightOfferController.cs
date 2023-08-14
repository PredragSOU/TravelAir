using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelAir.Data;
using TravelAir.Models;
using TravelAir.ViewModels;

namespace TravelAir.Controllers
{
    public class FlightOfferController : Controller
    {
        private readonly TravelAirDbContext _context;

        public FlightOfferController(TravelAirDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var flightOffers = await _context.FlightOffers.Include(fo => fo.CabinClass).ToListAsync();
            return View(flightOffers);
        }

        [HttpGet]
        public IActionResult CreateAsync()
        {
            ViewBag.CabinClassNames = new SelectList(_context.CabinClasses, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VM_FlightOffer_Create vm)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var flightOffer = new FlightOffer()
            {
                Origin = vm.Origin,
                Destination = vm.Destination,
                DepartureDate = vm.DepartureDate,
                ReturnDate = vm.ReturnDate,
                Length = vm.Length,
                Price = vm.Price,
                URL = vm.URL,
                CabinClassId = vm.CabinClassId
            };

            await _context.FlightOffers.AddAsync(flightOffer);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");        
        }

        public async Task<IActionResult> Delete(int id)
        {
            var flightOffer = _context.FlightOffers.FirstOrDefault(fo => fo.Id == id);

            if (flightOffer == null)
            {
                return View();
            }

            _context.Remove(flightOffer);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {

            var flightOffer = _context.FlightOffers.Include(fo => fo.CabinClass).FirstOrDefault(fo => fo.Id == id);

            return View(flightOffer);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.CabinClassNames = new SelectList(_context.CabinClasses, "Id", "Name");

            var flightOffer = _context.FlightOffers.FirstOrDefault(fo => fo.Id == id);

            return View(flightOffer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, VM_FlightOffer_Create vm)
        {
            var flightOffer = _context.FlightOffers.FirstOrDefault(fo => fo.Id == id);

            if(flightOffer != null) {

                flightOffer.Origin = vm.Origin;
                flightOffer.Destination = vm.Destination;
                flightOffer.DepartureDate = vm.DepartureDate;
                flightOffer.ReturnDate = vm.ReturnDate;
                flightOffer.Length = vm.Length;
                flightOffer.Price = vm.Price;
                flightOffer.URL = vm.URL;
                flightOffer.CabinClassId = vm.CabinClassId;

                await _context.SaveChangesAsync();
                
                return(RedirectToAction("Index"));
            }

            return View();
        }

    }
}
