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
    
    [Route("api/CodeMaster")]
    [ApiController]
    public class CodeMasterController : ControllerBase
    {
        private readonly ICodeMasterService _CodeMaster;
        private readonly IMapper _mapper;
        private readonly ILogger<SendMailService> _logger;
        private int _status;
        private string _message;

        public CodeMasterController(ICodeMasterService codeMaster, IMapper mapper, ILogger<SendMailService> logger)
        {
            _CodeMaster = codeMaster;
            _mapper = mapper;
            _logger = logger;
        }
        [Route("dropdown")]
        [HttpGet]

        public ActionResult<List<CodeMaster>> GetCodeMaster(long userId, [Required] string codeType, long headerId)
        {
            _logger.LogTrace("Controller: CodeMaster retrieve started");
            var result = _CodeMaster.GetCodeMaster(userId, codeType, headerId, out int _status, out string _message);
            // List<CodeMaster> result = _mapper.Map<List<CodeMaster>>(CodeMasterDMs);
            _logger.LogTrace("Controller: CodeMaster retrieve successfull");
            return StatusCode(CommonDetails.StatusCode(_status), new { data = result, status = _status, message = _message });
        }

    }                       
}