using JobTracking.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public async Task<ActionResult<IEnumerable<JobOffer>>> GetOffers()
        => await _context.JobOffers.OrderByDescending(o => o.CreatedOn).ToListAsync();

    [HttpPost]
    public async Task<IActionResult> CreateOffer([FromBody] JobOffer offer)
    {
        offer.CreatedOn = DateTime.UtcNow;
        _context.JobOffers.Add(offer);
        await _context.SaveChangesAsync();
        return Ok(offer);
    }

    // Add apply logic in a separate controller or method
}