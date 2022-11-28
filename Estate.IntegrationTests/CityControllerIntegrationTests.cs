namespace Estate.IntegrationTests
{
    public class CityControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _httpClient;

        public CityControllerIntegrationTests(TestingWebAppFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task GetCities_WhenCalled_ReturnsApplicationForm()
        {
            var response = await _httpClient.GetAsync("api/companies");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("Varna", responseString);
            Assert.Contains("Sofia", responseString);
        }
    }
}