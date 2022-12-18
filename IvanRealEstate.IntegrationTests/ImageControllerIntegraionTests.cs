namespace IvanRealEstate.IntegrationTests
{
    using Newtonsoft.Json;
    using System.Net;
    using System.Text;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using IvanRealEstate.Shared.DataTransferObject.Image;


    [TestClass]
    public class ImageControllerIntegraionTests
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
        public async Task GetAllImageForEstate_WhenCalled_ReturnOkResponse()
        {
            var estateId = Guid.Parse("99671edd-ebef-4b9b-865f-c7f52ed91657");
            var client = _factory.CreateClient();
            var response = await client.GetAsync($"api/estates/{estateId}/images");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GetAllImageForEstate_WhenCalled_ReturnExistingCities()
        {
            var estateId = Guid.Parse("99671edd-ebef-4b9b-865f-c7f52ed91657");
            var client = _factory.CreateClient();
            var response = await client.GetAsync($"api/estates/{estateId}/images");

            var responseString = await response.Content.ReadAsStringAsync();
            var images = JsonConvert.DeserializeObject<List<ImageDto>>(responseString);

            var image = images.FirstOrDefault(b => b.ImageId.ToString() == "03288698-8aa7-400a-bdec-90e824ae70d9");
            Assert.IsTrue(2 == images.Count);
            Assert.AreEqual("http://www.host1.com", image?.ImageUrl);
        }

        [TestMethod]
        public async Task GetImageForEstateById_ReturnOkStatusCode()
        {
            var estateId = Guid.Parse("99671edd-ebef-4b9b-865f-c7f52ed91657");
            var guid = Guid.Parse("03288698-8aa7-400a-bdec-90e824ae70d9");

            var client = _factory.CreateClient();
            var response = await client.GetAsync($"api/estates/{estateId}/images/{guid}");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GetImageForEstateById_ReturnExistingImageForEstate()
        {
            var estateId = Guid.Parse("99671edd-ebef-4b9b-865f-c7f52ed91657");
            var guid = Guid.Parse("03288698-8aa7-400a-bdec-90e824ae70d9");

            var client = _factory.CreateClient();
            var response = await client.GetAsync($"api/estates/{estateId}/images/{guid}");

            var responseString = await response.Content.ReadAsStringAsync();
            var image = JsonConvert.DeserializeObject<ImageDto>(responseString);

            Assert.AreEqual(image.ImageUrl, "http://www.host1.com");
            Assert.AreEqual(image.ImageId, guid);
        }

        [TestMethod]
        public async Task GetImageForEstateById_ReturnNotFound()
        {
            var estateId = Guid.Parse("99671edd-ebef-4b9b-865f-c7f52ed91657");
            var guid = Guid.Parse("03288698-8aa7-400a-bdec-90e824ae70d8");

            var client = _factory.CreateClient();
            var response = await client.GetAsync($"api/estates/{estateId}/images/{guid}");

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public async Task PostImageForEstate_ReturnCreatedResponse()
        {
            var estateId = Guid.Parse("99671edd-ebef-4b9b-865f-c7f52ed91657");
            var image = new ImageForCreationDto { ImageUrl = "http://www.host1.com" };

            var client = _factory.CreateClient();
            var response = await client.PostAsync($"api/estates/{estateId}/images",
                new StringContent(JsonConvert.SerializeObject(image), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public async Task PostImageForEstate_ReturnCreatedCity()
        {
            var estateId = Guid.Parse("99671edd-ebef-4b9b-865f-c7f52ed91657");
            var image = new ImageForCreationDto { ImageUrl = "http://www.host1.com" };

            var client = _factory.CreateClient();
            var response = await client.PostAsync($"api/estates/{estateId}/images",
                new StringContent(JsonConvert.SerializeObject(image), Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();
            var imageResponse = JsonConvert.DeserializeObject<ImageDto>(result);

            Assert.AreEqual(image.ImageUrl, imageResponse.ImageUrl);
        }

        [TestMethod]
        public async Task PostImageForEstate_ReturnUnprocessableEntity()
        {
            var estateId = Guid.Parse("99671edd-ebef-4b9b-865f-c7f52ed91657");
            var image = new ImageForCreationDto { ImageUrl = null };

            var client = _factory.CreateClient();
            var response = await client.PostAsync($"api/estates/{estateId}/images",
                new StringContent(JsonConvert.SerializeObject(image), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }

        [TestMethod]
        public async Task PostImageForEstate_ReturnBadRequest()
        {
            var estateId = Guid.Parse("99671edd-ebef-4b9b-865f-c7f52ed91657");
            var client = _factory.CreateClient();

            var response = await client.PostAsync($"api/estates/{estateId}/images",
                new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public async Task PutImageForEstate_ReturnNoContent()
        {
            var estateId = Guid.Parse("99671edd-ebef-4b9b-865f-c7f52ed91657");
            var image = new ImageForUpdateDto { ImageUrl = "http://www.host.com" };
            var guid = Guid.Parse("03288698-8aa7-400a-bdec-90e824ae70d9");

            var client = _factory.CreateClient();
            var response = await client.PutAsync($"api/estates/{estateId}/images/{guid}",
                new StringContent(JsonConvert.SerializeObject(image), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [TestMethod]
        public async Task PutImageForEstate_ReturnNotFound()
        {
            var estateId = Guid.Parse("99671edd-ebef-4b9b-865f-c7f52ed91657");
            var image = new ImageForUpdateDto { ImageUrl = "http://www.host.com" };
            var guid = Guid.Parse("03288698-8aa7-400a-bdec-90e824ae70d8");

            var client = _factory.CreateClient();
            var response = await client.PutAsync($"api/estates/{estateId}/images/{guid}",
                new StringContent(JsonConvert.SerializeObject(image), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public async Task PutImageForEstate_ReturnBadRequest()
        {
            var estateId = Guid.Parse("99671edd-ebef-4b9b-865f-c7f52ed91657");
            var guid = Guid.Parse("03288698-8aa7-400a-bdec-90e824ae70d9");

            var client = _factory.CreateClient();
            var response = await client.PutAsync($"api/estates/{estateId}/images/{guid}",
                new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public async Task PutCity_ReturnUnprocessableEntity()
        {
            var estateId = Guid.Parse("99671edd-ebef-4b9b-865f-c7f52ed91657");
            var image = new ImageForUpdateDto { ImageUrl = null };
            var guid = Guid.Parse("03288698-8aa7-400a-bdec-90e824ae70d9");

            var client = _factory.CreateClient();
            var response = await client.PutAsync($"api/estates/{estateId}/images/{guid}",
                new StringContent(JsonConvert.SerializeObject(image), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }

        [TestMethod]
        public async Task DeleteCity_ReturnNotFound()
        {
            var estateId = Guid.Parse("99671edd-ebef-4b9b-865f-c7f52ed91657");
            var guid = Guid.Parse("03288698-8aa7-400a-bdec-90e824ae70d8");

            var client = _factory.CreateClient();
            var response = await client.DeleteAsync($"api/estates/{estateId}/images/{guid}");

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public async Task DeleteCity_ReturnNoContent()
        {
            var estateId = Guid.Parse("99671edd-ebef-4b9b-865f-c7f52ed91657");
            var guid = Guid.Parse("03288698-8aa7-400a-bdec-90e824ae70d9");

            var client = _factory.CreateClient();
            var response = await client.DeleteAsync($"api/estates/{estateId}/images/{guid}");

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _factory.Dispose();
        }
    }
}
