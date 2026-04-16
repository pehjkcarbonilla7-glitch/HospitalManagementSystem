using Microsoft.AspNetCore.Mvc;
using Hospitalsystem.Data;
using Hospitalsystem.Models;

namespace Hospitalsystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly HospitalContext _context;

        public AuthController(HospitalContext context)
        {
            _context = context;
        }

        // REGISTER USER
        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok("User registered successfully");
        }

        // LOGIN USER
        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            var dbUser = _context.Users
                .FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);

            if (dbUser == null)
                return BadRequest("Invalid username or password");

            return Ok(new
            {
                message = "Login successful",
                username = dbUser.Username,
                role = dbUser.Role
            });
        }
    }
}