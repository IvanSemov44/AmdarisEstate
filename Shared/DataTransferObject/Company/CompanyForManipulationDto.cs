namespace IvanRealEstate.Shared.DataTransferObject.Company
{
    using IvanRealEstate.Shared.DataTransferObject.Image;
    using System.ComponentModel.DataAnnotations;

    public abstract record CompanyForManipulationDto
    {
        [Required(ErrorMessage = "Company name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string? Name { get; init; }

        [Required(ErrorMessage = "Company address is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the address is 30 characters.")]
        public string? Address { get; init; }

        [Required(ErrorMessage = "Description address is a required field.")]
        [MaxLength(200, ErrorMessage = "Maximum length for the Description is 200 characters.")]
        public string? Description { get; set; }

        public Guid? CompanyCityId { get; init; }
        public Guid? CompanyCountryId { get; set; }

        public ICollection<ImageForManipulationDto>? Images { get; set; }
    };
}
