using TaskMail.DataModels;
using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public interface ISendMailService
    {
        public void TaskMail(long taskHeaderPk,long UserFk, out int status, out string message, out long mailCount);
    }
}