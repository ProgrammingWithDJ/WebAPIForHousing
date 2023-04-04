using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using WebAPIForHousing.Dtos;
using WebAPIForHousing.Interfaces;
using WebAPIForHousing.Models;

namespace WebAPIForHousing.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUnitOfWork uow;

        public AccountController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginReqDto req)
        {
            var userss = uow.userRepository.Autheticate
                (req.UserName, req.Password);

            if (userss == null)
                return Unauthorized();

            var loginResp = new LoginResDto();

            loginResp.UsernName = req.UserName;
            loginResp.Token = CreateJWT(await userss);

            return Ok(loginResp);
        }

        private string CreateJWT(USer user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is my secret"));

            var claim = new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var siginingCredentials = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claim),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = siginingCredentials
            };

            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
