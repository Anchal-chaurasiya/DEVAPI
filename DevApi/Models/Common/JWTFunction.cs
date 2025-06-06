using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DevApi.Models.Common
{
   
    public   class JWTFunction
    {
        private  readonly IConfiguration configuration;
        public   JWTFunction(IConfiguration _configuration)
        {
                this.configuration = _configuration;
        }
        public   string GenerateJwtToken(string username)
        {
            // string value = System.Configuration.ConfigurationManager.AppSettings["Jwt:key"];
            var keee = configuration["Jwt:Key"];
            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, username)
        };

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(200),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
