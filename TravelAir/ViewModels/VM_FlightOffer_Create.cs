using TravelAir.Models;

namespace TravelAir.ViewModels
{
    public class VM_FlightOffer_Create
    {
        public string OriginCity { get; set; }

        public string OriginCountry { get; set; }

        public string DestinationAirport { get; set; }

        public string DestinationCity { get; set; }

        public string DestinationCountry { get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public TimeSpan Length { get; set; }

        public float Price { get; set; }

        public string URL { get; set; }

        public int CabinClassId { get; set; }

        public int CompanyId { get; set; }

        public int AirportId { get; set; }




    }
}
