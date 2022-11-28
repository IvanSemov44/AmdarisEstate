﻿namespace Entities.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        public Guid CountryId { get; set; }

        [Required(ErrorMessage = "City is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Country is 100 characters.  ")]
        public string? CountryName { get; set; }

        public ICollection<Estate>? Estates { get; set; }

    }
}
