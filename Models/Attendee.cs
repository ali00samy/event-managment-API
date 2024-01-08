namespace event_managment_API.Models
{
    public class Attendee
    {
        public int AttendeeId { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }

        public IList<AttendeeEvent> AttendeeEvents { get; set; }
    }
}
