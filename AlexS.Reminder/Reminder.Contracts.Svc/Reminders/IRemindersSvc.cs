using Reminder.Contracts.Svc.Common.Models.View;
using Reminder.Contracts.Svc.Reminders.Models.Input;
using Reminder.Contracts.Svc.Reminders.Models.View;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reminder.Contracts.Svc.Reminders
{
    public interface IRemindersSvc
    {
        Task<OperationResult<ReminderViewModel>> CreateAsync(ReminderInputModel im);

        Task<OperationResult> DeleteAsync(int id);

        Task<OperationResult<ReminderViewModel>> UpdateAsync(
            int id,
            ReminderInputModel im);

        Task<OperationResult<ReminderViewModel>> PostponeAsync(
            int id,
            PostponeInputModel im);

        Task<IEnumerable<ReminderViewModel>> GetAsync(bool active);
    }
}
