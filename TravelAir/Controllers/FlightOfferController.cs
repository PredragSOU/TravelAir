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
            ViewBag.OC = new SelectList(_context.Cities.OrderBy(c => c.Name), "Name", "Name");
            ViewBag.DC = new SelectList(_context.Cities.OrderBy(c => c.Name), "Name", "Name");
            ViewBag.CC = new SelectList(_context.CabinClasses.OrderBy(c => c.Name), "Name", "Name");
            

            var flightOffers = await _context.FlightOffers
                 .Include(fo => fo.CabinClass)
                 .Include(fo => fo.Company)
                 .Include(fo => fo.Airport)
                 .ThenInclude(fo => fo.City)
                 .ThenInclude(fo => fo.Country).ToListAsync();



            return View(flightOffers);

        }

        [HttpPost]
        public async Task<IActionResult> Index(string searchOriginCities, string searchDestinationCities, DateTime searchDepartureDate, string searchCabinClass)
        {
            ViewBag.OC = new SelectList(_context.Cities.OrderBy(c => c.Name), "Name", "Name");
            ViewBag.DC = new SelectList(_context.Cities.OrderBy(c => c.Name), "Name", "Name");
            ViewBag.DepartureDate = searchDepartureDate;
            ViewBag.CC = new SelectList(_context.CabinClasses.OrderBy(c => c.Name), "Name", "Name");

            var flightOffers = await _context.FlightOffers
                .Include(fo => fo.CabinClass)
                .Include(fo => fo.Company)
                .Include(fo => fo.Airport)
                .ThenInclude(fo => fo.City)
                .ThenInclude(fo => fo.Country)
                .Where(fo => 
                fo.OriginCity == searchOriginCities && 
                fo.DestinationCity == searchDestinationCities &&
                fo.DepartureDate.Date == searchDepartureDate.Date &&
                fo.CabinClass.Name == searchCabinClass)
                .ToListAsync();

            return View(flightOffers);
        }
    


   

        [HttpGet]
        public IActionResult CreateAsync()
        {
            var airports = new SelectList(_context.Airports, "Id", "Name");
   

            ViewBag.Airports = new SelectList(_context.Airports, "Id", "Name");

            ViewBag.OriginCountries = new SelectList(_context.Countries, "Name", "Name");
            ViewBag.OriginCities = new SelectList(_context.Cities, "Name", "Name");

            ViewBag.DestinationCountries = new SelectList(_context.Countries, "Name", "Name");
            ViewBag.DestinationCities = new SelectList(_context.Cities, "Name", "Name");
            ViewBag.DestinationAirports = new SelectList(_context.Airports, "Name", "Name");

            ViewBag.CabinClasses = new SelectList(_context.CabinClasses, "Id", "Name");
            ViewBag.Companies = new SelectList(_context.Companies, "Id", "Name");


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
                OriginCountry = vm.OriginCountry,
                OriginCity = vm.OriginCity,
                DestinationCountry = vm.DestinationCountry,
                DestinationCity = vm.DestinationCity,
                DestinationAirport = vm.DestinationAirport,
                DepartureDate = vm.DepartureDate,
                ReturnDate = vm.ReturnDate,
                Length = vm.Length,
                Price = vm.Price,
                URL = vm.URL,
                CabinClassId = vm.CabinClassId,
                CompanyId = vm.CompanyId,
                AirportId = vm.AirportId
            };

            await _context.FlightOffers.AddAsync(flightOffer);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");        
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var flightOffer = _context.FlightOffers.Include(fo => fo.CabinClass).FirstOrDefault(fo => fo.Id == id);

            return View(flightOffer);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var flightOffer = _context.FlightOffers.FirstOrDefault(fo => fo.Id == id);

            if (flightOffer == null)
                return View();


            _context.Remove(flightOffer);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
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

                flightOffer.DepartureDate = vm.DepartureDate;
                flightOffer.Length = vm.Length;
                flightOffer.Price = vm.Price;
                flightOffer.URL = vm.URL;
                flightOffer.CabinClassId = vm.CabinClassId;
                flightOffer.CompanyId = vm.CompanyId;

                _context.Update(flightOffer);
                await _context.SaveChangesAsync();
                
                return(RedirectToAction("Index"));
            }

            return View();
        }

    }
}
