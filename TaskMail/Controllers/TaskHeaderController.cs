using TaskMailService.Services;
using TaskMail.DataModels;
using TaskMail.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskMail.Common;
using System.ComponentModel.DataAnnotations;

namespace TaskMail.Controllers
{
    [Route("api")]
    [ApiController]

    public class TaskHeaderController : ControllerBase
    {
        private readonly ITaskHeaderService _TaskHeaderService;
        private readonly IMapper _mapper;
        private int _status;
        private string _message;
        private readonly ILogger<TaskHeaderController> _logger;



        public TaskHeaderController(ITaskHeaderService TaskHeaderService, IMapper mapper, ILogger<TaskHeaderController> logger)
        {
            _TaskHeaderService = TaskHeaderService;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet("taskHeader/retrieve")]
        public IActionResult GetTaskHeader([FromQuery][Required] string fromDate, [FromQuery][Required] string toDate, [FromQuery][Required] string userName)
        {
            _logger.LogTrace("Controller: Start Retrive Task Header UserName={username}", userName);
            var taskHeaderDMs = _TaskHeaderService.GetTaskHeader(userName, fromDate, toDate, out _status, out _message);
            List<TaskHeader> result = _mapper.Map<List<TaskHeader>>(taskHeaderDMs);
            _logger.LogTrace("Controller: Completed Retrive Task Header UserName={username}", userName);
            return StatusCode(CommonDetails.StatusCode(_status), new { data = result, status = _status, message = _message });
        }


        [Route("taskHeader/insert")]
        [HttpPost]
        public ActionResult<TaskHeader> InsertTaskHeader(TaskHeader taskHeaderVM)
        {
            _logger.LogTrace("Controller: Start Insert Task Header Id={Id}", taskHeaderVM.HeaderId);
            var taskHeaderDMs = _TaskHeaderService.InsertTaskHeader(taskHeaderVM, out _status, out _message);
            TaskHeader result = _mapper.Map<TaskHeader>(taskHeaderDMs);
            _logger.LogTrace("Controller: Completed Insert Task Header Count={Count}", taskHeaderVM.HeaderId);
            return StatusCode(CommonDetails.StatusCode(_status), new { data = result, status = _status, message = _message });
        }
        [HttpPut("taskHeader/update")]
        public ActionResult<TaskHeader> UpdateTaskHeader([FromBody] TaskHeader taskHeaderVM)
        {
            _logger.LogTrace("Controller: Start Update Task Header Id={Id}", taskHeaderVM.HeaderId);
            var taskHeaderDMs = _TaskHeaderService.UpdateTaskHeader(taskHeaderVM, out _status, out _message);
            TaskHeader result = _mapper.Map<TaskHeader>(taskHeaderDMs);
            _logger.LogTrace("Controller: Completed Update Task Header Id={Id}", taskHeaderVM.HeaderId);
            return StatusCode(CommonDetails.StatusCode(_status), new { data = result, status = _status, message = _message });
        }
        
         [HttpDelete("taskHeader/{headerId}")]
        public IActionResult DeleteTaskHeader(long headerId)
        {
            _logger.LogTrace("Controller: Start Insert Task Header Id={Id}", headerId);
            _TaskHeaderService.DeleteTaskHeader(headerId, out int _status, out string _message);
            _logger.LogTrace("Controller: Completed Insert Task Header Id={Id}", headerId);
            return StatusCode(CommonDetails.StatusCode(_status), new { data = new { }, status = _status, message = _message });
        }
        
    }
}
