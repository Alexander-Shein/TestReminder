using Reminder.Domain.Reminders;
using System;

namespace Reminder.Contracts.Svc.Reminders.Models.Input
{
    public class ReminderInputModel
    {
        public string Name { get; set; }
        public ScheduleType ScheduleType { get; set; }
        public DateTime RemindOn { get; set; }
    }
}
