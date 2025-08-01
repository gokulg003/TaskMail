using System.Text.Json.Serialization;

namespace TaskMail.ViewModels
{
    public class UserDetails
    {

        public long UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmailId { get; set; }
        public string UserType { get; set; }
    }
}
