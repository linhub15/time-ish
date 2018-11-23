using System;
using System.Collections.Generic;

namespace Tymish.Core.Entities
{
    public class TimeSheet : BaseEntity
    {
        public DateTime Issued { get; set; }
        public DateTime? Submitted { get; set; }
        public DateTime? Approved { get; set; }
        public int EmployeeId { get; set; }
        public int? PayPeriodId { get; set; }

        public virtual Employee Employee{ get; set; }
        public virtual PayPeriod PayPeriod { get; set; }
        public virtual IEnumerable<Activity> Activities { get; set;}
    }

    public class Activity : BaseEntity
    {
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public string Description { get; set; }
        public decimal Pay { get; set; }
        public int TimeSheetId { get; set; }
    }

    public class PayPeriod : BaseEntity
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}