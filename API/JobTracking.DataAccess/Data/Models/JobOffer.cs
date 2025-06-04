using System.ComponentModel.DataAnnotations;
using JobTracking.DataAccess.Data.Base;

namespace JobTracking.DataAccess.Data.Models;

public class JobOffer : IEntity
{
    [Required] public int Id { get; set; }
    [Required] public bool IsActive { get; set; }
    [Required] public DateTime CreatedOn { get; set; }
    [Required] public string CreatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    
    [Required, MaxLength(50)] public string ApplicantFullName { get; set; }
    [Required, MaxLength(50)] public string ApplicantEmail { get; set; }
    [Required, MaxLength(50)] public string CompanyName { get; set; }
    [Required, MaxLength(50)] public string JobTitle { get; set; }
    public int? JobSalary { get; set; }
}