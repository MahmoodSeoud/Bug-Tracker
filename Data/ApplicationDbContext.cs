using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IssueTracker.Models;

namespace IssueTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<IssueTracker.Models.Tickets>? Tickets { get; set; }

        public DbSet<IssueTracker.Models.Projects>? Projects { get; set; }

        public DbSet<IssueTracker.Models.TeamMember>? TeamMember { get; set; }
    }
}
