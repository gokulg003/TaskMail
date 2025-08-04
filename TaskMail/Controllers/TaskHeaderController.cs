using TaskMailService.Services;
using TaskMail.DataModels;
using TaskMail.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TaskMail.Common;

namespace TaskMail.Controllers
{
    [Route("api")]
    [ApiController]

    public class TaskHeaderController : ControllerBase
    {
        private readonly ITaskHeaderService _TaskHeaderService;
        private int _status;
        private string _message;
        private int _HeaderId;

        public TaskHeaderController(ITaskHeaderService TaskHeaderService)
        {
            _TaskHeaderService = TaskHeaderService;
        }

        [Route("TaskHeader")]
        [HttpPost]
        public ActionResult<TaskHeader> TaskHeader(TaskHeader taskHeaderVM)
        {
            var result = _TaskHeaderService.TaskHeader(taskHeaderVM, out _status, out _message, out _HeaderId);
            return StatusCode(CommonDetails.StatusCode(_status), new { data = result, status = _status, message = _message, HeaderId = _HeaderId });
        }
        [HttpPut("Update/{HeaderId}")]
        public ActionResult<TaskHeader> TaskHeaderUpdate([FromBody]TaskHeader taskHeaderVM,[FromRoute]int HeaderId)
        {
            var result = _TaskHeaderService.TaskHeaderUpdate(taskHeaderVM, out _status, out _message, out _HeaderId,HeaderId);
            return StatusCode(CommonDetails.StatusCode(_status), new { data = result, status = _status, message = _message, HeaderId = _HeaderId });
        }
        
    }
}
