
namespace IvanRealEstate.Entities.Models
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public ICollection<Estate>? Estate { get; set; }
        public ICollection<Message>? Message { get; set; }
    }
}
