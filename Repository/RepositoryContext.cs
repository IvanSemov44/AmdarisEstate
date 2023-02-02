namespace IvanRealEstate.Repository
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Repository.Configuration;

    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            //modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            //modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            //modelBuilder.ApplyConfiguration(new CityConfiguration());
            //modelBuilder.ApplyConfiguration(new CountryConfiguration());
            //modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
            //modelBuilder.ApplyConfiguration(new EstateTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new ImageConfiguration());
            //modelBuilder.ApplyConfiguration(new EstateConfiguration());
        }


        public DbSet<Estate>? Estates { get; set; }
        public DbSet<Image>? Images { get; set; }
        public DbSet<City>? Cities { get; set; }
        public DbSet<Currency>? Currencies { get; set; }
        public DbSet<Country>? Countries { get; set; }
        public DbSet<EstateType>? EstateTypes { get; set; }
        public DbSet<Message>? Messages { get; set; }
        public DbSet<Company>? Companies { get; set; }
    }
}
