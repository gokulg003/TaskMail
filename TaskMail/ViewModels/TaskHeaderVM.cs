using System.Text.Json.Serialization;

namespace TaskMail.ViewModels;
public class TaskHeaderVM
{
    public string Resource { get; set; }
    public string Type { get; set; }
    public long Month { get; set; }
    public long Date { get; set; }
    public long Year { get; set; }
    public string? In_Time { get; set; }
    public string? Out_Time { get; set; }
    public string? Total_Duration { get; set; }
    public string? Break_Duration { get; set; }
    public string? Act_Work_Hours { get; set; }
    public string? Comments { get; set; }
    [JsonIgnore]
    public string? Message { get; set; }
}

