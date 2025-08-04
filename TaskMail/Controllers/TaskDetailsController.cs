using Microsoft.AspNetCore.Mvc;
using TaskMailService.Services;
using TaskMail.ViewModels;
using TaskMail.Common;

namespace TaskMail.Controllers
{
    [Route("api/task-details")]
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

        [Route("get-task-details")]
        [HttpPost]
        public ActionResult<List<TaskDetails>> GetTaskDetails(List<TaskDetails> taskDetailsList)
        {
            var result = _taskDetailsService.TaskDetails(taskDetailsList, out _status, out _message);
            return StatusCode(CommonDetails.StatusCode(_status), new { data = result, status = _status, message = _message, });
        }


        [Route("update-task-details")]
        [HttpPut]
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

        [HttpDelete("task-details/{taskDetailPk}/{headerPk}")]
        public IActionResult DeleteTaskDetail(long taskDetailPk, long headerPk)
        {
            _taskDetailsService.DeleteTaskDetail(taskDetailPk, headerPk, out int status, out string message);

            if (status == 2)
                return Ok(new { status, message });

            return NotFound(new { status, message });
        }


        [HttpGet("get-task-details/{taskHeaderFk}")]
        public IActionResult GetTaskDetails(long taskHeaderFk)
        {
            var result = _taskDetailsService.TaskGetDetails(taskHeaderFk, out _status, out _message);
            return StatusCode(CommonDetails.StatusCode(_status), new
            {
                data = result,
                status = _status,
                message = _message
            });
        }
    
        
    }
}