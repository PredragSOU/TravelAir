using System.ComponentModel.DataAnnotations;

namespace TravelAir.Models
{
    public class FlightOffer
    {
        public int Id { get; set; }

        public string OriginCity { get; set; }

        public string OriginCountry { get; set; }

        public string DestinationAirport { get; set; }

        public string DestinationCity { get; set; }

        public string DestinationCountry { get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public TimeSpan Length { get; set; }

        [DataType(DataType.Currency)]
        public float Price { get; set; }

        public string URL { get; set; }


        public int AirportId { get; set; }

        public Airport Airport { get; set; }


        public int CabinClassId { get; set; }

        public CabinClass CabinClass { get; set; }

        
        public int CompanyId { get; set; }

        public Company Company { get; set; }


  


        public ICollection<AppUserFlightOffer> AppUserFlightOffers { get; set; }
    }
}
