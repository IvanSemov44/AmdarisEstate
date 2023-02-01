using System.ComponentModel.DataAnnotations.Schema;

namespace IvanRealEstate.Entities.Models
{
    public class Image
    {
        public Guid ImageId { get; set; }

        public string? ImageUrl { get; set; }

        public bool? DefaultImg { get; set; }

        public Guid? EstateId { get; set; }
        public Estate? Estate { get; set; }

        [ForeignKey("CompanyId")]
        public Guid? CompanyId { get; set; }
        public Company? Company { get; set; }

        //public Guid OwnerId { get; set; }
        //public User? User { get; set; }
    }
}
