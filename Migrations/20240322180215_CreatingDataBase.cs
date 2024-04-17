using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestLiveCode.Migrations
{
    /// <inheritdoc />
    public partial class CreatingDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    IS_TOP_500 = table.Column<bool>(type: "BIT", nullable: false),
                    DATE_ADDED = table.Column<DateTime>(type: "DATETIME", maxLength: 500, nullable: false),
                    TASKS_TO_BE_DONE = table.Column<int>(type: "INT", nullable: false),
                    TASKS_DONE = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CLIENT_ID", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DONE = table.Column<bool>(type: "BIT", nullable: false),
                    CLIENT_ID = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TICKET_ID", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Ticket_Client_CLIENT_ID",
                        column: x => x.CLIENT_ID,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_CLIENT_ID",
                table: "Ticket",
                column: "CLIENT_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
