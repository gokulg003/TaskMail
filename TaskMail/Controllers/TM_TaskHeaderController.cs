using Microsoft.AspNetCore.Mvc;
using TaskMail.ViewModels;
using TaskMailService.Services;

namespace TaskMail.Controllers
{
    [ApiController]
    [Route("api")]
    public class TM_TaskHeaderController : ControllerBase
    {
        private readonly ITM_TaskHeaderService _TM_TaskHeaderService;

        public TM_TaskHeaderController(ITM_TaskHeaderService TM_TaskHeaderService)
        {
            _TM_TaskHeaderService = TM_TaskHeaderService;
        }

        [HttpPost("TaskHeader")]
        public ActionResult<List<TM_TaskHeaderVM>> TaskHeader([FromBody] TaskHeaderSupplements taskHeaderSupplements)
        {
            var vm = new TM_TaskHeaderVM();
            var result = _TM_TaskHeaderService.TaskHeader(vm, taskHeaderSupplements);
            if (!string.IsNullOrEmpty(vm.Message))
            {
                return BadRequest(vm.Message); 
            }
            return Ok(result);
        }
    }
}