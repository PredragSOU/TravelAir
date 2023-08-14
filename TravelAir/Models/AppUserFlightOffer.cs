using TravelAir.Areas.Identity.Data;

namespace TravelAir.Models
{
    public class AppUserFlightOffer
    {
        public string AppUserId { get; set; }

        public ApplicationUser AppUser { get; set; }


        public int FlightOfferId { get; set; }

        public FlightOffer FlightOffer { get; set; }
    }
}
