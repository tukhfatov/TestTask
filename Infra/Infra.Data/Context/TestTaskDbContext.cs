using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.Data.Context
{
    public class TestTaskDbContext : DbContext
    {
//        public DbSet<Customer> Customers { get; set; }


        public TestTaskDbContext(
            DbContextOptions<TestTaskDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new CustomerMap());
                        
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            //var config = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            // define the database to use
            //optionsBuilder.UseSqlite("Filename=MyDatabase.db");
            //optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
            
    }
}