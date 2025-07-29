using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public interface ITaskDetailsService
    {
        List<TaskDetailsVM> TaskDetails(TaskDetailsVM taskDetailsVM, out int status, out string message);
    }
}