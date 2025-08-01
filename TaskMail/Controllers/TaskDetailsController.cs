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
            return StatusCode(CommonDetails.StatusCode(_status), new { data = result, status = _status, message = _message,});
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

    }
}