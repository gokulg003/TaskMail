using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public interface ITaskMail_TaskHeader_Service
    {
        List<TaskMail_TaskHeader_VM> TaskHeader(TaskMail_TaskHeader_VM taskHeader_VM, TaskHeaderSupplements taskHeaderSupplements);
    }
}