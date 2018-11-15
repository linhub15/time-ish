using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tymish.Core.Entities
{
    public class TimeSheet : BaseEntity
    {
        public DateTime Issued { get; set; }
        public DateTime? Submitted { get; set; }
        public DateTime? Approved { get; set; }
        [Required] public int EmployeeId { get; set; }
        public int? PayPeriodId { get; set; }

        public virtual Employee Employee{ get; set; }
        public virtual PayPeriod PayPeriod { get; set; }
        public virtual IEnumerable<Activity> Activities { get; set;}
    }

    public class Activity : BaseEntity
    {
        [Required] public DateTime Date { get; set; }
        [Required] [Range(0,24)] public int Hours { get; set; }
        public string Description { get; set; }
        [Required] public decimal Pay { get; set; }
        [Required] public int TimeSheetId { get; set; }
    }

    public class PayPeriod : BaseEntity
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}