using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public interface ITaskHeaderService
    {
        List<TaskHeaderDM> GetTaskHeader(string userName, string fromDate, string toDate, out int status, out string message);
        TaskHeaderDM InsertTaskHeader(TaskHeader taskHeaderVM, out int status, out string message);
        TaskHeaderDM UpdateTaskHeader(TaskHeader taskHeaderVM, out int status, out string message);
        public void DeleteTaskHeader(long taskHeader_PK, out int status, out string message);
    }
}