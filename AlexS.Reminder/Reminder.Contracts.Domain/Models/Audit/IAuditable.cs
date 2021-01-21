namespace Reminder.Contracts.Domain.Models.Audit
{
    public interface IAuditable<out T>
    {
        T CreatedAt { get; }
        T LastModifiedAt { get; }
    }
}
