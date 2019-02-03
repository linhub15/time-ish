using System;

namespace Tymish.Core.Entities
{
    public class Activity : BaseEntity
    {
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public string Description { get; set; }
        public decimal Pay { get; set; }
        public int TimeSheetId { get; set; }
    }
}