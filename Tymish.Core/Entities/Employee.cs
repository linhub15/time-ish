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

        // Do not serialize; I want to remove the attribute here. Where can it go?
        [IgnoreDataMember] protected string HashedPassword { get; set; }
            // ! Must not expose HashedPassword
            // MD5 128-bit hash CHAR(32)
            // Could use SHA-256 hash CHAR(64)
            // Should add Salt
    }
}