using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAir.Models
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string IATA_Code { get; set; }

        public string ImageName { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }


        public ICollection<FlightOffer> FlightOffers { get; set; }
    }
}
