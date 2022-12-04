namespace IvanRealEstate.Test.HandlersTests.ImageTest
{
    using Moq;
    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;

    public static class MockImageRepository
    {
        public static Mock<IRepositoryManager> ImageRepositoryForTest(Guid estateId, Guid imageId)
        {
            var images = new List<Image>
            {
                new Image
                {
                    ImageId = Guid.Parse("a7811775-1316-4e2c-4241-08dad234d5b6"),
                    EstateId = Guid.Parse("387f6683-f763-4e0d-b35c-08dad2038670"),
                    ImageUrl = "https://pixabay.com/images/search/real%20estate/",
                },
                new Image
                {
                    ImageId = Guid.Parse("ca807a5f-ec3b-47c1-d11a-08dad236fedb"),
                    EstateId = Guid.Parse("387f6683-f763-4e0d-b35c-08dad2038670"),
                    ImageUrl = "https://pixabay.com/images/search/real%20estate/",
                },
                new Image
                {
                    ImageId = Guid.NewGuid(),
                    EstateId = Guid.Parse("387f6683-f763-4e0d-b35c-08dad2038670"),
                    ImageUrl = "https://pixabay.com/",
                },
            };

            var mockRepo = new Mock<IRepositoryManager>();

            var estate = images.Where(c => c.EstateId == estateId && c.ImageId == imageId).SingleOrDefault();

            mockRepo
                .Setup(r => r.Image.GetImagesAsync(It.IsAny<Guid>(), false))
                .ReturnsAsync(images);

            mockRepo
                .Setup(r => r.Image.GetImageAsync(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(estate);

            mockRepo.Setup(r => r.Image.CreateImage(It.IsAny<Guid>(), It.IsAny<Image>()));

            mockRepo.Setup(r => r.Image.DeleteImage(It.IsAny<Image>())).Verifiable();

            mockRepo.Setup(r => r.SaveAsync()).Verifiable();

            return mockRepo;
        }

        public static Mock<IRepositoryManager> ImageRepositoryForTest()
        {
            var images = new List<Image>
            {
                new Image
                {
                    ImageId = Guid.Parse("a7811775-1316-4e2c-4241-08dad234d5b6"),
                    EstateId = Guid.Parse("387f6683-f763-4e0d-b35c-08dad2038670"),
                    ImageUrl = "https://pixabay.com/images/search/real%20estate/",
                },
                new Image
                {
                    ImageId = Guid.Parse("ca807a5f-ec3b-47c1-d11a-08dad236fedb"),
                    EstateId = Guid.Parse("387f6683-f763-4e0d-b35c-08dad2038670"),
                    ImageUrl = "https://pixabay.com/images/search/real%20estate/",
                },
                new Image
                {
                    ImageId = Guid.NewGuid(),
                    EstateId = Guid.Parse("387f6683-f763-4e0d-b35c-08dad2038670"),
                    ImageUrl = "https://pixabay.com/",
                },
            };

            var mockRepo = new Mock<IRepositoryManager>();

            mockRepo
                .Setup(r => r.Image.GetImagesAsync(It.IsAny<Guid>(), false))
                .ReturnsAsync(images);

            mockRepo
                .Setup(r => r.Estate.GetEstateAsync(It.IsAny<Guid>(), false))
                .ReturnsAsync(new Estate());

            return mockRepo;
        }
    }
}
