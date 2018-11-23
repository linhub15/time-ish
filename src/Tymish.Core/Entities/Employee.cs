using System;
using System.Runtime.Serialization;

namespace Tymish.Core.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Decimal HourlyPay { get; set; }
        // Do not serialize to Front End
        [IgnoreDataMember] protected string HashedPassword { get; set; }
    }
}