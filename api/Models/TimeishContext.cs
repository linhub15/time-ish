using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class TimeishContext : DbContext
    {
        public TimeishContext(DbContextOptions<TimeishContext> options)
            : base(options)
        {}

        public DbSet<Timesheet> Timesheets { get; set; }
        public DbSet<Activity> Activities { get; set; }
    }
}