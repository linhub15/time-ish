using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class TimeishDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*  warning To protect potentially sensitive information in your connection string, 
                you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 
                for guidance on storing connection strings.
             */
            optionsBuilder.UseMySQL("connection string");
        }
    }
}