using TaskMail.DataModels;
using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public interface ICodeMasterService
    {
        List<CodeMasterDM> GetCodeMaster(long UserId,string CodeType, out int status, out string message);
    }
}