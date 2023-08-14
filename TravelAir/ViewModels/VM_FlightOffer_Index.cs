using TravelAir.Models;

namespace TravelAir.ViewModels
{
    public class VM_FlightOffer_Index
    {
        public string Origin { get; set; }

        public string Destination { get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public TimeSpan Length { get; set; }

        public float Price { get; set; }

        public string URL { get; set; }



    }
}
