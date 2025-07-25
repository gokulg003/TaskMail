using System.ComponentModel.DataAnnotations;

namespace TaskMail.DataModels
{
    public class LoginDM
    {
        public string? UsersName { get; set; }
        public string? Passcode { get; set; }
        public string? Email { get; set; }
    }
}