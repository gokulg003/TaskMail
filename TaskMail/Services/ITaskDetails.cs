using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public interface ITaskDetailsService
    {
        List<TaskHeaderVM> TaskDetails(TaskDetailsVM taskDetailsVM, TaskDetailsSupplements taskHeaderSupplements);
    }

 
}