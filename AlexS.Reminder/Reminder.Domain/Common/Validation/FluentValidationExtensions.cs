using FluentValidation.Results;
using Reminder.Contracts.Domain.BusinessRules;
using System.Collections.Generic;

namespace Reminder.Domain.Common.Validation
{
    public static class FluentValidationExtensions
    {
        private static IDictionary<FluentValidation.Severity, Severity>
            _severtyMapper = new Dictionary<FluentValidation.Severity, Severity>
            {
                { FluentValidation.Severity.Error, Severity.Error },
                { FluentValidation.Severity.Info, Severity.Info },
                { FluentValidation.Severity.Warning, Severity.Warning }
            };

        public static Contracts.Domain.BusinessRules.ValidationResult Map(this FluentValidation.Results.ValidationResult validationResult)
        {
            if (validationResult.IsValid) return Contracts.Domain.BusinessRules.ValidationResult.Success;

            var result = new Contracts.Domain.BusinessRules.ValidationResult();

            foreach (var validationFailure in validationResult.Errors)
            {
                var error =
                    new BusinessError(
                        validationFailure.ErrorCode,
                        validationFailure.ErrorMessage,
                        _severtyMapper[validationFailure.Severity]);

                result.AddError(error);
            }

            return result;
        }
    }
}