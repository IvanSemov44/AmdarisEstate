using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace Estate.IntegrationTests
{
    public class TestingWebAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(service =>
            {
                var descriptor = service.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<RepositoryContext>));

                if (descriptor != null)
                    service.Remove(descriptor);


                service.AddDbContext<RepositoryContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryCityTest");

                    var sp = service.BuildServiceProvider();
                    using (var scope = sp.CreateScope())
                    using (var appContext = scope.ServiceProvider.GetRequiredService<RepositoryContext>())
                    {
                        try
                        {
                            //appContext.Database.EnsureCreated();
                            if (appContext.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                                appContext.Database.Migrate();
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }
                });
            });
        }
    }
}
