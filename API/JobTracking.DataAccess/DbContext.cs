using JobTracking.DataAccess.Data.Models;

namespace JobTracking.DataAccess;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<JobOffer> JobOffers { get; set; } = null!;

    public DbSet<Application> Applications { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}
