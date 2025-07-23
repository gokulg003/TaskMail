using System.Text.Json.Serialization;
public class TaskMail_Login_VM
{
    public string? UsersName { get; set; }
    public string? Password { get; set; }
    [JsonIgnore]
    public string? Message { get; set; }
    [JsonIgnore]
    public string? Email { get; set; }
}
