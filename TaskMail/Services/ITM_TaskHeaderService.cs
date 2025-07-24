using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public interface ITM_TaskHeaderService
    {
        List<TM_TaskHeaderVM> TaskHeader(TM_TaskHeaderVM taskHeaderVM, TaskHeaderSupplements taskHeaderSupplements);
    }
}