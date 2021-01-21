using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reminder.Contracts.Svc.Reminders;
using Reminder.Contracts.Svc.Reminders.Models.Input;
using System.Threading.Tasks;

namespace Reminder.Api.Controllers
{
    [ApiController]
    [Route("v1/reminders")]
    public class RemindersController : ControllerBase
    {
        private readonly ILogger<RemindersController> _logger;
        private readonly IRemindersSvc _remindersSvc;

        public RemindersController(
            ILogger<RemindersController> logger,
            IRemindersSvc remindersSvc)
        {
            _logger = logger;
            _remindersSvc = remindersSvc;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ReminderInputModel im)
        {
            var operationResult = await _remindersSvc.CreateAsync(im);

            if (operationResult.IsValid)
            {
                return Ok(operationResult.Data);
            }

            return BadRequest(operationResult.Errors);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, ReminderInputModel im)
        {
            var operationResult = await _remindersSvc.UpdateAsync(id, im);

            if (operationResult.IsValid)
            {
                return Ok(operationResult.Data);
            }

            return BadRequest(operationResult.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var operationResult = await _remindersSvc.DeleteAsync(id);

            if (operationResult.IsValid)
            {
                return Ok();
            }

            return BadRequest(operationResult.Errors);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PostponeAsync(int id, PostponeInputModel im)
        {
            var operationResult = await _remindersSvc.PostponeAsync(id, im);

            if (operationResult.IsValid)
            {
                return Ok(operationResult.Data);
            }

            return BadRequest(operationResult.Errors);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAsync(bool active = true)
        {
            var reminders = await _remindersSvc.GetAsync(active);
            return Ok(reminders);
        }
    }
}
