using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskMail.ViewModels;

public class TaskHeaderSupplements
{
    public string Resource { get; set; }
    public string Type { get; set; }

    [Range(1, 12, ErrorMessage = "Month must be between 1 and 12.")]
    public int Month { get; set; }

    [Range(1, 31, ErrorMessage = "Date must be between 1 and 31.")]
    public int Date { get; set; }
    [Range(1900, 2100, ErrorMessage = "Year must be between 1900 and 2100.")]
    public int Year { get; set; }
    public TimeSpan InTime { get; set; }
    public TimeSpan OutTime { get; set; }
    public TimeSpan TotalDuration { get; set; }
    public TimeSpan BreakDuration { get; set; }
    public TimeSpan ActualWorkHours { get; set; }
    public string Comments { get; set; }

}

