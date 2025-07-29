using TaskMail.DataModels;
using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public interface ICodeMasterService
    {
        List<CodeMasterDM> GetCodeMaster(string CodeType, out int status, out string message);
    }
}