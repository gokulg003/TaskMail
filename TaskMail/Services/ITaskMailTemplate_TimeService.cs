using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public interface ITaskMailTemplateTime_Service
    {
        TaskMail_TemplateTime_VM Template_Time(TaskMail_TemplateTime_VM TemplateTime_VM);
    }
}