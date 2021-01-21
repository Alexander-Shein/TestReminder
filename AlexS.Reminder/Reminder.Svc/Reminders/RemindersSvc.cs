using Reminder.Contracts.Data.Common.Domain;
using Reminder.Contracts.Data.Reminders.Domain;
using Reminder.Contracts.Data.Reminders.Query;
using Reminder.Contracts.Domain.BusinessRules;
using Reminder.Contracts.Svc.Auth;
using Reminder.Contracts.Svc.Common.Models.View;
using Reminder.Contracts.Svc.Reminders;
using Reminder.Contracts.Svc.Reminders.Models.Input;
using Reminder.Contracts.Svc.Reminders.Models.View;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reminder.Svc.Reminders
{
    public class RemindersSvc : IRemindersSvc
    {
        private readonly IAuthSvc _authSvc;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReminderDomainRepository _reminderDomainRepository;
        private readonly IReminderQueryRepository _reminderQueryRepository;

        public RemindersSvc(
            IAuthSvc authSvc,
            IUnitOfWork unitOfWork,
            IReminderDomainRepository reminderDomainRepository,
            IReminderQueryRepository reminderQueryRepository)
        {
            _authSvc = authSvc;
            _unitOfWork = unitOfWork;
            _reminderDomainRepository = reminderDomainRepository;
            _reminderQueryRepository = reminderQueryRepository;
        }

        public async Task<OperationResult<ReminderViewModel>> CreateAsync(ReminderInputModel im)
        {
            im = im ?? new ReminderInputModel();

            var user = _authSvc.GetCurrentUser();

            var result = Domain.Reminders.Reminder.CreateAndValidate(
                user,
                im.Name,
                im.ScheduleType,
                im.RemindOn);

            if (result.IsSuccess)
            {
                _reminderDomainRepository.Insert(result.Data);
                await _unitOfWork.SaveAsync();
            }

            return MapToVM(result);
        }

        public async Task<OperationResult<ReminderViewModel>> UpdateAsync(int id, ReminderInputModel im)
        {
            im = im ?? new ReminderInputModel();

            var user = _authSvc.GetCurrentUser();

            var result = Domain.Reminders.Reminder.CreateAndValidate(
                user,
                im.Name,
                im.ScheduleType,
                im.RemindOn,
                id);

            if (result.IsSuccess)
            {
                _reminderDomainRepository.Update(result.Data);
                await _unitOfWork.SaveAsync();
            }

            return MapToVM(result);
        }

        public async Task<OperationResult> DeleteAsync(int id)
        {
            _reminderDomainRepository.Delete(id);
            await _unitOfWork.SaveAsync();

            return new OperationResult();
        }

        public async Task<OperationResult<ReminderViewModel>> PostponeAsync(int id, PostponeInputModel im)
        {
            var reminder = await _reminderDomainRepository.GetByIdAsync(id);

            if (reminder == null)
                OperationResult<ReminderViewModel>.Error(
                    "TODO: ErrorCode",
                    $"Reminder {id} doesn't exist");

            var result = reminder.Postpone(im.RemindOn);

            if (result.IsSuccess)
            {
                _reminderDomainRepository.Update(reminder);
                await _unitOfWork.SaveAsync();
            }

            return MapToVM(result);
        }

        public async Task<IEnumerable<ReminderViewModel>> GetAsync(bool onlyActive)
        {
            var dtos = await _reminderQueryRepository.GetAsync(onlyActive);
            return dtos.Select(Map);
        }

        private OperationResult<ReminderViewModel> MapToVM(
            ValidationResult<Domain.Reminders.Reminder> validationResult)
        {
            return new OperationResult<ReminderViewModel>
            {
                Data = ReminderViewModel.MapToVM(validationResult.Data),
                Errors = validationResult.GetErrors(Severity.Error)
            };
        }

        private ReminderViewModel Map(ReminderDto dto)
        {
            return new ReminderViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                RemindOn = dto.RemindOn,
                ScheduleType = dto.ScheduleType
            };
        }
    }
}
