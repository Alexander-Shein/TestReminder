using Reminder.Contracts.Data.Common.Domain;
using System.Threading.Tasks;

namespace Reminder.Contracts.Data.Reminders.Domain
{
    public interface IReminderDomainRepository :
        IDomainRepository
    {
        void Insert(Reminder.Domain.Reminders.Reminder reminder);
        void Update(Reminder.Domain.Reminders.Reminder reminder);
        void Delete(int id);
        Task<Reminder.Domain.Reminders.Reminder> GetByIdAsync(int id);
    }
}
