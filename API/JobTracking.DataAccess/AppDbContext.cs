using JobTracking.DataAccess.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JobTracking.DataAccess;

public class AppDbContext : DbContext
{
    public DbSet<Dim4ou> Dim4ou { get; set; }
    public DbSet<KriskoBeats> KriskoBeats { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=JobTrackingDB;Trusted_Connection=True;");
        }
    }
}