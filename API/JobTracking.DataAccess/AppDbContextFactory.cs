using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace JobTracking.DataAccess
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
    
            // Manually load configuration from appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath("C:\\Users\\stili\\RiderProjects\\job-tracking-STIvanov21\\API\\JobTracking.API")
                .AddJsonFile("appsettings.json")
                .Build();


            var connectionString = config.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}