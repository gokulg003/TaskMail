using Microsoft.AspNetCore.Mvc;
using TaskMail.ViewModels;
using TaskMailService.Services;

namespace TaskMail.Controllers
{
    [ApiController]
    [Route("api/PD")]
    public class TaskMail_Template_Time_Controller : ControllerBase
    {
        private readonly ITaskMailTemplateTime_Service _TaskMailTemplateTime_Service;

        public TaskMail_Template_Time_Controller(ITaskMailTemplateTime_Service TaskMailTemplateTime_Service)
        {
            _TaskMailTemplateTime_Service = TaskMailTemplateTime_Service;
        }

        [HttpPost("Template_Time")]
        public ActionResult<List<TaskMail_Template_Time_VM>> Template_Time([FromBody] TemplateTimeSupplements templateTimeSupplements)
        {
            var vm = new TaskMail_Template_Time_VM();
            var result = _TaskMailTemplateTime_Service.Template_Time(vm, templateTimeSupplements);
            if (!string.IsNullOrEmpty(vm.Message))
            {
                return BadRequest(vm.Message); 
            }
            return Ok(result);
        }
    }
}