using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public interface ITaskHeaderService
    {
    TaskHeaderVM TaskHeader(TaskHeaderVM taskHeaderVM, out int status, out string message);
        

    }
}