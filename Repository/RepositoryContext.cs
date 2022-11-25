using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }


        public DbSet<Estate> Estates { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Curency> Curencies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<EstateType> EstateTypes { get; set; }

        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Company>? Companies { get; set; }
    }
}
