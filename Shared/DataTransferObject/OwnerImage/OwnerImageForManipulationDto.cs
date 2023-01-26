
using System.ComponentModel.DataAnnotations;

namespace IvanRealEstate.Shared.DataTransferObject.OwnerImage
{
    public abstract record OwnerImageForManipulationDto
    {
        [Required(ErrorMessage = "ImageUrl is a required field.")]
        public string? ImageUrl { get; init; }
        public bool? DefaultImg { get; set; }
    }
}
