using TaskMailService.Services;
using TaskMail.DataModels;
using TaskMail.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace TaskMail.Controllers
{
    [ApiController]
    [Route("api/PD")]
    public class TaskMailLogin_Controller : ControllerBase
    {
        private readonly ITaskMailLogin_Service _TaskMailLogin_Service;
        private readonly DefaultParameters _header;

        public TaskMailLogin_Controller(ITaskMailLogin_Service TaskMailLogin_Service)
        {
            _TaskMailLogin_Service = TaskMailLogin_Service;
        }
     [HttpPost("login")]
        public ActionResult<TaskMail_Login_VM> Login([FromBody] TaskMail_Login_VM loginVm)
        {
            if (loginVm == null || string.IsNullOrWhiteSpace(loginVm.UserName) || string.IsNullOrWhiteSpace(loginVm.Password))
            {
               return BadRequest(new { statusCode = 400, message = "Username and Password are required.", data = (object?)null });
            }
            var result = _TaskMailLogin_Service.Login(loginVm, loginVm.UserName, loginVm.Password);
            if (result.Message == "Success")
            {
                return Ok(new { statusCode = 200, message ="Success", data = new{userName = result.UserName,
                        email = result.Email}});
            }
            else
            {
                return Unauthorized(new { statusCode = 401, message = result.Message, data = (object?)null  });
            }
        }
    }
}