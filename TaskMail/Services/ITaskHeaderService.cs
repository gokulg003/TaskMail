using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public interface ITaskHeaderService
    {
    TaskHeaderDM TaskHeader(TaskHeader taskHeaderVM, out int status, out string message, out int HeaderId);
        
    // TaskHeaderVM TaskHeaderUpdate(TaskHeaderVM taskHeaderVM, out int status, out string message);
    }
}