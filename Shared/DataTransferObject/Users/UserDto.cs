namespace IvanRealEstate.Shared.DataTransferObject.Users
{
    using IvanRealEstate.Shared.DataTransferObject.Image;
    using IvanRealEstate.Shared.DataTransferObject.Estate;

    public record UserDto
    {
        public Guid Id { get; init; }
        public string? UserName { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public Guid? UserCityId { get; init; }
        public Guid? UserCountryId { get; init; }
        public Guid UserCompanyId { get; init; }

        //public string? UserName { get; init; }
        public ICollection<EstateDto>? Estate { get; init; }
        public ICollection<ImageDto>? Images { get; init; }

    }
}
