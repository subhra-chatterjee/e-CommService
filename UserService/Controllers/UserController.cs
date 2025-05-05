using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using UserService.Entity;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    

    [HttpPost("login")]
    public IActionResult Login([FromBody] User userreq)
    {
        if (userreq.Username == "test" && userreq.Password == "123")
            return Ok(new { Token = "mock-token", Username = userreq.Username });

        return Unauthorized();
    }
    
    [Authorize]
    [HttpGet("profile")]
    public IActionResult GetProfile()
    {
        // This route is only accessible to authenticated users
        var username = User.Identity.Name;  // Get the authenticated user's username
        return Ok(new { Profile = $"Profile for {username}" });
    }
}

