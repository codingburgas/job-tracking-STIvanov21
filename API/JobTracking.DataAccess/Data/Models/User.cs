using System.ComponentModel.DataAnnotations;
using JobTracking.DataAccess.Data.Base;

namespace JobTracking.DataAccess.Data.Models;

public class User : IEntity
{
    [Required] public int Id { get; set; }
    [Required] public bool IsActive { get; set; }
    [Required] public DateTime CreatedOn { get; set; }
    [Required] public string CreatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    
    [Required, MaxLength(50)] public string FullName { get; set; }
    [Required, MaxLength(50)] public string Email { get; set; }
    [Required] public string PasswordHash { get; set; }
    [Required] public UserRole Role { get; set; }
    [Required] public int Age { get; set; }
}