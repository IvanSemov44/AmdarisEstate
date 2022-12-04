namespace IvanRealEstate.Test.HandlersTests.EstateTests
{
    using Moq;
    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;

    public static class MockEstateRepository
    {
        public static Mock<IRepositoryManager> EstateRepositoryForTest(Guid estateId)
        {
            var estates = new List<Estate>
            {
                new Estate
                {
                    EstateId= Guid.Parse("387f6683-f763-4e0d-b35c-08dad2038670"),
                    Neighborhood= "Vladislavovo",
                    Address= "Bl.407",
                    Description ="Golqm e",
                    YearOfCreation= 1970,
                    Price= 199000,
                    Floоr= 7,
                    Rooms= 5,
                    Extras= "asansior i parking magazin",
                    Sell= true,
                    Created = DateTime.Parse("2022-11-29T12:16:19.5468059"),
                    Changed=DateTime.Parse("2022-11-29T12:16:19.5468204"),
                    CityId=Guid.Parse("25db1981-7501-45bd-e3bd-08dacfa02b27"),
                    CurencyId= Guid.Parse("4bb67d01-13cb-47d5-d499-08dad1453af0"),
                    CountryId=Guid.Parse("f8c5ce88-54ee-4feb-9605-08dad0620656"),
                    EstateTypeId= Guid.Parse("f9fec971-f109-4679-0c67-08dad1555662"),

                },
                new Estate
                {
                    EstateId= Guid.NewGuid(),
                    Neighborhood= "Vladislavovo",
                    Address= "Bl.407",
                    Description ="Golqm e",
                    YearOfCreation= 1970,
                    Price= 199000,
                    Floоr= 7,
                    Rooms= 5,
                    Extras= "asansior i parking magazin",
                    Sell= true,
                    Created = DateTime.Parse("2022-11-29T12:16:19.5468059"),
                    Changed=DateTime.Parse("2022-11-29T12:16:19.5468204"),
                    CityId=Guid.Parse("25db1981-7501-45bd-e3bd-08dacfa02b27"),
                    CurencyId= Guid.Parse("4bb67d01-13cb-47d5-d499-08dad1453af0"),
                    CountryId=Guid.Parse("f8c5ce88-54ee-4feb-9605-08dad0620656"),
                    EstateTypeId= Guid.Parse("f9fec971-f109-4679-0c67-08dad1555662"),

                },
                new Estate
                {
                    EstateId=  Guid.NewGuid(),
                    Neighborhood= "Vladislavovo",
                    Address= "Bl.407",
                    Description ="Golqm e",
                    YearOfCreation= 1970,
                    Price= 199000,
                    Floоr= 7,
                    Rooms= 5,
                    Extras= "asansior i parking magazin",
                    Sell= true,
                    Created = DateTime.Parse("2022-11-29T12:16:19.5468059"),
                    Changed=DateTime.Parse("2022-11-29T12:16:19.5468204"),
                    CityId=Guid.Parse("25db1981-7501-45bd-e3bd-08dacfa02b27"),
                    CurencyId= Guid.Parse("4bb67d01-13cb-47d5-d499-08dad1453af0"),
                    CountryId=Guid.Parse("f8c5ce88-54ee-4feb-9605-08dad0620656"),
                    EstateTypeId= Guid.Parse("f9fec971-f109-4679-0c67-08dad1555662"),

                },
            };

            var mockRepo = new Mock<IRepositoryManager>();

            var estate = estates.Where(c => c.EstateId == estateId).SingleOrDefault();

            mockRepo.Setup(r => r.Estate.GetAllEstatesAsync(false)).ReturnsAsync(estates);

            mockRepo.Setup(r => r.Estate.GetEstateAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(estate);

            mockRepo.Setup(r => r.Estate.CreateEstate(It.IsAny<Estate>()));

            mockRepo.Setup(r => r.Estate.DeleteEstate(It.IsAny<Estate>())).Verifiable();
            mockRepo.Setup(r => r.SaveAsync()).Verifiable();

            return mockRepo;
        }

        public static Mock<IRepositoryManager> EstateRepositoryForTest()
        {
            var estates = new List<Estate>
            {
                new Estate
                {
                    EstateId= Guid.Parse("387f6683-f763-4e0d-b35c-08dad2038670"),
                    Neighborhood= "Vladislavovo",
                    Address= "Bl.407",
                    Description ="Golqm e",
                    YearOfCreation= 1970,
                    Price= 199000,
                    Floоr= 7,
                    Rooms= 5,
                    Extras= "asansior i parking magazin",
                    Sell= true,
                    Created = DateTime.Parse("2022-11-29T12:16:19.5468059"),
                    Changed=DateTime.Parse("2022-11-29T12:16:19.5468204"),
                    CityId=Guid.Parse("25db1981-7501-45bd-e3bd-08dacfa02b27"),
                    CurencyId= Guid.Parse("4bb67d01-13cb-47d5-d499-08dad1453af0"),
                    CountryId=Guid.Parse("f8c5ce88-54ee-4feb-9605-08dad0620656"),
                    EstateTypeId= Guid.Parse("f9fec971-f109-4679-0c67-08dad1555662"),

                },
                new Estate
                {
                    EstateId= Guid.NewGuid(),
                    Neighborhood= "Vladislavovo",
                    Address= "Bl.407",
                    Description ="Golqm e",
                    YearOfCreation= 1970,
                    Price= 199000,
                    Floоr= 7,
                    Rooms= 5,
                    Extras= "asansior i parking magazin",
                    Sell= true,
                    Created = DateTime.Parse("2022-11-29T12:16:19.5468059"),
                    Changed=DateTime.Parse("2022-11-29T12:16:19.5468204"),
                    CityId=Guid.Parse("25db1981-7501-45bd-e3bd-08dacfa02b27"),
                    CurencyId= Guid.Parse("4bb67d01-13cb-47d5-d499-08dad1453af0"),
                    CountryId=Guid.Parse("f8c5ce88-54ee-4feb-9605-08dad0620656"),
                    EstateTypeId= Guid.Parse("f9fec971-f109-4679-0c67-08dad1555662"),

                },
                new Estate
                {
                    EstateId=  Guid.NewGuid(),
                    Neighborhood= "Vladislavovo",
                    Address= "Bl.407",
                    Description ="Golqm e",
                    YearOfCreation= 1970,
                    Price= 199000,
                    Floоr= 7,
                    Rooms= 5,
                    Extras= "asansior i parking magazin",
                    Sell= true,
                    Created = DateTime.Parse("2022-11-29T12:16:19.5468059"),
                    Changed=DateTime.Parse("2022-11-29T12:16:19.5468204"),
                    CityId=Guid.Parse("25db1981-7501-45bd-e3bd-08dacfa02b27"),
                    CurencyId= Guid.Parse("4bb67d01-13cb-47d5-d499-08dad1453af0"),
                    CountryId=Guid.Parse("f8c5ce88-54ee-4feb-9605-08dad0620656"),
                    EstateTypeId= Guid.Parse("f9fec971-f109-4679-0c67-08dad1555662"),

                },
            };

            var mockRepo = new Mock<IRepositoryManager>();

            mockRepo.Setup(r => r.Estate.GetAllEstatesAsync(false)).ReturnsAsync(estates);

            mockRepo.Setup(r => r.Estate.CreateEstate(It.IsAny<Estate>()));

            mockRepo.Setup(r => r.Estate.DeleteEstate(It.IsAny<Estate>()));

            return mockRepo;
        }
    }
}
