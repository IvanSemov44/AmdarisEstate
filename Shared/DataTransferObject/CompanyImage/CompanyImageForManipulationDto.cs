

using System.ComponentModel.DataAnnotations;

namespace IvanRealEstate.Shared.DataTransferObject.CompanyImage
{
    public abstract record CompanyImageForManipulationDto
    {
        [Required(ErrorMessage = "ImageUrl is a required field.")]
        public string? ImageUrl { get; init; }
        public bool? DefaultImg { get; set; }
    }
}
