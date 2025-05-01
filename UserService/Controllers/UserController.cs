using Microsoft.AspNetCore.Mvc;
using UserService.Entity;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private static readonly Dictionary<string, string> MockUsers = new()
    {
        { "user1", "password1" },
        { "user2", "password2" }
    };

    [HttpPost("login")]
    public IActionResult Login([FromBody] User userReq)
    {
        if (MockUsers.TryGetValue(userReq.Username, out var password) && password == userReq.Password)
            return Ok("Login successful!");
        return Unauthorized("Invalid credentials.");
    }
}

