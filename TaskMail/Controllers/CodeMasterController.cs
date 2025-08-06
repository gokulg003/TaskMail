using TaskMailService.Services;
using TaskMail.DataModels;
using TaskMail.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TaskMail.Common;
using System.Reflection.Emit;
using AutoMapper;


namespace TaskMail.Controllers
{
    
    [Route("api/CodeMaster")]
    [ApiController]
    public class CodeMasterController : ControllerBase
    {
        private readonly ICodeMasterService _CodeMaster;
        private readonly IMapper _mapper;
        private int _status;
        private string _message;

        public CodeMasterController(ICodeMasterService codeMaster, IMapper mapper)
        {
            _CodeMaster = codeMaster;
                _mapper = mapper;
        }
        [Route("dropdown/{CodeType}")]
        [HttpGet]

        public ActionResult<List<CodeMaster>> GetCodeMaster(long userId,string codeType)
        {
        var CodeMasterDMs = _CodeMaster.GetCodeMaster(userId,codeType,out int _status, out string _message);
        List<CodeMaster> result = _mapper.Map<List<CodeMaster>>(CodeMasterDMs);
        return StatusCode(CommonDetails.StatusCode(_status), new { data = result, status = _status, message = _message });
        }

    }                       
}