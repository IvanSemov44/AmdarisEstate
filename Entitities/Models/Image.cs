﻿namespace IvanRealEstate.Entities.Models
{
    public class Image
    {
        public Guid ImageId { get; set; }

        public string? ImageUrl { get; set; }

        public bool? DefaultImg { get; set; }

        public Guid EstateId { get; set; }
        public Estate? Estate { get; set; }

        public Guid ImageCompanyId { get; set; }
        public Company? Company { get; set; }

        public Guid ownerId { get; set; }
        public User? User { get; set; }
    }
}
