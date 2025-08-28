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
        private readonly ILogger<SendMailService> _logger;

        public SendMailController(ISendMailService sendMail, ILogger<SendMailService> logger)
        {
            _SendMail = sendMail;
            _logger = logger;

        }
        [HttpGet]
        public IActionResult TaskMail([Required]long headerId, [Required]long userId)
        {
            _logger.LogTrace("Controller: Start Send Mail");
            _SendMail.TaskMail(headerId, userId, out int _status, out string _message, out long _mailCount);
            _logger.LogTrace("Controller: Completed Send Mail");
            return StatusCode(CommonDetails.StatusCode(_status), new { data = new { }, status = _status, message = _message, mailCount = _mailCount });
        }

    }                       
}