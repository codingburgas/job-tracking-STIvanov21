using System.ComponentModel.DataAnnotations;
using JobTracking.DataAccess.Data.Base;

namespace JobTracking.DataAccess.Data.Models;

public class Application
{
    [Key]
    public int Id { get; set; }

    // Foreign key to User
    [Required]
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    // Foreign key to JobOffer
    [Required]
    public int JobOfferId { get; set; }
    public JobOffer JobOffer { get; set; } = null!;

    // Additional fields for tracking application details
    [Required]
    public DateTime AppliedOn { get; set; } = DateTime.UtcNow;

    [MaxLength(50)]
    public string Status { get; set; } = "Pending"; // e.g. Pending, Accepted, Rejected

    // Optional: cover letter or other application info can be added here
    public string? CoverLetter { get; set; }
}