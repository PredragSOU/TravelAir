using System.ComponentModel.DataAnnotations;

namespace TravelAir.Models
{
    public class CabinClass
    {
        public int Id { get; set; }

        [Display(Name = "Class")]
        public string Name { get; set; }


        public ICollection<FlightOffer> FlightOffers { get; set; }
    }
}
