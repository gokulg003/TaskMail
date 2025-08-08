using TaskMailService.Services;
using TaskMail.DataModels;
using TaskMail.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TaskMail.Common;
using AutoMapper;

namespace TaskMail.Controllers
{
    
    [Route("api/my-profile")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _LoginService;
        private readonly IMapper _mapper;
        private int _status;
        private string _message;
        public LoginController(ILoginService loginService, IMapper mapper)
        {
            _LoginService = loginService;
            _mapper = mapper;
        }
        [Route("login")]
        [HttpPost]
        public ActionResult<UserDetails> Login([FromBody]Login login)
        {
            var userDetailsDMs = _LoginService.Login(login, out _status, out _message);
            UserDetails result = _mapper.Map<UserDetails>(userDetailsDMs);
            return StatusCode(CommonDetails.StatusCode(_status), new { data = result, status = _status, message = _message });
        }
    }
}