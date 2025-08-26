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
        [HttpGet]
        public IActionResult TaskMail([Required]long headerId, [Required]long userId)
        {
            _SendMail.TaskMail(headerId, userId, out int _status, out string _message, out long _mailCount);
            return StatusCode(CommonDetails.StatusCode(_status), new { data = new { }, status = _status, message = _message , mailCount=_mailCount});
        }

    }                       
}