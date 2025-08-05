using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public interface ITaskHeaderService
    {
        List<TaskHeaderDM> GetTaskHeader(string UserName,string Fromdate,string Todate,out int status, out string message);
        TaskHeaderDM InsertTaskHeader(TaskHeader taskHeaderVM, out int status, out string message, out int HeaderId);
        TaskHeaderDM UpdateTaskHeader(TaskHeader taskHeaderVM, out int status, out string message, out int outHeaderId);
    }
}