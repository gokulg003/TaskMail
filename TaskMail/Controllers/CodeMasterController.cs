using TaskMailService.Services;
using TaskMail.DataModels;
using TaskMail.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TaskMail.Common;
using System.Reflection.Emit;

namespace TaskMail.Controllers
{
    
    [Route("api/CodeMaster")]
    [ApiController]
    public class CodeMasterController : ControllerBase
    {
        private readonly ICodeMasterService _CodeMaster;
        private int _status;
        private string _message;
        public CodeMasterController(ICodeMasterService codeMaster)
        {
            _CodeMaster = codeMaster;
        }
        [Route("Dropdown/{CodeType}")]
        [HttpGet]

        public ActionResult<List<CodeMasterVM>> GetCodeMaster(string CodeType)
        {
        var result = _CodeMaster.GetCodeMaster(CodeType,out int _status, out string _message);
        return StatusCode(CommonDetails.StatusCode(_status), new { data = result, status = _status, message = _message });
        }

    }                       
}