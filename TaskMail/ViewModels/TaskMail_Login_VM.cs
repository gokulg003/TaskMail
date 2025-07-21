using System.Text.Json.Serialization;

namespace TaskMail.ViewModels;

public class TaskMail_Login_VM
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    [JsonIgnore]
    public string? Message { get; set; }
    [JsonIgnore]
    public string? Email { get; set; }
}
