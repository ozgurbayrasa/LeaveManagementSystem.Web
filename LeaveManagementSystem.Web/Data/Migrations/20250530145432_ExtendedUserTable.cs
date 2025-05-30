﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9d9566a6-75ea-41dd-b379-5e83e0c2dd2a",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af97f4be-24a5-430f-ab23-9d09f8eb6464", new DateOnly(1990, 1, 1), "Default", "Admin", "AQAAAAIAAYagAAAAEA3mv/VZYehM6Hwarq419cNc7nx5cpA99diLyHiIqFmEZwMjOAAoNsgDJm2HRVel5Q==", "fa4c521f-cbe5-47d2-a96d-fce1542ebd50" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9d9566a6-75ea-41dd-b379-5e83e0c2dd2a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79917e35-2c0b-446f-9645-4ccdec006762", "AQAAAAIAAYagAAAAEJtdU+iPVdOpsByu/INifRRL3Y4uVLP2c/aL8aDD20CmPVngfQO6bi82e6+S4IZnAw==", "b1a88342-04a0-4236-87bb-e259bf4729a4" });
        }
    }
}
