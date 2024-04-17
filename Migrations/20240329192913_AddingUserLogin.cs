using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestLiveCode.Migrations
{
    /// <inheritdoc />
    public partial class AddingUserLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USER = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    PASSWORD = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    ACTIVE = table.Column<bool>(type: "BIT", nullable: false),
                    DATE_ADDED = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("USER_ID", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLogin");
        }
    }
}
