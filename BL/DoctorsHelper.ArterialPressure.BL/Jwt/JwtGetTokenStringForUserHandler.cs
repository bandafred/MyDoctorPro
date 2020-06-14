using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DoctorsHelper.ArterialPressure.Data;
using DoctorsHelper.BL.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DoctorsHelper.ArterialPressure.BL.Jwt
{
    public class JwtGetTokenStringForUserHandler : IHandler<User, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly JwtSecurityTokenConfiguration _jwtSecurityTokenConfiguration;

        public JwtGetTokenStringForUserHandler(IHttpContextAccessor httpContextAccessor,
            IOptions<JwtSecurityTokenConfiguration> jwtSecurityTokenConfiguration)
        {
            _httpContextAccessor = httpContextAccessor;
            _jwtSecurityTokenConfiguration = jwtSecurityTokenConfiguration.Value;
        }

        public async Task<string> Handle(User input)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecurityTokenConfiguration.Secret);
            var ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, input.Id),
                    new Claim(nameof(User.SecurityStamp), input.SecurityStamp),
                    new Claim("CreationDateTime", DateTime.Now.ToString()),
                    new Claim("Ip", ip),
                }),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return await Task.FromResult(tokenString);
        }
    }
}