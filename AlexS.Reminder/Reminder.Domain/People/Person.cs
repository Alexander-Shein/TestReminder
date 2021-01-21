using Reminder.Contracts.Domain.Models;
using Reminder.Contracts.Domain.Models.Audit;
using System;

namespace Reminder.Domain.People
{
    public class Person :
        IAggregateRoot<int>,
        IAuditable<DateTime>
    {
        public Person(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public DateTime LastModifiedAt { get; } = DateTime.UtcNow;
        public bool IsActive { get; } = true;
        public bool IsDeleted { get; }
    }
}