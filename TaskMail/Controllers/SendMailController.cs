using TaskMailService.Services;
using TaskMail.DataModels;
using TaskMail.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TaskMail.Common;
using System.Reflection.Emit;
using AutoMapper;
using System.ComponentModel.DataAnnotations;


namespace TaskMail.Controllers
{
    
    [Route("api/SendMail")]
    [ApiController]
    public class SendMailController : ControllerBase
    {
        private readonly ISendMailService _SendMail;
    
        public SendMailController(ISendMailService sendMail)
        {
            _SendMail = sendMail;
           
        }
        [HttpPost]
        public IActionResult TaskMail([Required]long headerId, [Required]long UserId)
        {
            _SendMail.TaskMail(headerId, UserId, out int _status, out string _message);
            return StatusCode(CommonDetails.StatusCode(_status), new { data = new { }, status = _status, message = _message });
        }

    }                       
}