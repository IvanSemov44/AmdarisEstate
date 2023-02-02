
namespace IvanRealEstate.Entities.Models
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public ICollection<Estate>? Estate { get; set; }
        public ICollection<Message>? Message { get; set; }
        public ICollection<Image>? Images { get; set; }

        public Guid UserCityId { get; set; }
        public City? City { get; set; }

        public Guid UserCountryId { get; set; }
        public Country? Country { get; set; }

        public Guid UserCompanyId { get; set; }
        public Company? Company { get; set; }

    }
}
