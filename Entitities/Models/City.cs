namespace Entities.Models
{
    public class City
    {
        public Guid CityId { get; set; }

        public string? CityName { get; set; }

        public ICollection<Estate>? Estate { get; set; }
    }
}
