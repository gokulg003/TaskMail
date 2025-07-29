using System.Text.Json.Serialization;

namespace TaskMail.ViewModels;
public class TaskHeaderVM
{
    public string Resource { get; set; }
    public string Type { get; set; }
    public long Month { get; set; }
    public long Date { get; set; }
    public long Year { get; set; }
    public string InTime { get; set; }
    public string OutTime { get; set; }
    public string TotalDuration { get; set; }
    public string BreakDuration { get; set; }
    public string ActWorkHours { get; set; }
    public string? Comments { get; set; }
    [JsonIgnore]
    public string? Message { get; set; }
}

