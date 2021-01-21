using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reminder.Contracts.Data.Reminders.Query
{
    public interface IReminderQueryRepository
    {
        Task<IEnumerable<ReminderDto>> GetAsync(bool onlyActive);
    }
}
