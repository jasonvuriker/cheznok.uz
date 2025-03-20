using cheznok.uz.Dtos;
using cheznok.uz.Services;
using Microsoft.AspNetCore.Mvc;

namespace cheznok.uz.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] SignInDto signInDto)
    {
        var apiKey = await _userService.SignIn(signInDto.Username, signInDto.Password);

        return Ok(apiKey);
    }
}
