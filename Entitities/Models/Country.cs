using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Country
    {
        public Guid CountryId { get; set; }

        [Required(ErrorMessage = "City is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Country is 100 characters.  ")]
        public string? CountryName { get; set; }

        public ICollection<Estate>? Estates { get; set; }

    }
}
