using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        // Data seeding of Identity roles
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole 
                { 
                    Id = "25ff193c-aa72-4332-9dcd-d59bba25d191",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                },
                new IdentityRole
                {
                    Id = "5c9cba3f-1bb8-4ad4-905c-7a3fef85342d",
                    Name = "Supervisor",
                    NormalizedName = "SUPERVISOR"
                },
                new IdentityRole
                {
                    Id = "abb432a0-7023-4085-97e8-de3bd1de7aae",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                });

            var hasher = new PasswordHasher<ApplicationUser>();


            builder.Entity<ApplicationUser>()
                .HasData(
                new ApplicationUser
                {
                    Id = "9d9566a6-75ea-41dd-b379-5e83e0c2dd2a",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    UserName = "admin@localhost.com",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true,
                    FirstName = "Default",
                    LastName = "Admin",
                    DateOfBirth = new DateOnly(1990, 1, 1) 
                });

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "abb432a0-7023-4085-97e8-de3bd1de7aae",
                    UserId = "9d9566a6-75ea-41dd-b379-5e83e0c2dd2a"
                }
                );
        }

        // Leave Type is data type we want to store in the database.
        // LeaveTypes is the name of the table that will be created in the database.
        // EF Core will automatically create a table named "LeaveTypes" based on this DbSet.
        public DbSet<LeaveType> LeaveTypes { get; set; }
    }
}
