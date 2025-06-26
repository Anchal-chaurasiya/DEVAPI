using Dapper;
using DevApi.Models.Common;
using Microsoft.Extensions.Configuration;
using MyApp.Models;
using MyApp.Models.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
namespace MyApp.BAL
{
    public class LoginService
    {
        private readonly JWTFunction jWTFunction;
        private readonly IConfiguration _configuration;

        public LoginService(JWTFunction jwtfunction, IConfiguration configuration)
        {
            this.jWTFunction = jwtfunction;
            this._configuration = configuration;
        }

        public UserResponseDto Login(string UserName, string Password)
        {
            var mCompanyId = _configuration.GetValue<long>("CompanyDetail:ID");
            UserResponseDto res = new UserResponseDto();
            string _proc = "Proc_LoginV2";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 1);
            queryparameter.Add("@UserName", UserName);
            queryparameter.Add("@Password", Crypto.Encrypt(Password));
            queryparameter.Add("@MCompanyID", mCompanyId);
            res = DBHelperDapper.GetAllModel<UserResponseDto>(_proc, queryparameter);
            if (res != null && res.UserGuid != Guid.Empty)
            {

                //var jwtFunction = new JWTFunction(configuration);
                res.Token = jWTFunction.GenerateJwtToken(res.UserId);

                if(res.IsSingleUser==true)
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jwtToken = handler.ReadJwtToken(res.Token);
                    var userId = jwtToken.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
                    var tokenJti = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti)?.Value;


                    string _proc2 = "Proc_LoginV2";
                    var queryparameter2 = new DynamicParameters();
                    queryparameter2.Add("@ProcId", 2);
                    queryparameter2.Add("@UserName", UserName);
                    queryparameter2.Add("@SessionToken", tokenJti);
                    queryparameter2.Add("@MCompanyID", mCompanyId);
                  var   res2 = DBHelperDapper.GetAllModel<UserResponseDto>(_proc2, queryparameter2);
                    return res;
                }
                else
                {
                    return res; 
                }
            }
            else
            {
                res = new UserResponseDto();
                res.Flag = 0;
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
