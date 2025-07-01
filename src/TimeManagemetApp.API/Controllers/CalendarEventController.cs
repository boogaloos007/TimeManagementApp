using Microsoft.AspNetCore.Mvc;
using TimeManagemetApp.BusinessLogic.Services;
using TimeManagemetApp.Models.Models;

namespace TimeManagemetApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalendarEventController : ControllerBase
    {
        private readonly CalendarEventService _calendarEventService;

        public CalendarEventController(CalendarEventService calendarEventService)
        {
            _calendarEventService = calendarEventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _calendarEventService.GetAllAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var calendarEvent = await _calendarEventService.GetByIdAsync(id);
            if (calendarEvent == null) return NotFound();
            return Ok(calendarEvent);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CalendarEvent calendarEvent)
        {
            var created = await _calendarEventService.CreateAsync(calendarEvent);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CalendarEvent calendarEvent)
        {
            if (id != calendarEvent.Id) return BadRequest();
            var updated = await _calendarEventService.UpdateAsync(calendarEvent);
            if (!updated) return NotFound();
            return Ok(calendarEvent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _calendarEventService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
