namespace Reminder.Contracts.Domain.BusinessRules
{
    public class BusinessError
    {
        public BusinessError(
            string code,
            string description,
            Severity severity = Severity.Error)
        {
            Code = code;
            Description = description;
            Severity = severity;
        }

        public string Code { get; }
        public string Description { get; }
        public Severity Severity { get; }

        public static BusinessError Create(
            string code,
            string description,
            Severity severity = Severity.Error)
        {
            return new BusinessError(code, description, severity);
        }
    }
}
