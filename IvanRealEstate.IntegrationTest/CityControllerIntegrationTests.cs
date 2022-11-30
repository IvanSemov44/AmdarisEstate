namespace IvanRealEstate.IntegrationTest
{
    public class CityControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _client;

        public CityControllerIntegrationTests(TestingWebAppFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task City_WhenCalled_ReturnsApplicationForm()
        {

            //var response = await _client.GetAsync("/api/cities");

            //response.EnsureSuccessStatusCode();

            //var responseString = await response.Content.ReadAsStringAsync();

            //Assert.Contains("Varna", responseString);
            //Assert.Contains("Evelin", responseString);


            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/cities");

            var formModel = new Dictionary<string, string>
                                {
                                     { "cityName", "Varna" },
                                 };

            postRequest.Content = new FormUrlEncodedContent(formModel);

            var response = await _client.SendAsync(postRequest);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("Varna", responseString);
        }
    }
}