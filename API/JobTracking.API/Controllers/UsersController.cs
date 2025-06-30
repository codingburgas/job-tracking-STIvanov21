using System.ComponentModel.DataAnnotations;
using JobTracking.DataAccess;
using JobTracking.DataAccess.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace JobTracking.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
        _context = context;
    }

    // 🔹 GET: api/users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    // 🔹 GET: api/users/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return NotFound();
        return user;
    }

    // 🔹 POST: api/users (generic create — can keep or remove)
    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    // 🔹 PUT: api/users/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, User updatedUser)
    {
        if (id != updatedUser.Id) return BadRequest();

        _context.Entry(updatedUser).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Users.Any(u => u.Id == id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // 🔹 DELETE: api/users/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return NotFound();

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = new User
        {
            FirstName    = request.FirstName,
            MiddleName   = request.MiddleName,
            LastName     = request.LastName,
            Username     = request.Username,
            Email        = request.Email,
            Age          = request.Age,
            Role         = request.Role,
            PasswordHash = HashPassword(request.Password),
            CreatedOn    = DateTime.UtcNow,
            CreatedBy    = "system",
            IsActive     = true
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Ok(new {
            user.Id,
            user.Username,
            user.Email,
            user.Age,
            user.Role
        });

    }



    // ✅ LOGIN: api/users/login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest login)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == login.Username);
        if (user == null || user.PasswordHash != HashPassword(login.Password))
        {
            return Unauthorized("Invalid username or password");
        }

        return Ok(new
        {
            user.Id,
            user.Username,
            user.Email,
            user.FirstName,
            user.LastName,
            user.Role,
            user.Age,
            user.CreatedOn // ✅ include this
        });


    }

    // 🔐 Helper for hashing passwords
    private string HashPassword(string input)
    {
        using var sha = SHA256.Create();
        var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
        return Convert.ToBase64String(bytes);
    }

    // 🔸 DTO for login
    public class LoginRequest
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
public class RegisterRequest
{
    [Required, MaxLength(50)]
    public string FirstName { get; set; } = null!;

    [MaxLength(50)]
    public string? MiddleName { get; set; }

    [Required, MaxLength(50)]
    public string LastName { get; set; } = null!;

    [Required, MaxLength(50)]
    public string Username { get; set; } = null!;

    [Required, EmailAddress, MaxLength(50)]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;    // raw password

    [Range(0, 150)]
    public int Age { get; set; }

    [MaxLength(50)]
    public string Role { get; set; } = "USER";
}
