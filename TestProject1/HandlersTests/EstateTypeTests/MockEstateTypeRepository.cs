namespace IvanRealEstate.Test.HandlersTests.EstateTypeTests
{
    using Moq;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;

    public class MockEstateTypeRepository
    {
        private static List<EstateType> estateTypes = new()
        {
            new EstateType
            {
                EstateTypeId = Guid.Parse("f9fec971-f109-4679-0c67-08dad1555662"),
                TypeName = "Apartment"
            },
            new EstateType
            {
                EstateTypeId = Guid.NewGuid(),
                TypeName = "House"
            },
            new EstateType
            {
                EstateTypeId = Guid.NewGuid(),
                TypeName = "Land"
            }
        };

        public static Mock<IRepositoryManager> EstateTypeRepository(Guid estateTypeId)
        {
            var mockRepo = new Mock<IRepositoryManager>();

            var estate = estateTypes.Where(e => e.EstateTypeId == estateTypeId).SingleOrDefault();

            mockRepo.Setup(r => r.EstateType.GetEstateTypeAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(estate);
            mockRepo.Setup(r => r.EstateType.CreateEstateType(It.IsAny<EstateType>()));
            mockRepo.Setup(r => r.EstateType.DeleteEstateType(It.IsAny<EstateType>())).Verifiable();
            mockRepo.Setup(r => r.SaveAsync()).Verifiable();

            return mockRepo;
        }

        public static Mock<IRepositoryManager> EstateTypeRepository()
        {
            var mockRepo = new Mock<IRepositoryManager>();

            mockRepo.Setup(r => r.EstateType.GetEstateTypesAsync(It.IsAny<bool>()))
                .ReturnsAsync(estateTypes);

            return mockRepo;
        }
    }
}
