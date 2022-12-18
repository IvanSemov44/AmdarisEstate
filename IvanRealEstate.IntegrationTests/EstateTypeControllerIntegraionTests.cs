namespace IvanRealEstate.IntegrationTests
{
    using System.Net;
    using System.Text;
    using Newtonsoft.Json;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using IvanRealEstate.Shared.DataTransferObject.City;
    using IvanRealEstate.Shared.DataTransferObject.EstateType;

    [TestClass]
    public class EstateTypeControllerIntegraionTests
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
        public async Task GetAllEstateTypes_WhenCalled_ReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/estatetypes");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GetAllEstateTypes_WhenCalled_ReturnExistingEstateTypes()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/estatetypes");

            var responseString = await response.Content.ReadAsStringAsync();
            var estateTypes = JsonConvert.DeserializeObject<List<EstateTypeDto>>(responseString);

            var estateType = estateTypes.FirstOrDefault(b => b.EstateTypeId.ToString() == "f8653723-3b8b-4078-ac7e-83d2432a0177");
            Assert.IsTrue(2 == estateTypes.Count);
            Assert.AreEqual("Apartment", estateType?.TypeName);
        }

        [TestMethod]        
        public async Task GetEstateTypeById_ReturnOkStatusCode()
        {
            var guid = Guid.Parse("f8653723-3b8b-4078-ac7e-83d2432a0177");
            var client = _factory.CreateClient();
            var response = await client.GetAsync($"api/estatetypes/{guid}");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GetEstateTypeById_ReturnExistingEstateType()
        {
            var guid = Guid.Parse("f8653723-3b8b-4078-ac7e-83d2432a0177");
            var client = _factory.CreateClient();
            var response = await client.GetAsync($"api/estatetypes/{guid}");

            var responseString = await response.Content.ReadAsStringAsync();
            var estateType = JsonConvert.DeserializeObject<EstateTypeDto>(responseString);

            Assert.AreEqual(estateType.TypeName, "Apartment");
            Assert.AreEqual(estateType.EstateTypeId, guid);
        }

        [TestMethod]
        public async Task GetEstateTypeById_ReturnNotFound()
        {
            var guid = Guid.Parse("f8653723-3b8b-4078-ac7e-83d2432a0173");
            var client = _factory.CreateClient();
            var response = await client.GetAsync($"api/estatetypes/{guid}");

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public async Task PostEstateType_ReturnCreatedResponse()
        {
            var estateType = new EstateTypeForCreationDto { TypeName = "Land" };
            var client = _factory.CreateClient();

            var response = await client.PostAsync("api/estatetypes",
                new StringContent(JsonConvert.SerializeObject(estateType), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public async Task PostEstateType_ReturnCreatedEstateType()
        {
            var estateType = new EstateTypeForCreationDto { TypeName = "Land" };
            var client = _factory.CreateClient();

            var response = await client.PostAsync("api/estatetypes",
                new StringContent(JsonConvert.SerializeObject(estateType), Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();
            var estateTypeResponse = JsonConvert.DeserializeObject<EstateTypeDto>(result);

            Assert.AreEqual(estateType.TypeName, estateTypeResponse.TypeName);
        }

        [TestMethod]
        public async Task PostEstateType_ReturnUnprocessableEntity()
        {
            var estateType = new EstateTypeForCreationDto { TypeName = null };
            var client = _factory.CreateClient();

            var response = await client.PostAsync("api/estatetypes",
                new StringContent(JsonConvert.SerializeObject(estateType), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }

        [TestMethod]
        public async Task PostEstateType_ReturnBadRequest()
        {
            var client = _factory.CreateClient();

            var response = await client.PostAsync("api/estatetypes",
                new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public async Task PutEstateType_ReturnNoContent()
        {
            var estateType = new EstateTypeForUpdateDto { TypeName = "Land" };
            var guid = Guid.Parse("f8653723-3b8b-4078-ac7e-83d2432a0177");

            var client = _factory.CreateClient();
            var response = await client.PutAsync($"api/estatetypes/{guid}",
                new StringContent(JsonConvert.SerializeObject(estateType), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [TestMethod]
        public async Task PutEstateType_ReturnNotFound()
        {
            var estateType = new EstateTypeForUpdateDto { TypeName = "Land" };
            var guid = Guid.Parse("ecab16f0-779a-4c87-994e-cb20b041cb92");

            var client = _factory.CreateClient();
            var response = await client.PutAsync($"api/estatetypes/{guid}",
                new StringContent(JsonConvert.SerializeObject(estateType), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public async Task PutEstateType_ReturnBadRequest()
        {
            var guid = Guid.Parse("f8653723-3b8b-4078-ac7e-83d2432a0177");

            var client = _factory.CreateClient();
            var response = await client.PutAsync($"api/estatetypes/{guid}",
                new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public async Task PutEstateType_ReturnUnprocessableEntity()
        {
            var estateType = new CityForUpdateDto { CityName = null };
            var guid = Guid.Parse("f8653723-3b8b-4078-ac7e-83d2432a0177");

            var client = _factory.CreateClient();
            var response = await client.PutAsync($"api/estatetypes/{guid}",
                new StringContent(JsonConvert.SerializeObject(estateType), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }

        [TestMethod]
        public async Task DeleteEstateType_ReturnNotFound()
        {
            var guid = Guid.Parse("f8653723-3b8b-4078-ac7e-83d2432a0176");

            var client = _factory.CreateClient();
            var response = await client.DeleteAsync($"api/estatetypes/{guid}");

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public async Task DeleteEstateTypey_ReturnNoContent()
        {
            var guid = Guid.Parse("f8653723-3b8b-4078-ac7e-83d2432a0177");

            var client = _factory.CreateClient();
            var response = await client.DeleteAsync($"api/estatetypes/{guid}");

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _factory.Dispose();
        }
    }
}
