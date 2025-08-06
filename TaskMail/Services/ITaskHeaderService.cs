using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public interface ITaskHeaderService
    {
        List<TaskHeaderDM> GetTaskHeader(string userName,string fromDate,string toDate,out int status, out string message);
        TaskHeaderDM InsertTaskHeader(TaskHeader taskHeaderVM, out int status, out string message, out int headerId);
        TaskHeaderDM UpdateTaskHeader(TaskHeader taskHeaderVM, out int status, out string message, out int outHeaderId);
    }
}