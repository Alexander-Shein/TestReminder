using Reminder.Contracts.Svc.Auth;
using Reminder.Domain.People;

namespace Reminder.Svc.Auth
{
    public class AuthSvcStub : IAuthSvc
    {
        public Person GetCurrentUser()
        {
            return new Person(1);
        }
    }
}
