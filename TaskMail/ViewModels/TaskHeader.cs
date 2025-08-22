using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskMail.ViewModels;

public class TaskHeader
{
    public long HeaderId { get; set; }
    public string Resource { get; set; }
    public long HeaderResourceId { get; set; }
    public string Type { get; set; }
    public string Month { get; set; }
    public string Date { get; set; }
    public string Year { get; set; }
    public string InTime { get; set; }
    public string OutTime { get; set; }
    public string TotalDuration { get; set; }
    public string BreakDuration { get; set; }
    public string ActWorkHours { get; set; }
    public string Comments { get; set; }

    public string UserName { get; set; }
    public long UserId { get; set; }

    public string ResourceCode { get; set; }
    public string TypeCode { get; set; }
}

