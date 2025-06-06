using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Models;
using Dapper;
using MyApp.Models.Common;
using DevApi.Models.Common;
using Microsoft.Extensions.Configuration;
namespace MyApp.BAL
{
    public  class LoginService
    {
        private readonly JWTFunction jWTFunction;
        public LoginService(JWTFunction _jwtfunction)
        {
                this.jWTFunction = _jwtfunction;
        }

        public  UserDto Login(string UserName,string Password)
        {
            UserDto res = new UserDto();
            string _proc = "Proc_Login";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 1);
            queryparameter.Add("@UserName", "Admin");
            queryparameter.Add("@Password", "BQLGE773F69/GxGiWmDnow==");
            res = DBHelperDapper.GetAllModel<UserDto>(_proc, queryparameter);
            if (res !=null)
            {

                //var jwtFunction = new JWTFunction(configuration);
                res.Token = jWTFunction.GenerateJwtToken(res.UserName);
            }
                
            return res;
        }
    }
}
