namespace IvanRealEstate.IntegrationTests
{
    using System.Net;
    using System.Text;
    using Newtonsoft.Json;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using IvanRealEstate.Shared.DataTransferObject.Currency;

    [TestClass]
    public class CurrencyControllerIntegraionTests
    {
        private static TestContext? _testContext;
        private static WebApplicationFactory<Program>? _factory;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _testContext = testContext;
            _factory = new TestingWebAppFactory<Program>();
        }

        [TestMethod]
        public async Task GetAllCurrencies_WhenCalled_ReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/currencies");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GetAllCurrencies_WhenCalled_ReturnExistingCurrencies()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/currencies");

            var responseString = await response.Content.ReadAsStringAsync();
            var currencies = JsonConvert.DeserializeObject<List<CurrencyDto>>(responseString);


            var city = currencies.FirstOrDefault(b => b.CurrencyId.ToString() == "adcbb794-5c2a-4dda-9da6-e4ab6c8a895e");
            Assert.IsTrue(2 == currencies.Count);
            Assert.AreEqual("EUR", city?.CurrencyName);
        }

        [TestMethod]
        public async Task GetCurrencyById_ReturnOkStatusCode()
        {
            var guid = Guid.Parse("adcbb794-5c2a-4dda-9da6-e4ab6c8a895e");
            var client = _factory.CreateClient();
            var response = await client.GetAsync($"api/currencies/{guid}");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GetCurrencyById_ReturnExistingCurrency()
        {
            var guid = Guid.Parse("adcbb794-5c2a-4dda-9da6-e4ab6c8a895e");
            var client = _factory.CreateClient();
            var response = await client.GetAsync($"api/currencies/{guid}");

            var responseString = await response.Content.ReadAsStringAsync();
            var currency = JsonConvert.DeserializeObject<CurrencyDto>(responseString);

            Assert.AreEqual(currency.CurrencyName, "EUR");
            Assert.AreEqual(currency.CurrencyId, guid);
        }

        [TestMethod]
        public async Task GetCurrencyById_ReturnNotFound()
        {
            var guid = Guid.Parse("c6514909-fac2-48e6-8590-d14a9b1cd604");
            var client = _factory.CreateClient();
            var response = await client.GetAsync($"api/currencies/{guid}");

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public async Task PostCurrencyy_ReturnCreatedResponse()
        {
            var currencies = new CurrencyForCreationDto { CurrencyName = "RON" };
            var client = _factory.CreateClient();

            var response = await client.PostAsync("api/currencies",
                new StringContent(JsonConvert.SerializeObject(currencies), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public async Task PostCurrency_ReturnCreatedCurrency()
        {
            var currency = new CurrencyForCreationDto { CurrencyName = "RON" };
            var client = _factory.CreateClient();

            var response = await client.PostAsync("api/currencies",
                new StringContent(JsonConvert.SerializeObject(currency), Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();
            var currencyResponse = JsonConvert.DeserializeObject<CurrencyDto>(result);

            Assert.AreEqual(currency.CurrencyName, currencyResponse.CurrencyName);
        }

        [TestMethod]
        public async Task PostCurrency_ReturnUnprocessableEntity()
        {
            var currency = new CurrencyForCreationDto { CurrencyName = null };
            var client = _factory.CreateClient();

            var response = await client.PostAsync("api/currencies",
                new StringContent(JsonConvert.SerializeObject(currency), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }

        [TestMethod]
        public async Task PostCurrency_ReturnBadRequest()
        {
            var client = _factory.CreateClient();

            var response = await client.PostAsync("api/currencies",
                new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public async Task PutCurrency_ReturnNoContent()
        {
            var currency = new CurrencyForUpdateDto { CurrencyName = "England" };
            var guid = Guid.Parse("adcbb794-5c2a-4dda-9da6-e4ab6c8a895e");

            var client = _factory.CreateClient();
            var response = await client.PutAsync($"api/currencies/{guid}",
                new StringContent(JsonConvert.SerializeObject(currency), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [TestMethod]
        public async Task PutCurrency_ReturnNotFound()
        {
            var currency = new CurrencyForUpdateDto { CurrencyName = "RON" };
            var guid = Guid.Parse("77395d5c-51f3-4562-ba47-70651a064dca");

            var client = _factory.CreateClient();
            var response = await client.PutAsync($"api/currencies/{guid}",
                new StringContent(JsonConvert.SerializeObject(currency), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public async Task PutCurrency_ReturnBadRequest()
        {
            var guid = Guid.Parse("adcbb794-5c2a-4dda-9da6-e4ab6c8a895e");

            var client = _factory.CreateClient();
            var response = await client.PutAsync($"api/currencies/{guid}",
                new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public async Task PutCurrencyy_ReturnUnprocessableEntity()
        {
            var currency = new CurrencyForUpdateDto { CurrencyName = null };
            var guid = Guid.Parse("adcbb794-5c2a-4dda-9da6-e4ab6c8a895e");

            var client = _factory.CreateClient();
            var response = await client.PutAsync($"api/currencies/{guid}",
                new StringContent(JsonConvert.SerializeObject(currency), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }

        [TestMethod]
        public async Task DeleteCurrency_ReturnNotFound()
        {
            var guid = Guid.Parse("21ca64db-95f4-4bca-afd3-6ba98bd87ab1");

            var client = _factory.CreateClient();
            var response = await client.DeleteAsync($"api/currencies/{guid}");

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public async Task DeleteCurrencyy_ReturnNoContent()
        {
            var guid = Guid.Parse("adcbb794-5c2a-4dda-9da6-e4ab6c8a895e");

            var client = _factory.CreateClient();
            var response = await client.DeleteAsync($"api/currencies/{guid}");

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _factory.Dispose();
        }
    }
}