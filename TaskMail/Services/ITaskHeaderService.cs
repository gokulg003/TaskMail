using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public interface ITaskHeaderService
    {
        List<TaskHeaderVM> TaskHeader(TaskHeaderVM taskHeaderVM, TaskHeaderSupplements taskHeaderSupplements,out int status, out string message );
    }
}