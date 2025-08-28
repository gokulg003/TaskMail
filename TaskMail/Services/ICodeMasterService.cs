using TaskMail.DataModels;
using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public interface ICodeMasterService
    {
        List<CodeMasterDM> GetCodeMaster(long userId,string codeType,long headerId, out int status, out string message);
    }
}