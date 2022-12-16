using IvanRealEstate.IntegrationTests.Helpers;
using IvanRealEstate.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IvanRealEstate.IntegrationTests
{
    public class TestingWebAppFactory<TEntryPoin> 
        : WebApplicationFactory<Program> where TEntryPoin : Program
    {
        private SqliteConnection _connection;

        public TestingWebAppFactory()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var serviceDescriptor = services
                .SingleOrDefault(d => d.ServiceType ==typeof(DbContextOptions<RepositoryContext>));
                services.Remove(serviceDescriptor);

                // Create a new service provider.
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkSqlite()
                    .BuildServiceProvider();

                services.AddDbContext<RepositoryContext>(options =>
                {
                    options.UseSqlite(_connection);
                    options.UseInternalServiceProvider(serviceProvider);
                }, ServiceLifetime.Scoped);

                // Build the service provider.
                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;

                    var db = scopedServices.GetRequiredService<RepositoryContext>();

                    db.Database.EnsureDeleted();

                    // Ensure the database is created.
                    db.Database.EnsureCreated();

                    // Seed the database with test data.
                    Utilities.InitializeDbForTests(db);
                }
            });
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _connection.Close();
            _connection.Dispose();
        }
    }
}
