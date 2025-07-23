using System.ComponentModel.DataAnnotations;

namespace TaskMail.DataModels
{
    public class TaskMail_Login_DM
    {
        public string? UsersName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
    }
}