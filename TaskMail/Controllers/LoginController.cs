using TaskMailService.Services;
using TaskMail.DataModels;
using TaskMail.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TaskMail.Common;

namespace TaskMail.Controllers
{
    
    [Route("api/my-profile")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _LoginService;
        private int _status;
        private string _message;
        public LoginController(ILoginService loginService)
        {
            _LoginService = loginService;
        }
        [Route("user-login")]
        [HttpGet]
        public ActionResult<UserDetails> Login(Login login)
        {
            var result = _LoginService.Login(login, out _status, out _message);
            return StatusCode(CommonDetails.StatusCode(_status), new { data = result, status = _status, message = _message });
        }
    }
}