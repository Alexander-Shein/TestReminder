using Reminder.Domain.Reminders;
using System;

namespace Reminder.Contracts.Data.Reminders.Query
{
    public class ReminderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public DateTime RemindOn { get; set; }
        public ScheduleType ScheduleType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
