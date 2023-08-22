using Microsoft.AspNetCore.Mvc;

namespace TravelAir.ViewModels
{
    public class VM_Company_Create
    {
        public string Name { get; set; }

        public string IATA_Code { get; set; }

        public string ImageName { get; set; }

        public IFormFile Image { get; set; }

    }

}
