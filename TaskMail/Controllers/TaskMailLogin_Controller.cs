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

        public TaskMailLogin_Controller(ITaskMailLogin_Service TaskMailLogin_Service)
        {
            _TaskMailLogin_Service = TaskMailLogin_Service;
        }
     [HttpPost("login")]
        public ActionResult<TaskMail_Login_VM> Login([FromBody] TaskMail_Login_VM loginVm)
        {
            if (loginVm == null || string.IsNullOrWhiteSpace(loginVm.UserName) || string.IsNullOrWhiteSpace(loginVm.Password))
            {
                return BadRequest("Username and Password are required.");
            }
 
            var result = _TaskMailLogin_Service.Login(loginVm, loginVm.UserName, loginVm.Password);
 
            if (!string.IsNullOrEmpty(result.Message))
            {
                return Unauthorized(result.Message);
            }

            return Ok(result);
        }



    }
}