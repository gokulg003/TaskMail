using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public interface ITaskDetailsService
    {
      List<string> InsertTaskDetails(List<TaskDetailsVM> taskDetailsList, out int status, out string message);

    }

 
}