using System;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Design;
using FluentValidation;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Core.Entities 
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Decimal HourlyPay { get; set; }

        // Do not serialize
        [IgnoreDataMember] protected string HashedPassword { get; set; }
            // ! Must not expose HashedPassword
            // MD5 128-bit hash CHAR(32)
            // Could use SHA-256 hash CHAR(64)
            // Should add Salt
    }

    public class EmployeeConfiguration: IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.FirstName).IsRequired()
                .HasMaxLength(25);

            builder.Property(e => e.LastName).IsRequired()
                .HasMaxLength(25);

            builder.Property(e => e.Email).IsRequired();

            builder.Property(e => e.HourlyPay).IsRequired();
        }
    }

    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.FirstName).NotEmpty().Length(0,25);
            RuleFor(e => e.LastName).NotEmpty().Length(0,25);
            RuleFor(e => e.Email).NotEmpty().EmailAddress();
            RuleFor(e => e.HourlyPay).NotEmpty().InclusiveBetween(0,100);
        }
    }
}