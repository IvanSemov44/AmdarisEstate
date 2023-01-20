namespace IvanRealEstate.Entities.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Estate
    {
        [Required]
        public Guid EstateId { get; set; }

        [MaxLength(100, ErrorMessage = "Maximum length for the Neighborhood is 100 characters.")]
        public string? Neighborhood { get; set; }

        [Required(ErrorMessage = "Address is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Address is 100 characters.")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Description is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the City is 100 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "YearOfCreation is a required field.")]
        public int YearOfCreation { get; set; }

        public double Price { get; set; }

        public int Floor { get; set; }

        [Required(ErrorMessage = "Rooms is a required field.")]
        public int Rooms { get; set; }

        [Required(ErrorMessage = "Extras is a required field.")]
        [MaxLength(1000, ErrorMessage = "Maximum length for the Extras is 1000 characters.")]
        public string? Extras { get; set; }

        public double? EstateArea { get; set; }

        public bool Sell { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Changed { get; set; }

        public ICollection<Image>? Images { get; set; }

        public Guid CityId { get; set; }
        public City? City { get; set; }

        public Guid CurencyId { get; set; }
        public Currency? Currency { get; set; }

        public Guid CountryId { get; set; }
        public Country? Country { get; set; }

        public Guid EstateTypeId { get; set; }
        public EstateType? EstateType { get; set; }

        public Guid OwnerId { get; set; }
        public User? User { get; set; }
        //public Curency Curency { get; set; }

    }
}
