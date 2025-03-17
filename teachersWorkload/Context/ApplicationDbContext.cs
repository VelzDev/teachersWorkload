using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using teachersWorkload.Concrete;

namespace teachersWorkload.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Workload> Workloads { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Group> Groups { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
