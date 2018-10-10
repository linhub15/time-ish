using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class TimeSheet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Issued { get; set; }
        public DateTime? Submitted { get; set; }
        public DateTime? Approved { get; set; }
        public int EmployeeId { get; set; }
        public int? PayPeriodId { get; set; }

        public virtual Employee Employee{ get; set; }
        public virtual PayPeriod PayPeriod { get; set; }
        public virtual IEnumerable<Activity> Activities { get; set;}
    }

    public class Activity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public string Description { get; set; }
        public decimal Pay { get; set; }
        public int TimeSheetId { get; set; }
    }

    public class PayPeriod
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}