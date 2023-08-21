using CaseDAL.Concrete.MySQL;
using CaseEntity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CaseAPI.Utils
{
    public sealed class JwtProvider : IJwtProvider
    {
        JwtOptions options { get; set; }
        public JwtProvider(IOptions<JwtOptions> _options)
        {
            options = _options.Value;
        }
        public string Generate(User user)
        {
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.PrimarySid,user.Id.ToString()),
            };

            var signinCredentials = new SigningCredentials(
                                    new SymmetricSecurityKey(
                                        Encoding.UTF8.GetBytes(options.SecretKey)),
                                    SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                options.Issuer,
                options.Audience,
                claims,
                null,
                DateTime.UtcNow.AddHours(1),
                signinCredentials
                ) ;

            string tokenValue = new JwtSecurityTokenHandler()
                .WriteToken(token);


            return tokenValue;
        }   
    }
}
