namespace IvanRealEstate.Repository.Configuration
{
    using IvanRealEstate.Entities.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EstateTypeConfiguration : IEntityTypeConfiguration<EstateType>
    {
        public void Configure(EntityTypeBuilder<EstateType> builder)
        {
            builder.HasData(
                new EstateType
                {
                    EstateTypeId = Guid.Parse("f8653723-3b8b-4078-ac7e-83d2432a0177"),
                    TypeName = "Apartment"
                },
                new EstateType
                {
                    EstateTypeId = Guid.Parse("e78dc580-557f-42be-a0bf-8268e2d1680d"),
                    TypeName = "House"
                });
        }
    }
}
