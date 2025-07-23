using TaskMailService.Services;
using TaskMail.DataModels;
using TaskMail.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace TaskMail.Controllers
{
    [ApiController]
    [Route("api/PD")]
    public class TaskMail_Login_Controller : ControllerBase
    {
        private readonly ITaskMail_Login_Service _TaskMail_Login_Service;
        // private readonly DefaultParameters _header;

        public TaskMail_Login_Controller(ITaskMail_Login_Service TaskMail_Login_Service)
        {
            _TaskMail_Login_Service = TaskMail_Login_Service;
        }
     [HttpPost("login")]
        public ActionResult<TaskMail_Login_VM> Login([FromBody] TaskMail_Login_VM loginVm)
        {
            // if (loginVm == null || string.IsNullOrWhiteSpace(loginVm.UsersName) || string.IsNullOrWhiteSpace(loginVm.Password))
            // {
            //    return BadRequest(new { statusCode = 400, message = "Username and Password are required.", data = (object?)null });
            // }
            var result = _TaskMail_Login_Service.Login(loginVm, loginVm.UsersName, loginVm.Password);
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