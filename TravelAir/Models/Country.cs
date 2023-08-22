namespace TravelAir.Models
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abbreviation { get; set; }


        public ICollection<City> Cities { get; set; }
    }
}
