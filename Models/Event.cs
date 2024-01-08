using System.ComponentModel.DataAnnotations;

namespace event_managment_API.Models
{
    public class Event
    {
        public int EventId { get; set; }

        public required string Name { get; set; }
        public DateTime Date { get; set; }

        public List<AttendeeEvent> AttendeeEvents { get; set; }

    }
}
