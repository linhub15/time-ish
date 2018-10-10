using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace api.Models 
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Decimal HourlyPay { get; set; }
        [IgnoreDataMember] protected string HashedPassword { get; set; }
            // ! Must not expose HashedPassword
            // MD5 128-bit hash CHAR(32)
            // Could use SHA-256 hash CHAR(64)
            // Should add Salt
    }
}