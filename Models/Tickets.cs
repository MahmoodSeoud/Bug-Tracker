using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Models
{
    public class Tickets
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="This field is required")]
        [DisplayName("Ticket Status")]
        public TicketStatus Status { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Work Description")]
        public string WorkDescription { get; set; }

        [DisplayFormat(DataFormatString ="{0:dd/MM/yyy}")]
        public DateTime Date { get; set; } = DateTime.Now;

        public int? AssignedUserId { get; set; }
    }
}