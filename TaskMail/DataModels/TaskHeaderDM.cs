using System.Text.Json.Serialization;

namespace TaskMail.ViewModels;

public class TaskHeaderDM
{
    public string UserName { get; set; }
    public string Type { get; set; }
    public long Month { get; set; }
    public long Date { get; set; }
    public long Year { get; set; }
    public TimeSpan InTime { get; set; }
    public TimeSpan OutTime { get; set; }
    public TimeSpan TotalDuration { get; set; }
    public TimeSpan BreakDuration { get; set; }
    public TimeSpan ActWorkHours { get; set; }
    public string Comments { get; set; }
    public string UserFK { get; set; }
    public string InsertededBy { get; set; }
    public string InsertDate { get; set; }
    public string UpdatedBy { get; set; }
    public string UpdatedDate{ get; set; }    
}

