using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAir.Data;
using TravelAir.Models;
using TravelAir.ViewModels;

namespace TravelAir.Controllers
{
    public class CompanyController : Controller
    {
        private readonly TravelAirDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CompanyController(TravelAirDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            List<Company> companies = await _context.Companies.ToListAsync();
            return View(companies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VM_Company_Create vm)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(vm.Image.FileName);
                string extension = Path.GetExtension(vm.Image.FileName);

                vm.ImageName = fileName = fileName + "-img-" + extension;
                string path = Path.Combine(wwwRootPath + "/images/company/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await vm.Image.CopyToAsync(fileStream);
                }

                var company = new Company()
                {
                    Name = vm.Name,
                    ImageName = vm.ImageName,
                    IATA_Code = vm.IATA_Code
                };

                _context.Add(company);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var company = _context.Companies.FirstOrDefault(c => c.Id == id);

            if(company == null)
            {
                return View();
            }

            _context.Remove(company);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var company = _context.Companies.FirstOrDefault(c => c.Id == id);

            return View(company);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, VM_Company_Create vm)
        {
            var company = _context.Companies.FirstOrDefault(fo => fo.Id == id);

            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(vm.Image.FileName);
            string extension = Path.GetExtension(vm.Image.FileName);

            vm.ImageName = fileName = "Comp_Img_" + fileName + extension;
            string path = Path.Combine(wwwRootPath + "/images/company/", fileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await vm.Image.CopyToAsync(fileStream);
            }

            if (company != null)
            {
                company.Name = vm.Name;
                company.ImageName = vm.ImageName;
                company.IATA_Code = vm.IATA_Code;

                _context.Update(company);
                await _context.SaveChangesAsync();

                return (RedirectToAction("Index"));
            }

            return View();
        }
    }
}