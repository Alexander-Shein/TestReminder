namespace Reminder.Contracts.Domain.Models
{
    public interface IEntity<out TKey> : IIdentity<TKey>
    {
    }
}
