using FluentValidation;
using System;

namespace Reminder.Domain.Reminders
{
    internal class ReminderBusinessRules :
        AbstractValidator<Reminder>
    {
        public ReminderBusinessRules()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.OwnerId)
                .GreaterThan(0);

            RuleFor(x => x.ScheduleType)
                .IsInEnum();

            RuleFor(x => x.CreatedAt)
                .NotEqual(DateTime.MinValue);

            RuleFor(x => x.LastModifiedAt)
                .GreaterThanOrEqualTo(x => x.CreatedAt);

            RuleFor(x => x.IsActive)
                .Equal(true);

            RuleFor(x => x.IsDeleted)
                .Equals(false);
                
        }
    }
}