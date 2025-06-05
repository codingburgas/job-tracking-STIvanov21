using JobTracking.DataAccess.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobTracking.DataAccess.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobOffersController : ControllerBase
{
    private readonly AppDbContext _context;

    public JobOffersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<JobOffer>>> GetAllJobOffers()
    {
        return await _context.JobOffers.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<JobOffer>> GetJobOffer(int id)
    {
        var jobOffer = await _context.JobOffers.FindAsync(id);
        if (jobOffer == null) return NotFound();
        return jobOffer;
    }

    [HttpPost]
    public async Task<ActionResult<JobOffer>> CreateJobOffer(JobOffer jobOffer)
    {
        _context.JobOffers.Add(jobOffer);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetJobOffer), new { id = jobOffer.Id }, jobOffer);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateJobOffer(int id, JobOffer updatedJobOffer)
    {
        if (id != updatedJobOffer.Id) return BadRequest();

        _context.Entry(updatedJobOffer).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.JobOffers.Any(j => j.Id == id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteJobOffer(int id)
    {
        var jobOffer = await _context.JobOffers.FindAsync(id);
        if (jobOffer == null) return NotFound();

        _context.JobOffers.Remove(jobOffer);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
