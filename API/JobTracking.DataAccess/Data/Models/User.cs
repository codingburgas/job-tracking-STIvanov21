using System.ComponentModel.DataAnnotations;
using JobTracking.DataAccess.Data.Base;

namespace JobTracking.DataAccess.Data.Models;

public class User : IEntity
{
    [Required] public int Id { get; set; }

    [Required] public bool IsActive { get; set; } = true;

    [Required] public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    [Required] public string CreatedBy { get; set; } = "system";

    public DateTime? UpdatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    
    [Required, MaxLength(50)] public string FirstName { get; set; } = null!;

    [Required, MaxLength(50), EmailAddress]
    public string Email { get; set; }

    [Required]
    public string PasswordHash { get; set; } = null!;

    [Required]
    public string Role { get; set; } = "USER";

    [Range(0, 150)]
    public int Age { get; set; }

    [Required, MaxLength(50)] public string? MiddleName { get; set; }
    [Required, MaxLength(50)] public string LastName { get; set; }
    [Required, MaxLength(50)] public string Username { get; set; }
}