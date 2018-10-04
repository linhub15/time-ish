using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Timesheet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Issued { get; set; }
        public DateTime Submitted { get; set; }
        public DateTime Approved { get; set; }
        public string EmployeeName { get; set; }

        public PayPeriod PayPeriod { get; set; }
        public IEnumerable<Activity> Activities { get; set; }
    }

    public class Activity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }

        public Timesheet Timesheet { get; set; }
    }

    public class PayPeriod
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public IEnumerable<Timesheet> Timesheets { get; set; }
    }
}