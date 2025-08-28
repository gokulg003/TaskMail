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
        private readonly ILogger<SendMailService> _logger;
        private int _status;
        private string _message;
        public LoginController(ILoginService loginService, IMapper mapper, ILogger<SendMailService> logger)
        {
            _LoginService = loginService;
            _mapper = mapper;
            _logger = logger;
        }
        [Route("login")]
        [HttpPost]
        public ActionResult<UserDetails> Login([FromBody]Login login)
        {
            _logger.LogTrace("Controller: Login validation started");
            var userDetailsDMs = _LoginService.Login(login, out _status, out _message);
            UserDetails result = _mapper.Map<UserDetails>(userDetailsDMs);
            _logger.LogTrace("Controller: Login validation successfull");
            return StatusCode(CommonDetails.StatusCode(_status), new { data = result, status = _status, message = _message });
        }
    }
}