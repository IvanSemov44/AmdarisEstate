namespace IvanRealEstate.IntegrationTests
{
    using System.Net;
    using System.Text;
    using Newtonsoft.Json;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using IvanRealEstate.Shared.DataTransferObject.Country;

    [TestClass]
    public class CountryControllerIntegraionTests
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
        public async Task GetAllCoutnries_WhenCalled_ReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/countries");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GetAllCountries_WhenCalled_ReturnExistingCountries()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/countries");

            var responseString = await response.Content.ReadAsStringAsync();
            var countries = JsonConvert.DeserializeObject<List<CountryDto>>(responseString);


            var city = countries.FirstOrDefault(b => b.CountryId.ToString() == "21ca64db-95f4-4bca-afd3-6ba98bd87ab2");
            Assert.IsTrue(2 == countries.Count);
            Assert.AreEqual("Bulgaria", city?.CountryName);
        }

        [TestMethod]
        public async Task GetCountryById_ReturnOkStatusCode()
        {
            var guid = Guid.Parse("21ca64db-95f4-4bca-afd3-6ba98bd87ab2");
            var client = _factory.CreateClient();
            var response = await client.GetAsync($"api/countries/{guid}");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GetCountryById_ReturnExistingCountry()
        {
            var guid = Guid.Parse("21ca64db-95f4-4bca-afd3-6ba98bd87ab2");
            var client = _factory.CreateClient();
            var response = await client.GetAsync($"api/countries/{guid}");

            var responseString = await response.Content.ReadAsStringAsync();
            var countries = JsonConvert.DeserializeObject<CountryDto>(responseString);

            Assert.AreEqual(countries.CountryName, "Bulgaria");
            Assert.AreEqual(countries.CountryId, guid);
        }

        [TestMethod]
        public async Task GetCountryById_ReturnNotFound()
        {
            var guid = Guid.Parse("c6514909-fac2-48e6-8590-d14a9b1cd604");
            var client = _factory.CreateClient();
            var response = await client.GetAsync($"api/countries/{guid}");

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public async Task PostCountry_ReturnCreatedResponse()
        {
            var country = new CountryForCreationDto { CountryName = "England" };
            var client = _factory.CreateClient();

            var response = await client.PostAsync("api/countries",
                new StringContent(JsonConvert.SerializeObject(country), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public async Task PostCountry_ReturnCreatedBook()
        {
            var country = new CountryForCreationDto { CountryName = "England" };
            var client = _factory.CreateClient();

            var response = await client.PostAsync("api/countries",
                new StringContent(JsonConvert.SerializeObject(country), Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();
            var cityResponse = JsonConvert.DeserializeObject<CountryDto>(result);

            Assert.AreEqual(country.CountryName, cityResponse.CountryName);
        }

        [TestMethod]
        public async Task PostCountry_ReturnUnprocessableEntity()
        {
            var country = new CountryForCreationDto { CountryName = null };
            var client = _factory.CreateClient();

            var response = await client.PostAsync("api/countries",
                new StringContent(JsonConvert.SerializeObject(country), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }

        [TestMethod]
        public async Task PostCountry_ReturnBadRequest()
        {
            var client = _factory.CreateClient();

            var response = await client.PostAsync("api/countries",
                new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public async Task PutCountry_ReturnNoContent()
        {
            var country = new CountryForUpdateDto { CountryName = "England" };
            var guid = Guid.Parse("21ca64db-95f4-4bca-afd3-6ba98bd87ab2");

            var client = _factory.CreateClient();
            var response = await client.PutAsync($"api/countries/{guid}",
                new StringContent(JsonConvert.SerializeObject(country), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [TestMethod]
        public async Task PutCountry_ReturnNotFound()
        {
            var country = new CountryForUpdateDto { CountryName = "Plovdiv" };
            var guid = Guid.Parse("21ca64db-95f4-4bca-afd3-6ba98bd87ab1");

            var client = _factory.CreateClient();
            var response = await client.PutAsync($"api/countries/{guid}",
                new StringContent(JsonConvert.SerializeObject(country), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public async Task PutCountry_ReturnBadRequest()
        {
            var guid = Guid.Parse("21ca64db-95f4-4bca-afd3-6ba98bd87ab2");

            var client = _factory.CreateClient();
            var response = await client.PutAsync($"api/countries/{guid}",
                new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public async Task PutCountry_ReturnUnprocessableEntity()
        {
            var country = new CountryForUpdateDto { CountryName = null };
            var guid = Guid.Parse("21ca64db-95f4-4bca-afd3-6ba98bd87ab2");

            var client = _factory.CreateClient();
            var response = await client.PutAsync($"api/countries/{guid}",
                new StringContent(JsonConvert.SerializeObject(country), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }

        [TestMethod]
        public async Task DeleteCountry_ReturnNotFound()
        {
            var guid = Guid.Parse("21ca64db-95f4-4bca-afd3-6ba98bd87ab1");

            var client = _factory.CreateClient();
            var response = await client.DeleteAsync($"api/countries/{guid}");

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public async Task DeleteCountry_ReturnNoContent()
        {
            var guid = Guid.Parse("21ca64db-95f4-4bca-afd3-6ba98bd87ab2");

            var client = _factory.CreateClient();
            var response = await client.DeleteAsync($"api/countries/{guid}");

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _factory.Dispose();
        }
    }
}
