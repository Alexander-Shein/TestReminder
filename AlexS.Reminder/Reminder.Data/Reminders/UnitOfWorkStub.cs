using Reminder.Contracts.Data.Common.Domain;
using System.Threading.Tasks;

namespace Reminder.Data.Reminders
{
    public class UnitOfWorkStub : IUnitOfWork
    {
        public async Task SaveAsync()
        {
        }
    }
}
