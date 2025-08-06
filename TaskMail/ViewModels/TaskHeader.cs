using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskMail.ViewModels;

public class TaskHeader
{
    public long HeaderId { get; set; }
    public string Resource { get; set; }
    public string Type { get; set; }

    // [Range(01, 12, ErrorMessage = "Month must be between 1 and 12.")]
    public string Month { get; set; }

    // [Range(01, 31, ErrorMessage = "Date must be between 1 and 31.")]
    public string Date { get; set; }
    // [Range(1900, 2100, ErrorMessage = "Year must be between 1900 and 2100.")]
    public string Year { get; set; }
    public string InTime { get; set; }
    public string OutTime { get; set; }
    public string TotalDuration { get; set; }
    public string BreakDuration { get; set; }
    public string ActWorkHours { get; set; }
    public string Comments { get; set; }
    
    public string UserName { get; set; }
    public long UserId { get; set; }

}

