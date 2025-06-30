using Microsoft.AspNetCore.Mvc;

namespace JobTracking.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PingController : ControllerBase
{
    [HttpGet]
    [HttpGet]
    public IActionResult Get() => Ok(new { message = "API is working!" });

}