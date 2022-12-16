using IvanRealEstate.Shared.DataTransferObject.City;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Net;

namespace IvanRealEstate.IntegrationTests
{
    [TestClass]
    public class CityControllerIntegraionTests //: IClassFixture<TestingWebAppFactory<Program>>
    {
        private static TestContext _testContext;
        private static WebApplicationFactory<Program> _factory;

        //public CityControllerIntegraionTests(TestingWebAppFactory<Program> factory)
        //{
        //    _client = factory.CreateClient();
        //}

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _testContext = testContext;
            _factory = new TestingWebAppFactory<Program>();
        }


        [TestMethod]
        public async Task Index_WhenCalled_ShouldReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/cities");

            //response.EnsureSuccessStatusCode();

            //var responseString = await response.Content.ReadAsStringAsync();
            //var cities = JsonConvert.DeserializeObject<List<CityDto>>(responseString);


            //var city = cities.FirstOrDefault(b => b.CityId.ToString() == "c6514909-fac2-48e6-8590-d14a9b1cd60c");
            //Assert.Contains("Varna", city?.CityName);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task Index_WhenCalled_ReturnsApplicationForm()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/cities");

            var responseString = await response.Content.ReadAsStringAsync();
            var cities = JsonConvert.DeserializeObject<List<CityDto>>(responseString);


            var city = cities.FirstOrDefault(b => b.CityId.ToString() == "c6514909-fac2-48e6-8590-d14a9b1cd60c");
            Assert.IsTrue(2 == cities.Count);
            Assert.AreEqual("Varna", city?.CityName);
        }
    }
}