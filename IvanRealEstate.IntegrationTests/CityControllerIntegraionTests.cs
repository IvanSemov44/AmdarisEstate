namespace IvanRealEstate.IntegrationTests
{
    using System.Net;
    using Newtonsoft.Json;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using IvanRealEstate.Shared.DataTransferObject.City;
    using System.Text;

    [TestClass]
    public class CityControllerIntegraionTests
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
        public async Task GetAllCities_WhenCalled_ReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/cities");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GetAllCities_WhenCalled_ReturnExistingCities()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/cities");

            var responseString = await response.Content.ReadAsStringAsync();
            var cities = JsonConvert.DeserializeObject<List<CityDto>>(responseString);


            var city = cities.FirstOrDefault(b => b.CityId.ToString() == "c6514909-fac2-48e6-8590-d14a9b1cd60c");
            Assert.IsTrue(2 == cities.Count);
            Assert.AreEqual("Varna", city?.CityName);
        }

        [TestMethod]
        public async Task GetCityById_ReturnOkStatusCode()
        {
            var guid = Guid.Parse("c6514909-fac2-48e6-8590-d14a9b1cd60c");
            var client = _factory.CreateClient();
            var response = await client.GetAsync($"api/cities/{guid}");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GetCityById_ReturnExistingCity()
        {
            var guid = Guid.Parse("c6514909-fac2-48e6-8590-d14a9b1cd60c");
            var client = _factory.CreateClient();
            var response = await client.GetAsync($"api/cities/{guid}");

            var responseString = await response.Content.ReadAsStringAsync();
            var city = JsonConvert.DeserializeObject<CityDto>(responseString);

            Assert.AreEqual(city.CityName, "Varna");
            Assert.AreEqual(city.CityId, guid);
        }

        [TestMethod]
        public async Task GetCityById_ReturnNotFound()
        {
            var guid = Guid.Parse("c6514909-fac2-48e6-8590-d14a9b1cd604");
            var client = _factory.CreateClient();
            var response = await client.GetAsync($"api/cities/{guid}");

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public async Task PostCity_ReturnCreatedResponse()
        {
            var city = new CityForCreationDto { CityName = "Plovdiv" };
            var client = _factory.CreateClient();

            var response = await client.PostAsync("api/cities",
                new StringContent(JsonConvert.SerializeObject(city), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public async Task PostCity_ReturnCreatedBook()
        {
            var city = new CityForCreationDto { CityName = "Plovdiv" };
            var client = _factory.CreateClient();

            var response = await client.PostAsync("api/cities",
                new StringContent(JsonConvert.SerializeObject(city), Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();
            var cityResponse = JsonConvert.DeserializeObject<CityDto>(result);

            Assert.AreEqual(city.CityName, cityResponse.CityName);
        }

        [TestMethod]
        public async Task PostCity_ReturnUnprocessableEntity()
        {
            var city = new CityForCreationDto { CityName = null };
            var client = _factory.CreateClient();

            var response = await client.PostAsync("api/cities",
                new StringContent(JsonConvert.SerializeObject(city), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }

        [TestMethod]
        public async Task PostCity_ReturnBadRequest()
        {
            var client = _factory.CreateClient();

            var response = await client.PostAsync("api/cities",
                new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public async Task PutCity_ReturnNoContent()
        {
            var city = new CityForUpdateDto { CityName = "Plovdiv" };
            var guid = Guid.Parse("ecab16f0-779a-4c87-994e-cb20b041cb91");

            var client = _factory.CreateClient();
            var response = await client.PutAsync($"api/cities/{guid}",
                new StringContent(JsonConvert.SerializeObject(city), Encoding.UTF8, "application/json"));
        
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [TestMethod]
        public async Task PutCity_ReturnNotFound()
        {
            var city = new CityForUpdateDto { CityName = "Plovdiv" };
            var guid = Guid.Parse("ecab16f0-779a-4c87-994e-cb20b041cb92");

            var client = _factory.CreateClient();
            var response = await client.PutAsync($"api/cities/{guid}",
                new StringContent(JsonConvert.SerializeObject(city), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public async Task PutCity_ReturnBadRequest() 
        { 
            var guid = Guid.Parse("ecab16f0-779a-4c87-994e-cb20b041cb92");

            var client = _factory.CreateClient();
            var response = await client.PutAsync($"api/cities/{guid}",
                new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public async Task PutCity_ReturnUnprocessableEntity()
        {
            var city = new CityForUpdateDto { CityName = null };
            var guid = Guid.Parse("ecab16f0-779a-4c87-994e-cb20b041cb92");

            var client = _factory.CreateClient();
            var response = await client.PutAsync($"api/cities/{guid}",
                new StringContent(JsonConvert.SerializeObject(city), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }

        [TestMethod]
        public async Task DeleteCity_ReturnNotFound()
        {
            var guid = Guid.Parse("ecab16f0-779a-4c87-994e-cb20b041cb92");

            var client = _factory.CreateClient();
            var response = await client.DeleteAsync($"api/cities/{guid}");

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public async Task DeleteCity_ReturnNoContent()
        {
            var guid = Guid.Parse("ecab16f0-779a-4c87-994e-cb20b041cb91");

            var client = _factory.CreateClient();
            var response = await client.DeleteAsync($"api/cities/{guid}");

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _factory.Dispose();
        }
    }
}