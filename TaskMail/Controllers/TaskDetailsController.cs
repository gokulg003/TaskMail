using Microsoft.AspNetCore.Mvc;
using TaskMailService.Services;
using TaskMail.ViewModels;
using TaskMail.Common;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace TaskMail.Controllers
{
    [Route("api/taskDetails")]
    [ApiController]
    public class TaskDetailsController : ControllerBase
    {
        private readonly ITaskDetailsService _taskDetailsService;
        private readonly IMapper _mapper;
        private int _status;
        private string _message;

        public TaskDetailsController(ITaskDetailsService taskDetailsService, IMapper mapper)
        {
            _taskDetailsService = taskDetailsService;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("insert")]
        public ActionResult<List<TaskDetails>> InsertTaskDetails(List<TaskDetails> taskDetailsList)
        {
            var taskDetailsDMs = _taskDetailsService.InsertTaskDetails(taskDetailsList, out _status, out _message);
            List<TaskDetails> result = _mapper.Map<List<TaskDetails>>(taskDetailsDMs);
            return StatusCode(CommonDetails.StatusCode(_status), new { data = result, status = _status, message = _message, });
        }



        [HttpPut]
        [Route("update")]
        public ActionResult<List<TaskDetailsDM>> UpdateTaskDetails(List<TaskDetails> taskDetailsList)
        {
            var taskDetailsDMs = _taskDetailsService.UpdateTaskDetails(taskDetailsList, out _status, out _message);
            List<TaskDetails> result = _mapper.Map<List<TaskDetails>>(taskDetailsDMs);
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
            _taskDetailsService.DeleteTaskDetails(detailsId, headerId, out int _status, out string _message);
            return StatusCode(CommonDetails.StatusCode(_status), new { data = new { }, status = _status, message = _message });
        }


        [HttpGet("retrieve/{headerId}")]
        public IActionResult GetTaskDetails(long headerId)
        {
            var taskDetailsDMs = _taskDetailsService.GetTaskDetails(headerId, out _status, out _message);
            List<TaskDetails> result = _mapper.Map<List<TaskDetails>>(taskDetailsDMs);

            return StatusCode(CommonDetails.StatusCode(_status), new
            {
                data = result,
                status = _status,
                message = _message
            });
        }
        
        [HttpGet("taskMail/{headerId}")]
        public IActionResult TaskMail(long headerId, [Required]long UserId)
        {
            _taskDetailsService.TaskMail(headerId, UserId, out int _status, out string _message);
            // _mapper.Map<List<TaskDetails>>(_taskDetailsService);
            return StatusCode(CommonDetails.StatusCode(_status), new { data = new { }, status = _status, message = _message });
        }
    
        
    }
}