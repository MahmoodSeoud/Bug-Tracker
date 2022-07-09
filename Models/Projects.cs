namespace IssueTracker.Models
{
    public class Projects
    {
        public int Id { get; set; }

        public string ProjectName { get; set; } = default!;

        public string ProjectDescription { get; set; } = default!;

        public List<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();


    }
}
