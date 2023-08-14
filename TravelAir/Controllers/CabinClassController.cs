using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAir.Data;
using TravelAir.Models;
using TravelAir.ViewModels;

namespace TravelAir.Controllers
{
    public class CabinClassController : Controller
    {
        private readonly TravelAirDbContext _context;

        public CabinClassController(TravelAirDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<CabinClass> cabinClasses = await _context.CabinClasses.ToListAsync();
            return View(cabinClasses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VM_CabinClass viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var cabinClass = new CabinClass()
            {
                Name = viewModel.Name
            };
  
            await _context.AddAsync(cabinClass);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var cabinClass = _context.CabinClasses.FirstOrDefault(c => c.Id == id);

            if (cabinClass == null)
            {
                return View();           
            }

            _context.CabinClasses.Remove(cabinClass);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cabinClass = _context.CabinClasses.FirstOrDefault(c => c.Id == id);
            return View(cabinClass);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, VM_CabinClass vm)
        {
            
            var cabinClass = _context.CabinClasses.FirstOrDefault(c => c.Id == id);

            if (cabinClass != null)
            {
                cabinClass.Name = vm.Name;
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View();
        }

    }
}
