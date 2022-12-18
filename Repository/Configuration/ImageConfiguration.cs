namespace IvanRealEstate.Repository.Configuration
{
    using IvanRealEstate.Entities.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(
                new Image
                {
                    ImageId = Guid.Parse("03288698-8aa7-400a-bdec-90e824ae70d9"),
                    ImageUrl = "http://www.host1.com",
                    EstateId = new Guid("99671edd-ebef-4b9b-865f-c7f52ed91657")
                },
                new Image
                {
                    ImageId = Guid.Parse("b9da16a6-3801-463f-8d3c-5cca0c44a769"),
                    ImageUrl = "http://www.host.com",
                    EstateId = new Guid("99671edd-ebef-4b9b-865f-c7f52ed91657")
                }); 
        }
    }
}
