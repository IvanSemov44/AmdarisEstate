namespace IvanRealEstate.Shared.DataTransferObject.Message
{
    using System.ComponentModel.DataAnnotations;

    public abstract record MessageForManipulationDto
    {
        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Name is 100 characters.")]
        public string? Name { get; init; }

        [Required(ErrorMessage = "Email is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Email is 100 characters.")]
        public string? Email { get; init; }

        [Required(ErrorMessage = "Text is a required field.")]
        [MaxLength(1000, ErrorMessage = "Maximum length for the Text is 1000 characters.")]
        public string? Text { get; init; }

        public bool? IsRead { get; init; }

        public DateTime? Created { get; init; }
    }
}
