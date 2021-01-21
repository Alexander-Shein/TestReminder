using Reminder.Contracts.Domain.BusinessRules;
using System.Collections.Generic;
using System.Linq;

namespace Reminder.Contracts.Svc.Common.Models.View
{
    public class OperationResult
    {
        public bool IsValid
        {
            get
            {
                return Errors == null || !Errors.Any();
            }
        }
        public IEnumerable<BusinessError> Errors { get; set; }
    }

    public class OperationResult<T> : OperationResult
    {
        public T Data { get; set; }

        public static OperationResult<T> Error(string errorCode, string description)
        {
            return new OperationResult<T>
            {
                Errors = new List<BusinessError> { new BusinessError(errorCode, description) }
            };
        }
    }
}
