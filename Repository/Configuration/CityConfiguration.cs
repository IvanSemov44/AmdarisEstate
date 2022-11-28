using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
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
