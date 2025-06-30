using JobTracking.DataAccess.Data.Models;

public class JobOffer
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string CreatedBy { get; set; } = null!;
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    
    public ICollection<Application> JobApplications { get; set; } = new List<Application>();
}