using System.ComponentModel.DataAnnotations.Schema;

namespace IvanRealEstate.Entities.Models
{
    public class OwnerImage
    {
        public Guid OwnerImageId { get; set; }

        public string? ImageUrl { get; set; }

        public bool? DefaultImg { get; set; }

        [ForeignKey("OwnerId")]
        public Guid OwnerId { get; set; }
        public User? User { get; set; }
    }
}
