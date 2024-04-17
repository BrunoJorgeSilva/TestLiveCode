using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestLiveCode.Migrations
{
    /// <inheritdoc />
    public partial class CreatingDataBase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ACTIVE",
                table: "Ticket",
                type: "BIT",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ACTIVE",
                table: "Client",
                type: "BIT",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ACTIVE",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "ACTIVE",
                table: "Client");
        }
    }
}
