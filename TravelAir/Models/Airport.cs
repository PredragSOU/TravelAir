using System.ComponentModel.DataAnnotations;

namespace TravelAir.Models
{
    public class Airport
    {
        public int Id { get; set; }

        public string Name { get; set; }    

        public string Address { get; set; }

        public string IATA_Code { get; set; }


        public int CityId { get; set; }

        public City City { get; set; }


        public ICollection<Origin> Origins { get; set; }

        public ICollection<Destination> Destinations { get; set; }
  
    }

}

