using event_managment_API.Data;
using event_managment_API.Models;
using event_managment_API.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace event_managment_API.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private ApplicationDbContext _dbContext;

        public EventController(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(Event Event)
        {
            Event newEvent = new()
            {
                Name = Event.Name,
                Date = DateTime.Now
            };
            _dbContext.Set<Event>().Add(newEvent);
            await _dbContext.SaveChangesAsync();
            return Ok(newEvent);
        }

        [HttpDelete("{eventId}")]
        public async Task<IActionResult> DeleteEvent(int eventId)
        {
            var @event = await _dbContext.Events.FindAsync(eventId);
            if (@event != null)
            {
                return NotFound("event not found");
            }

            _dbContext.Remove(@event);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{eventId}")]
        public async Task<IActionResult> GetEventDetails(int eventId)
        {
            var result = await _dbContext.Events
                .Include(e => e.AttendeeEvents)
                .ThenInclude(ae => ae.Attendee)
                .FirstOrDefaultAsync(e => e.EventId == eventId);

            if (result == null)
            {
                return NotFound("Event not found");
            }

            var EventDto = new EventDTO
            {
                EventId = result.EventId,
                Name = result.Name,
                Date = result.Date,
                Attendees = result.AttendeeEvents.Select(ea => new AttendeeDTO
                {
                    AttendeeId = ea.Attendee.AttendeeId,
                    Name = ea.Attendee.Name,
                    Email = ea.Attendee.Email
                }).ToList(),
            };

            return Ok(EventDto);
        }

        [HttpGet("AllEvents")]
        public IActionResult GetAllEventsWithAttendees()
        {
            var eventsWithAttendees = _dbContext.Events
                .Include(e => e.AttendeeEvents)
                .ThenInclude(ea => ea.Attendee)
                .ToList();

            var eventsDto = eventsWithAttendees.Select(eventItem => new EventDTO
            {
                EventId = eventItem.EventId,
                Name = eventItem.Name,
                Date = eventItem.Date,
                Attendees = eventItem.AttendeeEvents.Select(ea => new AttendeeDTO
                {
                    AttendeeId = ea.Attendee.AttendeeId,
                    Name = ea.Attendee.Name,
                    Email = ea.Attendee.Email // Add any other fields you want
                }).ToList()
            }).ToList();

            return Ok(eventsDto);
        }
    }


}
