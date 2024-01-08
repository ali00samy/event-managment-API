namespace event_managment_API.Models.DTO
{
    public class EventDTO
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<AttendeeDTO> Attendees { get; set; }
    }
}
