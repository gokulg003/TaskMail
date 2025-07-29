using System.Text.Json.Serialization;

namespace TaskMail.ViewModels;

public class TaskHeaderDM
{
    public string UserName { get; set; }
    public string Type { get; set; }
    public long Month { get; set; }
    public long Date { get; set; }
    public long Year { get; set; }
    public string InTime { get; set; }
    public string OutTime { get; set; }
    public string TotalDuration { get; set; }
    public string BreakDuration { get; set; }
    public string ActWorkHours { get; set; }
    public string Comments { get; set; }
    public string UserFK { get; set; }
    public string InsertededBy { get; set; }
    public string InsertDate { get; set; }
    public string UpdatedBy { get; set; }
    public string UpdatedDate{ get; set; }    
}

