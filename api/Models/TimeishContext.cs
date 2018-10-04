using System;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class TimeishContext : DbContext
    {
        public TimeishContext(DbContextOptions<TimeishContext> options)
            : base(options)
        { }

        public DbSet<Timesheet> Timesheets { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<PayPeriod> PayPeriods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PayPeriod>().HasData(
                new PayPeriod { Id = 1, Start = DateTime.Today, End = DateTime.Today },
                new PayPeriod { Id = 2, Start = DateTime.Today, End = DateTime.Today }
            );
            modelBuilder.Entity<Timesheet>().HasData(
                new Timesheet { Id = 1, Issued = DateTime.Now, EmployeeName = "Hubert Lin", PayPeriodId = 1},
                new Timesheet { Id = 2, Issued = DateTime.Now, EmployeeName = "John Smith", PayPeriodId = 1},
                new Timesheet { Id = 3, Issued = DateTime.Now, EmployeeName = "Lunette Clowne", PayPeriodId = 1},
                new Timesheet { Id = 4, Issued = DateTime.Now, EmployeeName = "Peter Parker", PayPeriodId = 2}
            );
        }
    }
}