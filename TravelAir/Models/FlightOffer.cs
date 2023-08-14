using System.ComponentModel.DataAnnotations;

namespace TravelAir.Models
{
    public class FlightOffer
    {
        public int Id { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public TimeSpan Length { get; set; }

        [DataType(DataType.Currency)]
        public float Price { get; set; }

        public string URL { get; set; }



        public int CabinClassId { get; set; }

        public CabinClass CabinClass { get; set; }


        public ICollection<AppUserFlightOffer> AppUserFlightOffers { get; set; }
    }
}
