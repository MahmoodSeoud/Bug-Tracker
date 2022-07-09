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

        public DbSet<Tickets> Tickets => Set<Tickets>();

        public DbSet<Projects> Projects => Set<Projects>();

        public DbSet<TeamMember> TeamMember => Set<TeamMember>();
    }
}
