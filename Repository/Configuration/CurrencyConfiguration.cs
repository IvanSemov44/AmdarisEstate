namespace IvanRealEstate.Repository.Configuration
{
    using IvanRealEstate.Entities.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasData(
                new Currency
                {
                    CurrencyId = Guid.Parse("74115593-82b5-4db3-8bfe-b21f0ce285d9"),
                    CurrencyName = "BGN"
                },
                new Currency
                {
                    CurrencyId = Guid.Parse("adcbb794-5c2a-4dda-9da6-e4ab6c8a895e"),
                    CurrencyName = "EUR"
                });
        }
    }
}
