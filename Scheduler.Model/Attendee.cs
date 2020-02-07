namespace Scheduler.Model
{
    public class Attendee : IEntityBase
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        public int Id { get; set; }
    }
}