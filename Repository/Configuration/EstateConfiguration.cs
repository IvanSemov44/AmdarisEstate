namespace IvanRealEstate.Repository.Configuration
{
    using IvanRealEstate.Entities.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EstateConfiguration : IEntityTypeConfiguration<Estate>
    {
        public void Configure(EntityTypeBuilder<Estate> builder)
        {
            builder.HasData(
                new Estate
                {
                    EstateId = Guid.Parse("99671edd-ebef-4b9b-865f-c7f52ed91657"),
                    Neighborhood = "Levski",
                    Address = "Bul.Vasil Levski",
                    Description = "With Nice Bars",
                    YearOfCreation = 2010,
                    Price = 259000,
                    Floor = 11,
                    Rooms = 4,
                    Extras = "asansior, parking, magazin",
                    Sell = true,
                    Created = DateTime.Parse("2022-11-29T12:16:19.5468059"),
                    Changed = DateTime.Parse("2022-11-29T12:16:19.5468204"),
                    CityId = Guid.Parse("ecab16f0-779a-4c87-994e-cb20b041cb91"),
                    CurencyId = Guid.Parse("74115593-82b5-4db3-8bfe-b21f0ce285d9"),
                    CountryId = Guid.Parse("21ca64db-95f4-4bca-afd3-6ba98bd87ab2"),
                    EstateTypeId = Guid.Parse("f8653723-3b8b-4078-ac7e-83d2432a0177")
                },
                new Estate
                {
                    EstateId = Guid.Parse("c6514909-fac2-48e6-8590-d14a9b1cd60c"),
                    Neighborhood = "Levski",
                    Address = "Bul.Vasil Levski",
                    Description = "With Nice Bars",
                    YearOfCreation = 2010,
                    Price = 259000,
                    Floor = 11,
                    Rooms = 4,
                    Extras = "asansior, parking, magazin",
                    Sell = true,
                    Created = DateTime.Parse("2022-11-29T12:16:19.5468059"),
                    Changed = DateTime.Parse("2022-11-29T12:16:19.5468204"),
                    CityId = Guid.Parse("ecab16f0-779a-4c87-994e-cb20b041cb91"),
                    CurencyId = Guid.Parse("74115593-82b5-4db3-8bfe-b21f0ce285d9"),
                    CountryId = Guid.Parse("21ca64db-95f4-4bca-afd3-6ba98bd87ab2"),
                    EstateTypeId = Guid.Parse("f8653723-3b8b-4078-ac7e-83d2432a0177"),
                });
        }
    }
}
