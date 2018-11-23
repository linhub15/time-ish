using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tymish.Core.Entities;

namespace Tymish.Infrastructure.DataAccess.Configuration
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.Property(a => a.Date)
                .IsRequired();

            builder.Property(a => a.Hours)
                .IsRequired();

            builder.Property(a => a.Pay)
                .IsRequired();

            builder.Property(a => a.TimeSheetId)
                .IsRequired();
        }
    }
}