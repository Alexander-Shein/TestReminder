using Reminder.Contracts.Data.Reminders.Domain;
using Reminder.Contracts.Data.Reminders.Query;
using Reminder.Domain.Reminders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reminder.Data.Reminders
{
    public class ReminderRepositoryStub :
        IReminderDomainRepository,
        IReminderQueryRepository
    {
        private static List<ReminderDto> _reminders
            = new List<ReminderDto>
            {
                new ReminderDto { Id = 1, Name = "Reminder1", ScheduleType = ScheduleType.Daily, CreatedAt = DateTime.UtcNow, RemindOn = DateTime.UtcNow.AddMinutes(15), OwnerId = 1 },
                new ReminderDto { Id = 2, Name = "Reminder2", ScheduleType = ScheduleType.Daily, CreatedAt = DateTime.UtcNow, RemindOn = DateTime.UtcNow.AddMinutes(20), OwnerId = 1 },
                new ReminderDto { Id = 3, Name = "Reminder3", ScheduleType = ScheduleType.Daily, CreatedAt = DateTime.UtcNow, RemindOn = DateTime.UtcNow.AddMinutes(25), OwnerId = 1 },
                new ReminderDto { Id = 4, Name = "Reminder4", ScheduleType = ScheduleType.Daily, CreatedAt = DateTime.UtcNow, RemindOn = DateTime.UtcNow.AddMinutes(35), OwnerId = 1 },
                new ReminderDto { Id = 5, Name = "Reminder5", ScheduleType = ScheduleType.Daily, CreatedAt = DateTime.UtcNow, RemindOn = DateTime.UtcNow.AddMinutes(45), OwnerId = 1 },
                new ReminderDto { Id = 6, Name = "Reminder6", ScheduleType = ScheduleType.Daily, CreatedAt = DateTime.UtcNow, RemindOn = DateTime.UtcNow.AddMinutes(55), OwnerId = 1 },
                new ReminderDto { Id = 7, Name = "Reminder7", ScheduleType = ScheduleType.Daily, CreatedAt = DateTime.UtcNow, RemindOn = DateTime.UtcNow.AddMinutes(65), OwnerId = 1 },
                new ReminderDto { Id = 8, Name = "Reminder8", ScheduleType = ScheduleType.Daily, CreatedAt = DateTime.UtcNow, RemindOn = DateTime.UtcNow.AddMinutes(75), OwnerId = 1 },
                new ReminderDto { Id = 9, Name = "Reminder9", ScheduleType = ScheduleType.Daily, CreatedAt = DateTime.UtcNow, RemindOn = DateTime.UtcNow.AddMinutes(885), OwnerId = 1 },
                new ReminderDto { Id = 10, Name = "Reminder10", ScheduleType = ScheduleType.Daily, CreatedAt = DateTime.UtcNow, RemindOn = DateTime.UtcNow.AddMinutes(95), OwnerId = 1 }
            };

        public void Insert(Domain.Reminders.Reminder reminder)
        {
            _reminders.Add(
                new ReminderDto
                {
                    Id = reminder.Id,
                    Name = reminder.Name,
                    ScheduleType = reminder.ScheduleType,
                    CreatedAt = reminder.CreatedAt,
                    RemindOn = reminder.RemindOn
                });
        }

        public void Update(Domain.Reminders.Reminder reminder)
        {
            var dto = _reminders.First(x => x.Id == reminder.Id);

            dto.Name = reminder.Name;
            dto.RemindOn = reminder.RemindOn;
            dto.ScheduleType = reminder.ScheduleType;
        }
        public void Delete(int id)
        {
            var dto = _reminders.First(x => x.Id == id);
            _reminders.Remove(dto);
        }

        public async Task<Domain.Reminders.Reminder> GetByIdAsync(int id)
        {
            var dto = _reminders.First(x => x.Id == id);
            return new Domain.Reminders.Reminder(
                dto.Id,
                dto.OwnerId,
                dto.Name,
                dto.ScheduleType,
                dto.RemindOn);
        }

        public async Task<IEnumerable<ReminderDto>> GetAsync(bool onlyActive)
        {
            return _reminders
                .Where(x => onlyActive == false || x.RemindOn > DateTime.UtcNow)
                .OrderBy(x => x.RemindOn)
                .ToList();
        }
    }
}
