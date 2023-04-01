using Microsoft.AspNetCore.Mvc;
using WebAPIForHousing.Dtos;
using WebAPIForHousing.Interfaces;

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
            var userss= uow.userRepository.Autheticate
                (req.UserName, req.Password);

            if(userss ==null)
                return Unauthorized();

            var loginResp= new LoginResDto();

            loginResp.UsernName = req.UserName;
            loginResp.Token = "This is the tojen";

            return Ok(loginResp);
        }


    }
}
