using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public interface ITaskDetailsService
    {
        // List<TaskDetailsVM> TaskDetails(TaskDetailsVM taskDetailsVM, out int status, out string message);
        // List<TaskDetailsVM> TaskDetails(TaskDetailsVM taskDetailsVM, out int status, out string message);
        List<TaskDetailsDM> TaskDetails(List<TaskDetails> taskDetailsList, out int status, out string message);
        // List<TaskDetailsVM> TaskDetailsUpdate(List<TaskDetailsVM> taskDetailsList, out int status, out string message);
        // List<TaskDetailsDM> TaskDetailsUpdate(List<TaskDetails> taskDetailsList, long ID_PK, out int status, out string message);
        
    }
}