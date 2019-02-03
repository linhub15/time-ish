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
}