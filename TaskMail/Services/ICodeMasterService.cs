using TaskMail.DataModels;
using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public interface ICodeMaster
    {
        CodeMasterDM GetCodeMaster(out int status, out string message);
    }
}