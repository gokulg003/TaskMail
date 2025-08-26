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
        private int _mailCount;



        public TaskHeaderController(ITaskHeaderService TaskHeaderService, IMapper mapper)
        {
            _TaskHeaderService = TaskHeaderService;
            _mapper = mapper;
        }
        [HttpGet("taskHeader/retrieve")]
        public IActionResult GetTaskHeader([FromQuery][Required]string fromDate,[FromQuery][Required]string toDate,[FromQuery][Required]string userName)
        {
            var taskHeaderDMs = _TaskHeaderService.GetTaskHeader(userName,fromDate,toDate, out _status, out _message);
            List<TaskHeader> result = _mapper.Map<List<TaskHeader>>(taskHeaderDMs);
            return StatusCode(CommonDetails.StatusCode(_status), new { data = result, status = _status, message = _message });
        }


        [Route("taskHeader/insert")]
        [HttpPost]
        public ActionResult<TaskHeader>InsertTaskHeader(TaskHeader taskHeaderVM)
        {
            var taskHeaderDMs = _TaskHeaderService.InsertTaskHeader(taskHeaderVM, out _status, out _message, out _mailCount);
            TaskHeader result = _mapper.Map<TaskHeader>(taskHeaderDMs);
            return StatusCode(CommonDetails.StatusCode(_status), new { data = result, status = _status, message = _message, mailCount =_mailCount});
        }
        [HttpPut("taskHeader/update")]
        public ActionResult<TaskHeader> UpdateTaskHeader([FromBody]TaskHeader taskHeaderVM)
        {
            var taskHeaderDMs = _TaskHeaderService.UpdateTaskHeader(taskHeaderVM, out _status, out _message, out _mailCount);
            TaskHeader result = _mapper.Map<TaskHeader>(taskHeaderDMs);
            return StatusCode(CommonDetails.StatusCode(_status), new { data = result, status = _status, message = _message , mailCount =_mailCount});
        }
        
    }
}
