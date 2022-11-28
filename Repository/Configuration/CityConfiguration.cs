namespace IvanRealEstate.Repository.Configuration
{
    using IvanRealEstate.Entities.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(
                new City
                {
                    CityId = new Guid(),
                    CityName = "Sofia"
                },
                new City
                {
                    CityId = new Guid(),
                    CityName = "Varna"
                });
        }
    }
}
