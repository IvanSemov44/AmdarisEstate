namespace IvanRealEstate.Shared.DataTransferObject.Users
{
    using System.ComponentModel.DataAnnotations;

    public class UserForRegistrationDto
    {
        public string? FirstName { get; init; }

        public string? LastName { get; init; }

        [Required(ErrorMessage = "UserName name is a required field.")]
        public string? UserName { get; init; }

        [Required(ErrorMessage = "Password name is a required field.")]
        public string? Password { get; init; }

        public string? Email { get; init; }

        public string? PhoneNumber { get; init; }
        public Guid? UserCityId { get; init; }
        public Guid? UserCountryId { get; init; }

        public ICollection<string>? Roles { get; init; }
    }
}
