namespace Reminder.Contracts.Domain.Models
{
    public interface IIdentity<out TKey>
    {
        TKey Id { get; }
    }
}
