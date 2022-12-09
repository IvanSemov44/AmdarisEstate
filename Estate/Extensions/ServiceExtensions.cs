namespace IvanRealEstate.Extensions
{
    using Microsoft.EntityFrameworkCore;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.LoggerService;
    using IvanRealEstate.Repository;

    public static class ServiceExtensions
    {
        public static void ConfigureCORS(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", bulder =>
                bulder.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .WithExposedHeaders("X-Pagination")
                .AllowAnyMethod()
                .SetIsOriginAllowedToAllowWildcardSubdomains());
            });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {

            });

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

    }
}
