namespace IvanRealEstate.IntegrationTests
{

    using System.Net;
    using System.Text;
    using Newtonsoft.Json;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using IvanRealEstate.Shared.DataTransferObject.Estate;

    [TestClass]
    public class EstateControllerIntegraionTests
    {
        private static TestContext _testContext;
        private static WebApplicationFactory<Program> _factory;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _testContext = testContext;
            _factory = new TestingWebAppFactory<Program>();
        }

        [TestMethod]
        public async Task GetAllEstates_WhenCalled_ReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/estates");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GetAllEstates_WhenCalled_ReturnExistingEstates()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/estates");

            var responseString = await response.Content.ReadAsStringAsync();
            var estates = JsonConvert.DeserializeObject<List<EstateDto>>(responseString);


            var estate = estates.FirstOrDefault(b => b.EstateId.ToString() == "99671edd-ebef-4b9b-865f-c7f52ed91657");
            Assert.IsTrue(2 == estates.Count);
            Assert.AreEqual("With Nice Bars", estate?.Description);
        }

        [TestMethod]
        public async Task GetEstateById_ReturnOkStatusCode()
        {
            var guid = Guid.Parse("99671edd-ebef-4b9b-865f-c7f52ed91657");
            var client = _factory.CreateClient();
            var response = await client.GetAsync($"api/estates/{guid}");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GetEstatById_ReturnExistingCity()
        {
            var guid = Guid.Parse("99671edd-ebef-4b9b-865f-c7f52ed91657");
            var client = _factory.CreateClient();
            var response = await client.GetAsync($"api/estates/{guid}");

            var responseString = await response.Content.ReadAsStringAsync();
            var estate = JsonConvert.DeserializeObject<EstateDto>(responseString);

            Assert.AreEqual(estate.Description, "With Nice Bars");
            Assert.AreEqual(estate.EstateId, guid);
        }

        [TestMethod]
        public async Task GetEstatById_ReturnNotFound()
        {
            var guid = Guid.Parse("99671edd-ebef-4b9b-865f-c7f52ed91656");
            var client = _factory.CreateClient();
            var response = await client.GetAsync($"api/estates/{guid}");

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public async Task PostEstate_ReturnCreatedResponse()
        {
            var estate = new EstateForCreationDto
            {
                Neighborhood = "Levski",
                Address = "Bul.Vasil Levski",
                Description = "With Nice Bars",
                YearOfCreation = 2010,
                Price = 259000,
                Floоr = 11,
                Rooms = 4,
                Extras = "asansior, parking, magazin",
                Sell = true,
                Created = DateTime.Parse("2022-11-29T12:16:19.5468059"),
                Changed = DateTime.Parse("2022-11-29T12:16:19.5468204"),
                CityId = Guid.Parse("ecab16f0-779a-4c87-994e-cb20b041cb91"),
                CurencyId = Guid.Parse("74115593-82b5-4db3-8bfe-b21f0ce285d9"),
                CountryId = Guid.Parse("21ca64db-95f4-4bca-afd3-6ba98bd87ab2"),
                EstateTypeId = Guid.Parse("f8653723-3b8b-4078-ac7e-83d2432a0177")
            };
            var client = _factory.CreateClient();

            var response = await client.PostAsync($"api/estates",
                new StringContent(JsonConvert.SerializeObject(estate), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public async Task PostEstate_ReturnCreatedCity()
        {
            var estate = new EstateForCreationDto
            {
                Neighborhood = "Levski",
                Address = "Bul.Vasil Levski",
                Description = "With Nice Bars",
                YearOfCreation = 2010,
                Price = 259000,
                Floоr = 11,
                Rooms = 4,
                Extras = "asansior, parking, magazin",
                Sell = true,
                Created = DateTime.Parse("2022-11-29T12:16:19.5468059"),
                Changed = DateTime.Parse("2022-11-29T12:16:19.5468204"),
                CityId = Guid.Parse("ecab16f0-779a-4c87-994e-cb20b041cb91"),
                CurencyId = Guid.Parse("74115593-82b5-4db3-8bfe-b21f0ce285d9"),
                CountryId = Guid.Parse("21ca64db-95f4-4bca-afd3-6ba98bd87ab2"),
                EstateTypeId = Guid.Parse("f8653723-3b8b-4078-ac7e-83d2432a0177")
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/estates",
                new StringContent(JsonConvert.SerializeObject(estate), Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();
            var estateResponse = JsonConvert.DeserializeObject<EstateDto>(result);

            Assert.AreEqual(estate.Neighborhood, estateResponse.Neighborhood);
            Assert.AreEqual(estate.Address, estateResponse.Address);
            Assert.AreEqual(estate.Description, estateResponse.Description);
            Assert.AreEqual(estate.YearOfCreation, estateResponse.YearOfCreation);
            Assert.AreEqual(estate.Price, estateResponse.Price);
            Assert.AreEqual(estate.Floоr, estateResponse.Floоr);
            Assert.AreEqual(estate.Rooms, estateResponse.Rooms);
            Assert.AreEqual(estate.Extras, estateResponse.Extras);
            Assert.AreEqual(estate.Sell, estateResponse.Sell);
            Assert.AreEqual(estate.CityId, estateResponse.CityId);
            Assert.AreEqual(estate.CurencyId, estateResponse.CurencyId);
            Assert.AreEqual(estate.CountryId, estateResponse.CountryId);
            Assert.AreEqual(estate.EstateTypeId, estateResponse.EstateTypeId);
        }

        [TestMethod]
        public async Task PostEstate_ReturnUnprocessableEntity()
        {
            var estate = new EstateForCreationDto
            {
                Neighborhood = null,
                Address = "Bul.Vasil Levski",
                Description = "With Nice Bars",
                YearOfCreation = 2010,
                Price = 259000,
                Floоr = 11,
                Rooms = 4,
                Extras = "asansior, parking, magazin",
                Sell = true,
                Created = DateTime.Parse("2022-11-29T12:16:19.5468059"),
                Changed = DateTime.Parse("2022-11-29T12:16:19.5468204"),
                CityId = Guid.Parse("ecab16f0-779a-4c87-994e-cb20b041cb91"),
                CurencyId = Guid.Parse("74115593-82b5-4db3-8bfe-b21f0ce285d9"),
                CountryId = Guid.Parse("21ca64db-95f4-4bca-afd3-6ba98bd87ab2"),
                EstateTypeId = Guid.Parse("f8653723-3b8b-4078-ac7e-83d2432a0177")
            };

            var client = _factory.CreateClient();

            var response = await client.PostAsync("api/estates",
                new StringContent(JsonConvert.SerializeObject(estate), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }

        [TestMethod]
        public async Task PostEstate_ReturnBadRequest()
        {
            var client = _factory.CreateClient();

            var response = await client.PostAsync("api/estates",
                new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public async Task PutCity_ReturnNoContent()
        {
            var estate = new EstateForUpdateDto
            {
                Neighborhood = "Levski",
                Address = "Bul.Vasil Levski",
                Description = "With Nice Bars",
                YearOfCreation = 2010,
                Price = 259000,
                Floоr = 11,
                Rooms = 4,
                Extras = "asansior, parking, magazin",
                Sell = true,
                Created = DateTime.Parse("2022-11-29T12:16:19.5468059"),
                Changed = DateTime.Parse("2022-11-29T12:16:19.5468204"),
                CityId = Guid.Parse("ecab16f0-779a-4c87-994e-cb20b041cb91"),
                CurencyId = Guid.Parse("74115593-82b5-4db3-8bfe-b21f0ce285d9"),
                CountryId = Guid.Parse("21ca64db-95f4-4bca-afd3-6ba98bd87ab2"),
                EstateTypeId = Guid.Parse("f8653723-3b8b-4078-ac7e-83d2432a0177")
            };

            var guid = Guid.Parse("99671edd-ebef-4b9b-865f-c7f52ed91657");

            var client = _factory.CreateClient();
            var response = await client.PutAsync($"api/estates/{guid}",
                new StringContent(JsonConvert.SerializeObject(estate), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [TestMethod]
        public async Task PutEstate_ReturnNotFound()
        {
            var estate = new EstateForUpdateDto
            {
                Neighborhood = "Levski",
                Address = "Bul.Vasil Levski",
                Description = "With Nice Bars",
                YearOfCreation = 2010,
                Price = 259000,
                Floоr = 11,
                Rooms = 4,
                Extras = "asansior, parking, magazin",
                Sell = true,
                Created = DateTime.Parse("2022-11-29T12:16:19.5468059"),
                Changed = DateTime.Parse("2022-11-29T12:16:19.5468204"),
                CityId = Guid.Parse("ecab16f0-779a-4c87-994e-cb20b041cb91"),
                CurencyId = Guid.Parse("74115593-82b5-4db3-8bfe-b21f0ce285d9"),
                CountryId = Guid.Parse("21ca64db-95f4-4bca-afd3-6ba98bd87ab2"),
                EstateTypeId = Guid.Parse("f8653723-3b8b-4078-ac7e-83d2432a0177")
            };
            var guid = Guid.Parse("ecab16f0-779a-4c87-994e-cb20b041cb91");

            var client = _factory.CreateClient();
            var response = await client.PutAsync($"api/estates/{guid}",
                new StringContent(JsonConvert.SerializeObject(estate), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public async Task PutEstate_ReturnBadRequest()
        {
            var guid = Guid.Parse("99671edd-ebef-4b9b-865f-c7f52ed91657");

            var client = _factory.CreateClient();
            var response = await client.PutAsync($"api/estates/{guid}",
                new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public async Task PutEstate_ReturnUnprocessableEntity()
        {
            var estate = new EstateForUpdateDto
            {
                Neighborhood = "Levski",
                Address = null,
                Description = "With Nice Bars",
                YearOfCreation = 2010,
                Price = 259000,
                Floоr = 11,
                Rooms = 4,
                Extras = "asansior, parking, magazin",
                Sell = true,
                Created = DateTime.Parse("2022-11-29T12:16:19.5468059"),
                Changed = DateTime.Parse("2022-11-29T12:16:19.5468204"),
                CityId = Guid.Parse("ecab16f0-779a-4c87-994e-cb20b041cb91"),
                CurencyId = Guid.Parse("74115593-82b5-4db3-8bfe-b21f0ce285d9"),
                CountryId = Guid.Parse("21ca64db-95f4-4bca-afd3-6ba98bd87ab2"),
                EstateTypeId = Guid.Parse("f8653723-3b8b-4078-ac7e-83d2432a0177")
            };

            var guid = Guid.Parse("ecab16f0-779a-4c87-994e-cb20b041cb92");

            var client = _factory.CreateClient();
            var response = await client.PutAsync($"api/estates/{guid}",
                new StringContent(JsonConvert.SerializeObject(estate), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }

        [TestMethod]
        public async Task DeleteEstate_ReturnNotFound()
        {
            var guid = Guid.Parse("ecab16f0-779a-4c87-994e-cb20b041cb92");

            var client = _factory.CreateClient();
            var response = await client.DeleteAsync($"api/estates/{guid}");

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public async Task DeleteEstate_ReturnNoContent()
        {
            var guid = Guid.Parse("99671edd-ebef-4b9b-865f-c7f52ed91657");

            var client = _factory.CreateClient();
            var response = await client.DeleteAsync($"api/estates/{guid}");

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _factory.Dispose();
        }
    }
}
