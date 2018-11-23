using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Tymish.Core.Entities;
using Tymish.Infrastructure.Configuration;

namespace Tymish.Infrastructure.DataAccess
{
    public class TimeishContext : IdentityDbContext
    {
        public TimeishContext(DbContextOptions<TimeishContext> options)
            : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<TimeSheet> TimeSheets { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<PayPeriod> PayPeriods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new TimeSheetConfiguration());
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FirstName = "Hubert", LastName = "Lin", Email = "hubert.lin@example.com", HourlyPay = 25.00M },
                new Employee { Id = 2, FirstName = "John", LastName = "Smith", Email = "John.Smith@example.com", HourlyPay = 25.00M },
                new Employee { Id = 3, FirstName = "Lunette", LastName = "Clowne", Email = "Luntette.Clowne@example.com", HourlyPay = 25.00M },
                new Employee { Id = 4, FirstName = "Peter", LastName = "Parker", Email = "Peter.Parker@example.com", HourlyPay = 25.00M }
            );
            modelBuilder.Entity<PayPeriod>().HasData(
                new PayPeriod { Id = 1, Start = DateTime.Today, End = DateTime.Today },
                new PayPeriod { Id = 2, Start = DateTime.Today, End = DateTime.Today }
            );
            modelBuilder.Entity<TimeSheet>().HasData(
                new TimeSheet { Id = 1, Issued = DateTime.Now, EmployeeId = 1, PayPeriodId = 1},
                new TimeSheet { Id = 2, Issued = DateTime.Now, EmployeeId = 2, PayPeriodId = 1},
                new TimeSheet { Id = 3, Issued = DateTime.Now, EmployeeId = 3, PayPeriodId = 1},
                new TimeSheet { Id = 4, Issued = DateTime.Now, EmployeeId = 4, PayPeriodId = 2}
            );
            modelBuilder.Entity<Activity>().HasData(
                new Activity { Id = 1, Date = DateTime.Today, Pay = 25, Description = "Teaching Dance", Hours = 1, TimeSheetId = 1 },
                new Activity { Id = 2, Date = DateTime.Today, Pay = 25, Description = "Teaching Kids", Hours = 1, TimeSheetId = 1 }
            );
        }
    }
}