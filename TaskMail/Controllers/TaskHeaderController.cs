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
        private int _HeaderId;



        public TaskHeaderController(ITaskHeaderService TaskHeaderService, IMapper mapper)
        {
            _TaskHeaderService = TaskHeaderService;
            _mapper = mapper;
        }
        [HttpGet("taskHeader/retrieve")]
        public IActionResult GetTaskHeader([FromQuery][Required]string Fromdate,[FromQuery][Required]string Todate,[FromQuery][Required]string UserName)
        {
            var taskHeaderDMs = _TaskHeaderService.GetTaskHeader(UserName,Fromdate,Todate, out _status, out _message);
            List<TaskHeader> result = _mapper.Map<List<TaskHeader>>(taskHeaderDMs);
            return StatusCode(CommonDetails.StatusCode(_status), new { data = result, status = _status, message = _message });
        }


        [Route("taskHeader/insert")]
        [HttpPost]
        public ActionResult<TaskHeader>TaskHeader(TaskHeader taskHeaderVM)
        {
            var taskHeaderDMs = _TaskHeaderService.TaskHeader(taskHeaderVM, out _status, out _message, out _HeaderId);
            TaskHeader result = _mapper.Map<TaskHeader>(taskHeaderDMs);
            return StatusCode(CommonDetails.StatusCode(_status), new { data = result, status = _status, message = _message, HeaderId = _HeaderId });
        }
        [HttpPut("taskHeader/update")]
        public ActionResult<TaskHeader> TaskHeaderUpdate([FromBody]TaskHeader taskHeaderVM)
        {
            var taskHeaderDMs = _TaskHeaderService.TaskHeaderUpdate(taskHeaderVM, out _status, out _message, out _HeaderId);
            TaskHeader result = _mapper.Map<TaskHeader>(taskHeaderDMs);
            return StatusCode(CommonDetails.StatusCode(_status), new { data = result, status = _status, message = _message, HeaderId = _HeaderId });
        }
        
    }
}
