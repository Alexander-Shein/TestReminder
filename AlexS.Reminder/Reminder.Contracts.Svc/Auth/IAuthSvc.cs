using Reminder.Domain.People;

namespace Reminder.Contracts.Svc.Auth
{
    public interface IAuthSvc
    {
        Person GetCurrentUser();
    }
}
