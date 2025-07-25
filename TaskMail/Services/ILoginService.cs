using TaskMail.DataModels;
using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public interface ILoginService
    {
        UserDetailsDM Login(Login login, out int status, out string message);
    }
}