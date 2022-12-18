using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace IvanRealEstate.IntegrationTests
{
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

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _factory.Dispose();
        }
    }
}
