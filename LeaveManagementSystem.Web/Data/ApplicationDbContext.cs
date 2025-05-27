using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Leave Type is data type we want to store in the database.
        // LeaveTypes is the name of the table that will be created in the database.
        // EF Core will automatically create a table named "LeaveTypes" based on this DbSet.
        public DbSet<LeaveType> LeaveTypes { get; set; }
    }
}
