using System.Text.Json.Serialization;

namespace TaskMail.ViewModels;

public class TaskMail_Template_Time_VM
{
   public string Resource { get; set; }
    public string Type { get; set; }
    public string Month { get; set; }
    public string Date { get; set; }
    public string Year { get; set; }
    public System.TimeSpan In_Time { get; set; }
    public System.TimeSpan Out_Time { get; set; }
    public System.TimeSpan Total_Duration { get; set; }
    public System.TimeSpan Break_Duration  { get; set; }
    public System.TimeSpan Act_Work_Hours{ get; set; }
    public string? Comments { get; set; }
}

