using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public interface ITaskMailTemplateTime_Service
    {
        List<TaskMail_Template_Time_VM> Template_Time(TaskMail_Template_Time_VM TemplateTime_VM, in string TM_Template_Time_PK,
         in string TM_Type, in string TM_Month, in string TM_Date, in string TM_Year, in string TM_In_Time, in string TM_Out_Time,
         in string TM_Total_Duration, in string TM_Break_Duration, in string TM_Act_Work_Hours, in string TM_Comments);
    }
}