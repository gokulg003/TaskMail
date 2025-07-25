using Microsoft.AspNetCore.Mvc;
using TaskMail.ViewModels;
using TaskMailService.Services;

namespace TaskMail.Controllers
{
    [ApiController]
    [Route("api")]
    public class TaskHeaderController : ControllerBase
    {
        private readonly ITaskHeaderService _TaskHeaderService;
        public TaskHeaderController(ITaskHeaderService TaskHeaderService)
        {
            _TaskHeaderService = TaskHeaderService;
        }

        [HttpPost("TaskHeader")]
        public ActionResult<List<TaskHeaderVM>> TaskHeader([FromBody] TaskHeaderSupplements taskHeaderSupplements)
        {
            var vm = new TaskHeaderVM();
            var result = _TaskHeaderService.TaskHeader(vm, taskHeaderSupplements);
            if (!string.IsNullOrEmpty(vm.Message))
            {
                return BadRequest(vm.Message); 
            }
            return Ok(result);
        }
    }
}