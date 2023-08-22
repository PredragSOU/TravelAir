using Microsoft.AspNetCore.Mvc;
using TravelAir.Data;
using TravelAir.Models;
using TravelAir.ViewModels;

namespace TravelAir.Controllers
{
    public class CountryController : Controller
    {
        private readonly TravelAirDbContext _context;

        public CountryController(TravelAirDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var countries = _context.Countries.ToList();
            var countriesVM = new List<VM_Country_Index>();

            foreach(var item in countries)
            {
                VM_Country_Index vm = new VM_Country_Index();
                vm.Name = item.Name;
                vm.Abbreviation = item.Abbreviation;
                countriesVM.Add(vm);
            }

            return View(countriesVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> Create(VM_Country vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Country country = new Country()
            {
                Name = vm.Name,
                Abbreviation = vm.Abbreviation
            };

            await _context.AddAsync(country);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var country = _context.Countries.FirstOrDefault(c => c.Id == id);

            if (country == null)
            {
                return View();
               
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var country = _context.Countries.FirstOrDefault(c => c.Id == id);

            return View(country);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, VM_Country vm)
        {
            var country = _context.Countries.FirstOrDefault(c => c.Id == id);

            if(country != null)
            {
                country.Name = vm.Name; 
                country.Abbreviation = vm.Abbreviation;

                _context.Update(country);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View();
        }      
    }
}
