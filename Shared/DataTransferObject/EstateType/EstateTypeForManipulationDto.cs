namespace IvanRealEstate.Shared.DataTransferObject.EstateType
{
    using System.ComponentModel.DataAnnotations;

    public abstract record EstateTypeForManipulationDto
    {
        [Required(ErrorMessage = "TypeName name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the TypeName is 30 characters.")]
        public string? TypeName { get; init; }

    }
}
