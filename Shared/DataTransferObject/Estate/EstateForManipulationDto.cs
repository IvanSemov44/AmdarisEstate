    namespace IvanRealEstate.Shared.DataTransferObject.Estate
{
    using IvanRealEstate.Shared.DataTransferObject.Image;
    using System.ComponentModel.DataAnnotations;

    public record EstateForManipulationDto
    {
        public Guid? OwnerId { get; init; }

        [Required(ErrorMessage = "Neighborhood is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Neighborhood is 100 characters.")]
        public string? Neighborhood { get; init; }

        [Required(ErrorMessage = "Address is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Address is 100 characters.")]
        public string? Address { get; init; }

        [Required(ErrorMessage = "Description is a required field.")]
        [MaxLength(1000, ErrorMessage = "Maximum length for the Description is 1000 characters.")]
        public string? Description { get; init; }

        [Range(0, int.MaxValue, ErrorMessage = "YearOfCreation is Required and it can't be lower than 0.")]
        public int YearOfCreation { get; init; }

        [Range(0, double.MaxValue, ErrorMessage = "Price is Required and it can't be lower than 0.")]
        public double Price { get; init; }

        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Floоr is Required.")]
        public int Floor { get; init; }

        [Range(0, int.MaxValue, ErrorMessage = "Rooms is Required and it can't be lower than 0.")]
        public int Rooms { get; init; }

        [Required(ErrorMessage = "Extras is a required field.")]
        [MaxLength(1000, ErrorMessage = "Maximum length for the Extras is 1000 characters.")]
        public string? Extras { get; init; }

        public bool Sell { get; init; }

        public double? EstateArea { get; set; }

        public DateTime? Created { get; init; }

        public DateTime? Changed { get; init; }

        public Guid CityId { get; init; }

        public Guid CurencyId { get; init; }

        public Guid CountryId { get; init; }

        public Guid EstateTypeId { get; init; }

        public IEnumerable<ImageDto>? Images { get; init; }

    }
}
