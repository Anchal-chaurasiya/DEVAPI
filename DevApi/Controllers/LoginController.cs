using Microsoft.AspNetCore.Mvc;
using MyApp.BAL;
using MyApp.Models;

namespace DevApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
   
    public class LoginController : Controller
    {
        private readonly LoginService loginservice;
        public LoginController(LoginService _loginservice)
        {
            this.loginservice = _loginservice;
        }
        [HttpGet(Name = "Login")]
        public UserDto Login(UserDto obj)
        {
            var e = loginservice.Login(obj.UserName, obj.Password);
            return e;
        }
    }
}
