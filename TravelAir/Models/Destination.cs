namespace TravelAir.Models
{
    public class Destination
    {
        public int Id { get; set; }


        public int AirportId { get; set; }

        public Airport Airport { get; set; }


    }
}
