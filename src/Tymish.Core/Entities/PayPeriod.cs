using System;

namespace Tymish.Core.Entities
{
    public class PayPeriod : BaseEntity
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}