using Microsoft.AspNetCore.Mvc;
using TaskMailService.Services;
using TaskMail.ViewModels;
using TaskMail.Common;

namespace TaskMail.Controllers
{
    [Route("api/taskDetails")]
    [ApiController]
    public class TaskDetailsController : ControllerBase
    {
        private readonly ITaskDetailsService _taskDetailsService;
        private int _status;
        private string _message;

        public TaskDetailsController(ITaskDetailsService taskDetailsService)
        {
            _taskDetailsService = taskDetailsService;
        }


        [HttpPost]
        [Route("insert")]
        public ActionResult<List<TaskDetails>> GetTaskDetails(List<TaskDetails> taskDetailsList)
        {
            var result = _taskDetailsService.TaskDetails(taskDetailsList, out _status, out _message);
            return StatusCode(CommonDetails.StatusCode(_status), new { data = result, status = _status, message = _message, });
        }



        [HttpPut]
        [Route("update")]
        public ActionResult<List<TaskDetailsDM>> UpdateTaskDetails(List<TaskDetails> taskDetailsList)
        {
            var result = _taskDetailsService.TaskDetailsUpdate(taskDetailsList, out _status, out _message);
            return StatusCode(CommonDetails.StatusCode(_status), new
            {
                data = result,
                status = _status,
                message = _message
            });
        }

        [HttpDelete("delete/{taskdetailid}/{headerid}")]
        public IActionResult DeleteTaskDetail(long taskDetailid, long headerid)
        {
            _taskDetailsService.DeleteTaskDetail(taskDetailid, headerid, out int status, out string message);

            if (status == 2)
                return Ok(new { status, message });

            return NotFound(new { status, message });
        }


        [HttpGet("get/{taskHeaderid}")]
        public IActionResult GetTaskDetails(long taskHeaderid)
        {
            var result = _taskDetailsService.TaskGetDetails(taskHeaderid, out _status, out _message);
            return StatusCode(CommonDetails.StatusCode(_status), new
            {
                data = result,
                status = _status,
                message = _message
            });
        }
    
        
    }
}