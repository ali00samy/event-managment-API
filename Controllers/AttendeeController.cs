using event_managment_API.Data;
using event_managment_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace event_managment_API.Controllers
{
    [Route("api/attendee")]
    [ApiController]
    public class AttendeeController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public AttendeeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAttendee([FromBody] Attendee newAttendee)
        {
            _dbContext.Attendees.Add(newAttendee);
            await _dbContext.SaveChangesAsync();
            return Ok(newAttendee);
        }

        [HttpPost("register")]
        public async Task<IActionResult> AssignAttendeeToEvent([FromBody] AttendeeEvent attendeeEvent)
        {
            _dbContext.AttendeeEvents.Add(attendeeEvent);
            await _dbContext.SaveChangesAsync();
            return Ok(attendeeEvent);
        }
    }
}
