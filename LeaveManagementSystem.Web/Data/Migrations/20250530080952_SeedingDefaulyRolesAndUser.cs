using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaulyRolesAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25ff193c-aa72-4332-9dcd-d59bba25d191", null, "Employee", "EMPLOYEE" },
                    { "5c9cba3f-1bb8-4ad4-905c-7a3fef85342d", null, "Supervisor", "SUPERVISOR" },
                    { "abb432a0-7023-4085-97e8-de3bd1de7aae", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9d9566a6-75ea-41dd-b379-5e83e0c2dd2a", 0, "79917e35-2c0b-446f-9645-4ccdec006762", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEJtdU+iPVdOpsByu/INifRRL3Y4uVLP2c/aL8aDD20CmPVngfQO6bi82e6+S4IZnAw==", null, false, "b1a88342-04a0-4236-87bb-e259bf4729a4", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "abb432a0-7023-4085-97e8-de3bd1de7aae", "9d9566a6-75ea-41dd-b379-5e83e0c2dd2a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25ff193c-aa72-4332-9dcd-d59bba25d191");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c9cba3f-1bb8-4ad4-905c-7a3fef85342d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "abb432a0-7023-4085-97e8-de3bd1de7aae", "9d9566a6-75ea-41dd-b379-5e83e0c2dd2a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abb432a0-7023-4085-97e8-de3bd1de7aae");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9d9566a6-75ea-41dd-b379-5e83e0c2dd2a");
        }
    }
}
