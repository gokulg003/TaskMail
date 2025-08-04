using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public interface ITaskDetailsService
    {
       
        List<TaskDetailsDM> TaskDetails(List<TaskDetails> taskDetailsList, out int status, out string message);
        
        List<TaskDetailsDM> TaskDetailsUpdate(List<TaskDetails> taskDetailsList, out int status, out string message);
        public bool DeleteTaskDetail(long taskDetailPK, long taskHeaderFK, out int status, out string message);
    }
}