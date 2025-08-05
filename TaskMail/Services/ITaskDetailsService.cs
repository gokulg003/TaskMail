using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public interface ITaskDetailsService
    {

        List<TaskDetailsDM> InsertTaskDetails(List<TaskDetails> taskDetailsList, out int status, out string message);

        List<TaskDetailsDM> UpdateTaskDetails(List<TaskDetails> taskDetailsList, out int status, out string message);
        public void DeleteTaskDetails(long taskDetailPk, long taskHeader_FK, out int status, out string message);
        public List<TaskDetailsDM> GetTaskDetails(long taskHeader_FK, out int status, out string message);
    }
}