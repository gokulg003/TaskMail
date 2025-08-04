using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public interface ITaskDetailsService
    {

        List<TaskDetailsDM> TaskDetails(List<TaskDetails> taskDetailsList, out int status, out string message);

        List<TaskDetailsDM> TaskDetailsUpdate(List<TaskDetails> taskDetailsList, out int status, out string message);
        // public bool DeleteTaskDetail(long taskDetailPK, long taskHeaderFK, out int status, out string message);
        public void DeleteTaskDetail(long taskDetailPk, long taskHeader_FK, out int status, out string message);
        public List<TaskDetailsDM> TaskGetDetails(long taskHeader_FK, out int status, out string message);
    }
}