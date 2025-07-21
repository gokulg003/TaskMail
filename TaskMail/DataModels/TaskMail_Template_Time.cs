using System.Text.Json.Serialization;

namespace TaskMail.ViewModels;

public class TaskMail_Template_Time_DM
{
    public string TM_Template_Time_PK { get; set; }
    public string TM_Type { get; set; }
    public long TM_Month { get; set; }
    public long TM_Date { get; set; }
    public long TM_Year { get; set; }
    public TimeSpan TM_In_Time { get; set; }
    public TimeSpan TM_Out_Time { get; set; }
    public TimeSpan TM_Total_Duration { get; set; }
    public TimeSpan TM_Break_Duration  { get; set; }
    public TimeSpan TM_Act_Work_Hours{ get; set; }
    public string? TM_Comments { get; set; }
}

