using JobTracking.DataAccess;
using JobTracking.DataAccess.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobTracking.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicationsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ApplicationsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Application>>> GetAllApplications()
    {
        return await _context.Applications.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Application>> GetApplication(int id)
    {
        var application = await _context.Applications.FindAsync(id);
        if (application == null) return NotFound();
        return application;
    }

    [HttpPost]
    public async Task<ActionResult<Application>> CreateApplication(Application application)
    {
        _context.Applications.Add(application);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetApplication), new { id = application.Id }, application);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateApplication(int id, Application updatedApplication)
    {
        if (id != updatedApplication.Id) return BadRequest();

        _context.Entry(updatedApplication).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Applications.Any(a => a.Id == id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteApplication(int id)
    {
        var application = await _context.Applications.FindAsync(id);
        if (application == null) return NotFound();

        _context.Applications.Remove(application);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
