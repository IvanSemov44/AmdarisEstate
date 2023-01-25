namespace IvanRealEstate.Entities.Models
{
    public class City
    {
        public Guid CityId { get; set; }

        public string? CityName { get; set; }

        public ICollection<Estate>? Estate { get; set; }
        public ICollection<Company>? Company { get; set; }
        public ICollection<User>? User { get; set; }
    }
}
