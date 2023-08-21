using CaseAPI.Models;
using CaseAPI.Utils;
using CaseDAL.Abstract;
using CaseEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CaseAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        public IUserRepository userRepository { get; set; }
        IJwtProvider jwtProvider { get; set; }
        public AuthController(IUserRepository _userRepository,IJwtProvider _jwtProvider)
        {
            userRepository = _userRepository;
            jwtProvider = _jwtProvider;
        }

        [HttpGet("Login")]
        public async  Task<IActionResult> Login(string email,string password)
        {
            try
            {
                User user = await userRepository.GetByEmailAndPasswordAsync(email, password);

                if(user == null)
                {
                    return Ok(new AuthResponse { IsOk = false, Errors = new List<string> { "Email yada şifre hatalı" } });
                }

                string token = jwtProvider.Generate(user);


                return Ok(new AuthResponse { IsOk=true, User = user,Token = token});
            }
            catch (Exception ex)
            {

                return Ok(new AuthResponse { IsOk = false, Errors = new List<string> { ex.Message } });
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            try
            {
                User user = new User()
                {
                    Id = new Guid(),
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    Email = userDTO.Email,
                    Password = userDTO.Password
                };

                userRepository.Create(user);
                string token = jwtProvider.Generate(user);
                return Ok(new AuthResponse { User = user, Token = token });

            }
            catch (Exception ex)
            {

                return Ok(new AuthResponse { IsOk = false,Errors = new List<string> { ex.Message } });
            }
           
        }

        [HttpGet("ValidateToken")]
        public bool ValidateToken(string token )
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("tnJB6IJnhy/cG7letMQ9ADB/1Nl0/U3pwAXPci9fjzU="));
            try
            {
                JwtSecurityTokenHandler handler = new();
                handler.ValidateToken(token, new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey,
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuer = false

                }, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                var claims  = jwtToken.Claims.ToList();
                    return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
