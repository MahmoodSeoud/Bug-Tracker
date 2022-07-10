namespace IssueTracker.Models
{
    public class Tickets
    {
        public int Id { get; set; }

        public TicketStatus Status { get; set; }
        public string Subject { get; set; }

        public string WorkDescription { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public int? AssignedUserId { get; set; }
    }
}