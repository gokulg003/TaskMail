using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public interface ITaskMailLogin_Service
    {
        TaskMail_Login_VM Login(TaskMail_Login_VM loginVm, in string Username, in string Password);

    }

}