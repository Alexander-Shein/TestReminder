using System.Collections.Generic;
using System.Linq;

namespace Reminder.Contracts.Domain.BusinessRules
{
    public class ValidationResult
    {
        public bool IsSuccess => !IsFailure;
        public bool IsFailure => Errors.Any(x => x.Severity == Severity.Error);

        protected ICollection<BusinessError> Errors = new List<BusinessError>();

        public IEnumerable<BusinessError> GetErrors(Severity severity = Severity.Error)
        {
            return Errors.Where(x => x.Severity == severity);
        }

        public static ValidationResult Success = new ValidationResult();

        public void AddError(BusinessError error)
        {
            Errors.Add(error);
        }
    }
    public class ValidationResult<T> : ValidationResult
    {
        public static ValidationResult<T> Ok(T data)
        {
            return new ValidationResult<T>(data);
        }
        public static ValidationResult<T> Fail(IEnumerable<BusinessError> errors)
        {
            var result = new ValidationResult<T>(default(T));

            foreach (var error in errors)
            {
                result.AddError(error);
            }
            return result;
        }

        public static ValidationResult<T> Map(T data, ValidationResult validationResult)
        {
            if (validationResult.IsSuccess)
            {
                return Ok(data);
            }

            return Fail(validationResult.GetErrors());
        }

        public ValidationResult(T data)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
