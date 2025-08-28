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
        private readonly ILogger<TaskDetailsController> _logger;

        public TaskDetailsController(ITaskDetailsService taskDetailsService, IMapper mapper,ILogger<TaskDetailsController> logger)
        {
            _taskDetailsService = taskDetailsService;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpPost]
        [Route("insert")]
        public ActionResult<List<TaskDetails>> InsertTaskDetails(List<TaskDetails> taskDetailsList)
        {
            _logger.LogTrace("Controller: Start InsertTaskDetails Count={Count}", taskDetailsList.Count);
            var taskDetailsDMs = _taskDetailsService.InsertTaskDetails(taskDetailsList, out _status, out _message);
            List<TaskDetails> result = _mapper.Map<List<TaskDetails>>(taskDetailsDMs);
            _logger.LogTrace("Controller: Completed InsertTaskDetails Count={Count}", taskDetailsList.Count);
            return StatusCode(CommonDetails.StatusCode(_status), new { data = result, status = _status, message = _message, });
        }



        [HttpPut]
        [Route("update")]
        public ActionResult<List<TaskDetailsDM>> UpdateTaskDetails(List<TaskDetails> taskDetailsList)
        {
             _logger.LogTrace("Controller: Start UpdateTaskDetails Count={Count}", taskDetailsList.Count);
            var taskDetailsDMs = _taskDetailsService.UpdateTaskDetails(taskDetailsList, out _status, out _message);
            List<TaskDetails> result = _mapper.Map<List<TaskDetails>>(taskDetailsDMs);
             _logger.LogTrace("Controller: Completed UpdateTaskDetails Count={Count}", taskDetailsList.Count);
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
            _logger.LogTrace("Controller: Start delete TaskDetails Id={Id}", detailsId);
            _taskDetailsService.DeleteTaskDetails(detailsId, headerId, out int _status, out string _message);
            _logger.LogTrace("Controller: Completed delete TaskDetails Id={Id}", detailsId);
            return StatusCode(CommonDetails.StatusCode(_status), new { data = new { }, status = _status, message = _message });
        }


        [HttpGet("retrieve/{headerId}")]
        public IActionResult GetTaskDetails(long headerId)
        {
            _logger.LogTrace("Controller: Start Retrive TaskDetails Id={Id}", headerId);
            var taskDetailsDMs = _taskDetailsService.GetTaskDetails(headerId, out _status, out _message);
            List<TaskDetails> result = _mapper.Map<List<TaskDetails>>(taskDetailsDMs);
            _logger.LogTrace("Controller: Completed Retrive TaskDetails Id={Id}", headerId);
            return StatusCode(CommonDetails.StatusCode(_status), new
            {
                data = result,
                status = _status,
                message = _message
            });
        }
    }
}