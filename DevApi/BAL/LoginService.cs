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

        public  UserResponseDto Login(string UserName,string Password)
        {
            UserResponseDto res = new UserResponseDto();
            string _proc = "Proc_Login";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 1);
            queryparameter.Add("@UserName", UserName);
            queryparameter.Add("@Password",Crypto.Encrypt( Password));
            res = DBHelperDapper.GetAllModel<UserResponseDto>(_proc, queryparameter);
            if (res != null && res.UserGuid !=Guid.Empty )
            {

                //var jwtFunction = new JWTFunction(configuration);
                res.Token = jWTFunction.GenerateJwtToken(res.UserName);
            }
            else
            {
                res = new UserResponseDto();
                res.Flag= 0;
                res.Message = "Invalid UserName or Password";
            }

                return res;
        }

        public string Encrypt(string data)
        {
           
           
            string res = Crypto.Encrypt(data);
            return res;
        }
        public string Decrypt(string data)
        { 

            string res = Crypto.Decrypt(data);
            return res;
        }
    }
}
