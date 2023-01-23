namespace IvanRealEstate.Entities.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Company
    {
        [Column("CompanyId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Company name is a required field.")]
        [MaxLength(60,ErrorMessage ="Maximum length for the Name is 60 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Company address is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters.")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Description address is a required field.")]
        [MaxLength(200, ErrorMessage = "Maximum length for the Description is 200 characters.")]
        public string? Description { get; set; }

        public ICollection<User>? Employees { get; set; }
        public ICollection<Image>? Images { get; set; }

        public Guid CompanyCityId { get; set; }
        public City? City { get; set; }

        public Guid CompanyCountryId { get; set; }
        public Country? Country { get; set; }
    }
}
