using Microsoft.AspNetCore.Mvc;
using TaskMail.ViewModels;
using TaskMailService.Services;

namespace TaskMail.Controllers
{
    [ApiController]
    [Route("api/PD")]
    public class TaskMail_TaskHeader_Controller : ControllerBase
    {
        private readonly ITaskMail_TaskHeader_Service _TaskMail_TaskHeader_Service;

        public TaskMail_TaskHeader_Controller(ITaskMail_TaskHeader_Service TaskMail_TaskHeader_Service)
        {
            _TaskMail_TaskHeader_Service = TaskMail_TaskHeader_Service;
        }

        [HttpPost("Template_Time")]
        public ActionResult<List<TaskMail_TaskHeader_VM>> TaskHeader([FromBody] TaskHeaderSupplements taskHeaderSupplements)
        {
            var vm = new TaskMail_TaskHeader_VM();
            var result = _TaskMail_TaskHeader_Service.TaskHeader(vm, taskHeaderSupplements);
            if (!string.IsNullOrEmpty(vm.Message))
            {
                return BadRequest(vm.Message); 
            }
            return Ok(result);
        }
    }
}