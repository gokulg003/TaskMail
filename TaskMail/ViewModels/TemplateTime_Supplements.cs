using System.Text.Json.Serialization;

namespace TaskMail.ViewModels;

public class TemplateTimeSupplements
{
    public string Resource { get; set; }
    public string Type { get; set; }
    public long Month { get; set; }
    public long Date { get; set; }
    public long Year { get; set; }
    public System.TimeSpan In_Time { get; set; }
    public System.TimeSpan Out_Time { get; set; }
    public System.TimeSpan Total_Duration { get; set; }
    public System.TimeSpan Break_Duration { get; set; }
    public System.TimeSpan Act_Work_Hours { get; set; }
    public string? Comments { get; set; }

}

