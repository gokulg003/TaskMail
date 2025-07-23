using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public interface ITaskMail_Login_Service
    {
        TaskMail_Login_VM Login(TaskMail_Login_VM loginVm, in string Usersname, in string Password);
    }
}