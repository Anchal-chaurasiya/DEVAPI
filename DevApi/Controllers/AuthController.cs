using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyApp.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DevApi.Models;
using MyApp.BAL;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{

    private readonly IConfiguration _configuration;
    private readonly LoginService loginService;

    public AuthController(IConfiguration configuration, LoginService loginService)
    {
        _configuration = configuration;
        this.loginService = loginService;   
    }

    [HttpPost("UserLogin")]
    public UserDto Login([FromBody] UserReqDto userLogin)
    {
        // Validate user credentials (this should check against a database)
        var e = loginService.Login(userLogin.UserName, userLogin.Password);

        return e;
    }

   
}
