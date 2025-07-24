using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public interface ITM_LoginService
    {
        TM_LoginVM Login(TM_LoginVM loginVM);
    }
}