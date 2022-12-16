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
                    CityId =  Guid.Parse("ecab16f0-779a-4c87-994e-cb20b041cb91"),
                    CityName = "Sofia"
                },
                new City
                {
                    CityId = Guid.Parse("c6514909-fac2-48e6-8590-d14a9b1cd60c"),
                    CityName = "Varna"
                });
        }
    }
}
