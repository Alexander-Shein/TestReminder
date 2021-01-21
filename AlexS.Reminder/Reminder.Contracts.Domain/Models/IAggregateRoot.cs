namespace Reminder.Contracts.Domain.Models
{
    public interface IAggregateRoot<out TKey> : IEntity<TKey>
    {
    }
}
