using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskMail.ViewModels;
public class Login
{
    [MaxLength(250, ErrorMessage = "Username cannot exceed 250 characters.")]
    public string UsersName { get; set; }
    public string Passcode { get; set; }
}
