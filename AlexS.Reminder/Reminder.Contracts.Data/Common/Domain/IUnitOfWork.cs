using System.Threading.Tasks;

namespace Reminder.Contracts.Data.Common.Domain
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
    }
}
