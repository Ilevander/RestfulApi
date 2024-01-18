using Microsoft.AspNetCore.Mvc;
using RestfulApi.Models;

namespace RestfulApi.Controllers
{
    public class AuthenticationController
    {
        [Route("api/[controller]")]
        [ApiController]
        public class UserController : ControllerBase
        {
            private readonly ClinicSysDbContext _dbContext;
            private readonly IConfiguration _configuration;

            public UserController(ClinicSysDbContext dbContext, IConfiguration configuration)
            {
                _dbContext = dbContext;
                _configuration = configuration;
            }

            [HttpPost("register")]
            public ActionResult<User> Register([FromBody] User request)
            {
                try
                {
                    // Check if the username is already taken
                    if (_dbContext.Users.Any(u => u.Username == request.Username))
                    {
                        return BadRequest("Username is already taken.");
                    }

                    // Hash the password before storing it in the database
                    string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.PasswordHash);

                    // Set the hashed password
                    request.PasswordHash = passwordHash;

                    // Set the registration date
                    request.Date = DateTime.Now;

                    // Add the user to the database
                    _dbContext.Users.Add(request);
                    _dbContext.SaveChanges();

                    // Return the user object without the password hash
                    request.PasswordHash = null;
                    return Ok(request);
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it appropriately
                    Console.WriteLine($"Exception: {ex.Message}");
                    return StatusCode(500, "Internal server error");
                }
            }

            [HttpPost("login")]
            public ActionResult<User> Login([FromBody] User request)
            {
                try
                {
                    // Find the user by username
                    var user = _dbContext.Users.SingleOrDefault(u => u.Username == request.Username);

                    // Check if the user exists
                    if (user == null)
                    {
                        return BadRequest("User not found!");
                    }

                    // Verify the password using BCrypt
                    if (!BCrypt.Net.BCrypt.Verify(request.PasswordHash, user.PasswordHash))
                    {
                        return BadRequest("Wrong password");
                    }

                    // TODO: Generate and return a JWT token for authentication

                    // Return the user object without the password hash
                    user.PasswordHash = null;
                    return Ok(user);
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it appropriately
                    Console.WriteLine($"Exception: {ex.Message}");
                    return StatusCode(500, "Internal server error");
                }
            }

        }
    }
}
