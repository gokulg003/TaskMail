using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public interface ITaskMailTemplateTime_Service
    {
        List<TaskMail_Template_Time_VM> Template_Time(TaskMail_Template_Time_VM TemplateTime_VM, TemplateTimeSupplements templateTimeSupplements);
        object Template_Time(TemplateTimeSupplements templateTimeSupplements);
    }
}