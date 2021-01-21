using Reminder.Contracts.Domain.BusinessRules;
using Reminder.Contracts.Domain.Models;
using Reminder.Contracts.Domain.Models.Audit;
using Reminder.Domain.People;
using Reminder.Domain.Common.Validation;
using System;

namespace Reminder.Domain.Reminders
{
    public class Reminder :
        IAggregateRoot<int>,
        IAuditable<DateTime>
    {
        public Reminder(
            int id,
            int ownerId,
            string name,
            ScheduleType scheduleType,
            DateTime remindOn)
        {
            Id = id;
            OwnerId = ownerId;
            Name = name;
            ScheduleType = scheduleType;
            RemindOn = remindOn;
        }

        public int Id { get; }
        public string Name { get; }
        public ScheduleType ScheduleType { get; }
        public DateTime RemindOn { get; private set; }
        public int OwnerId { get; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public DateTime LastModifiedAt { get; private set; } = DateTime.UtcNow;
        public bool IsActive { get; } = true;
        public bool IsDeleted { get; }

        public ValidationResult<Reminder> Postpone(DateTime remindOn)
        {
            RemindOn = remindOn;
            LastModifiedAt = DateTime.UtcNow;
            var validationResult = Validate();
            return ValidationResult<Reminder>.Map(this, validationResult);
        }

        public ValidationResult Validate()
        {
            var validator = new ReminderBusinessRules();
            var validationResult = validator.Validate(this).Map();
            return validationResult;
        }

        public static ValidationResult<Reminder> CreateAndValidate(
            Person owner,
            string name,
            ScheduleType scheduleType,
            DateTime eventDateTime,
            int id = 0)
        {
            var inst = new Reminder(
                id,
                owner?.Id ?? 0,
                name,
                scheduleType,
                eventDateTime);

            var validationResult = inst.Validate();
            return ValidationResult<Reminder>.Map(inst, validationResult);
        }
    }
}