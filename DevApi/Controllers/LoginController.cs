﻿using DevApi.Models.Common;
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
        //[HttpGet(Name = "Login")]
        //public UserResponseDto Login(UserDto obj)
        //{
        //    var e = loginservice.Login(obj.UserName, obj.Password);
        //    return e;
        //}

        //[HttpPost(Name = "Encrypt")]
        //public string Encrypt([FromBody] CommonRequestDto<string> commonRequestDto)
        //{
        //    var e = loginservice.Encrypt(commonRequestDto.Data);
        //    return e;
        //}
        //[HttpPost(Name = "Encrypt")]
        //public string Decrypt(string data)
        //{
        //    var e = loginservice.Decrypt(data);
        //    return e;
        //}
    }
}
