using IssueTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tickets> Tickets => Set<Tickets>();

        public DbSet<Projects> Projects => Set<Projects>();

        public DbSet<TeamMember> TeamMember => Set<TeamMember>();
    }
}