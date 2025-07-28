using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskMail.ViewModels;
public class Login
{
    [MaxLength(250, ErrorMessage = "Username cannot exceed 250 characters.")]
    public string UserName { get; set; }
    [MaxLength(15, ErrorMessage = "Password cannot exceed 15 characters.")]
    public string Passcode { get; set; }
}
