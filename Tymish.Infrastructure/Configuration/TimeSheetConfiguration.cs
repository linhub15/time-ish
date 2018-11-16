using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tymish.Core.Entities;

namespace Tymish.Infrastructure.Configuration
{
    public class TimeSheetConfiguration : IEntityTypeConfiguration<TimeSheet>
    {
        public void Configure(EntityTypeBuilder<TimeSheet> builder)
        {
            builder.Property(t => t.EmployeeId)
                .IsRequired();
        }
    }
}