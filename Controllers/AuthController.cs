using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using GrpcService1.Dtos;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace GrpcService1.Controllers;

[Route("api/[Controller]")]
[ApiController]

public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;

    public AuthController( UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost("register")]

    public async Task<IActionResult> Register([FromBody] RegisterRequestDto model)
{
    var user = new IdentityUser
    {
        UserName = model.Username,
        Email = model.Email
    };

    // Aquí podrías agregar más lógica para manejar el registro, como crear el usuario en la base de datos
    // Ejemplo:
    var result = await _userManager.CreateAsync(user, model.Password);

    if (result.Succeeded)
    {
        return Ok(new { Message = "User registered successfully!" });
    }

    return BadRequest(result.Errors);
}
  [HttpPost("login")]
public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
{
  
    var user = await _userManager.FindByNameAsync(model.UserName);

  
    if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.UserName),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKeyThatIsAtLeast32Chars123!")); 
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "camilo",
            audience: "web",
            claims: claims,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: creds);

      
        return Ok(new
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = token.ValidTo
        });
    }

   
    return Unauthorized(new { Message = "Invalid username or password." });
}

}