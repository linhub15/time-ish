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

        public IEnumerable<Activity> Activities { get; set; }
    }

    public class Activity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public Timesheet Timesheet { get; set; }
    }
}