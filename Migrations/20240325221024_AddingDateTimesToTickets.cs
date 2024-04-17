using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestLiveCode.Migrations
{
    /// <inheritdoc />
    public partial class AddingDateTimesToTickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DATE_ADDED",
                table: "Ticket",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DATE_ADDED",
                table: "Ticket");
        }
    }
}
