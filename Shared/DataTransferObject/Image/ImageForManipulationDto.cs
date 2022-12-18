using System.ComponentModel.DataAnnotations;

namespace IvanRealEstate.Shared.DataTransferObject.Image
{
    public abstract record ImageForManipulationDto
    {
        [Required(ErrorMessage = "ImageUrl is a required field.")]
        public string? ImageUrl { get; init; }
    }
}
