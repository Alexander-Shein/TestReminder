using Reminder.Contracts.Svc.Reminders.Models.Input;

namespace Reminder.Contracts.Svc.Reminders.Models.View
{
    public class ReminderViewModel : ReminderInputModel
    {
        public int Id { get; set; }

        public static ReminderViewModel MapToVM(Reminder.Domain.Reminders.Reminder domain)
        {
            if (domain == null) return null;

            return new ReminderViewModel
            {
                Id = domain.Id,
                Name = domain.Name,
                ScheduleType = domain.ScheduleType,
                RemindOn = domain.RemindOn
            };
        }

    }
}
