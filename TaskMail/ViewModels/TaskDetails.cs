using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskMail.ViewModels;

public class TaskDetails
{
    public string Project { get; set; }
    public string Sprint { get; set; }
    public string TaskName { get; set; }
    public string Type { get; set; }
    public long SOWIssueNo { get; set; }
    public long Year { get; set; }
    public string In_Time { get; set; }
    public string Out_Time { get; set; }
    public string Total_Duration { get; set; }
    public string Break_Duration { get; set; }
    public string Act_Work_Hours { get; set; }
    public string? Comments { get; set; }
    [JsonIgnore]
    public string Message { get; set; }
}