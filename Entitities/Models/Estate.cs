
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Estate
    {
        [Required]
        public Guid EstateId { get; set; }

        //[Required(ErrorMessage ="City is a required field.")]
        //[MaxLength(100,ErrorMessage ="Maximum length for the City is 100 characters.  ")]
        //public string? City { get; set; }

        [MaxLength(100, ErrorMessage = "Maximum length for the Neighborhood is 100 characters.  ")]
        public string? Neighborhood { get; set; }

        [Required(ErrorMessage = "City is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Address is 100 characters.  ")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "City is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the City is 100 characters.  ")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "City is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the City is 100 characters.  ")]
        public string? YearOfCreation { get; set; }

        public decimal Price { get; set; }

        public int Floоr { get; set; }

        public int Rooms { get; set; }

        public string? Extras { get; set; }

        public bool Sell { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Changed { get; set; }

        public ICollection<Image>? Images { get; set; }

        public Guid CityId { get; set; }
        public City? City { get; set; }

        public Guid CurencyId { get; set; }
        public Curency? Currency { get; set; }

        public Guid CountryId { get; set; }
        public Country? Country { get; set; }

        public Guid EstateTypeId { get; set; }
        public EstateType? EstateType { get; set; }
        //public Curency Curency { get; set; }

    }
}
