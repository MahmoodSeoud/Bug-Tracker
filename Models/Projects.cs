namespace IssueTracker.Models
{
    public class Projects
    {
        public int Id { get; set; }

        public string ProjectName { get; set; }

        public string ProjectDescription { get; set; }

        public List<TeamMember> teamMembers { get; set; }
    }
}
