using System;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class TimeishContext : DbContext
    {
        public TimeishContext(DbContextOptions<TimeishContext> options)
            : base(options)
        { }

        public DbSet<TimeSheet> TimeSheets { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<PayPeriod> PayPeriods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PayPeriod>().HasData(
                new PayPeriod { Id = 1, Start = DateTime.Today, End = DateTime.Today },
                new PayPeriod { Id = 2, Start = DateTime.Today, End = DateTime.Today }
            );
            modelBuilder.Entity<TimeSheet>().HasData(
                new TimeSheet { Id = 1, Issued = DateTime.Now, EmployeeName = "Hubert Lin", PayPeriodId = 1},
                new TimeSheet { Id = 2, Issued = DateTime.Now, EmployeeName = "John Smith", PayPeriodId = 1},
                new TimeSheet { Id = 3, Issued = DateTime.Now, EmployeeName = "Lunette Clowne", PayPeriodId = 1},
                new TimeSheet { Id = 4, Issued = DateTime.Now, EmployeeName = "Peter Parker", PayPeriodId = 2}
            );
            modelBuilder.Entity<Activity>().HasData(
                new Activity { Id = 1, Date = DateTime.Today, Amount = 25, Description = "Teaching Dance", Hours = 1, TimeSheetId = 1 },
                new Activity { Id = 2, Date = DateTime.Today, Amount = 25, Description = "Teaching Kids", Hours = 1, TimeSheetId = 1 }
            );
        }
    }
}