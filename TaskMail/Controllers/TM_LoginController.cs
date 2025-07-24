using TaskMailService.Services;
using TaskMail.DataModels;
using TaskMail.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace TaskMail.Controllers
{
    [ApiController]
    [Route("api/my-profile")]
    public class TM_LoginController : ControllerBase
    {
        private readonly ITM_LoginService _TM_LoginService;
        public TM_LoginController(ITM_LoginService TM_LoginService)
        {
            _TM_LoginService = TM_LoginService;
        }
        [Route("user-login")]  
        [HttpPost]
        public ActionResult<TM_LoginVM> Login([FromBody] TM_LoginVM loginVM)
        {
            var result = _TM_LoginService.Login(loginVM);
            if (result.Message == "Success")
            {
                return Ok(new { statusCode = 200, message ="Success", data = new{userName = result.UsersName,
                        email = result.Email}});
            }
            else
            {
                return Unauthorized(new { statusCode = 401, message = result.Message, data = (object?)null  });
            }
        }
    }
}