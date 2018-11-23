using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Tymish.Core.Entities;

namespace Tymish.Infrastructure.DataAccess.Configuration
{
    public class EmployeeConfiguration: IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(e => e.Email)
                .IsRequired();

            builder.Property(e => e.HourlyPay)
                .IsRequired();
        }
    }
}