namespace IvanRealEstate.Repository.Configuration
{
    using IvanRealEstate.Entities.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                new Country
                {
                    CountryId = Guid.Parse("21ca64db-95f4-4bca-afd3-6ba98bd87ab2"),
                    CountryName = "Bulgaria"
                },
                new Country
                {
                    CountryId = Guid.Parse("2b675228-3147-4b75-b4b8-0f2104728b35"),
                    CountryName = "Romania"
                });
        }
    }
}
