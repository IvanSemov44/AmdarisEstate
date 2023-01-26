
using System.ComponentModel.DataAnnotations.Schema;

namespace IvanRealEstate.Entities.Models
{
    public class CompanyImage
    {
        public Guid CompanyImageId { get; set; }

        public string? ImageUrl { get; set; }

        public bool? DefaultImg { get; set; }

        [ForeignKey("CompanyId")]
        public Guid CompanyId { get; set; }
        public User? Compnay { get; set; }
    }
}
