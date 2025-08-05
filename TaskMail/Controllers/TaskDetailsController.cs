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

        [HttpDelete("delete/{detailsId}/{headerId}")]
        public IActionResult DeleteTaskDetail(long detailsId, long headerId)
        {
            _taskDetailsService.DeleteTaskDetail(detailsId, headerId, out int status, out string message);

            if (status == 2)
                return Ok(new { status, message });

            return NotFound(new { status, message });
        }


        [HttpGet("retrieve/{headerId}")]
        public IActionResult GetTaskDetails(long headerId)
        {
            var result = _taskDetailsService.TaskGetDetails(headerId, out _status, out _message);
            return StatusCode(CommonDetails.StatusCode(_status), new
            {
                data = result,
                status = _status,
                message = _message
            });
        }
    
        
    }
}