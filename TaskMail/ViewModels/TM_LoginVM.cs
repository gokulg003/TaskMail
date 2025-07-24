using System.Text.Json.Serialization;

namespace TaskMail.ViewModels;
public class TM_LoginVM
{
    public string? UsersName { get; set; }
    public string? Passcode { get; set; }
    [JsonIgnore]
    public string? Message { get; set; }
    [JsonIgnore]
    public string? Email { get; set; }
}
