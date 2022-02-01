using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConnectaSummer.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Agency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AccountHolders",
                columns: table => new
                {
                    AccountHolderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    TaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountHolders", x => x.AccountHolderId);
                    table.ForeignKey(
                        name: "FK_AccountHolders_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Extracts",
                columns: table => new
                {
                    ExtractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nature = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extracts", x => x.ExtractId);
                    table.ForeignKey(
                        name: "FK_Extracts_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountHolders_AccountId",
                table: "AccountHolders",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Extracts_AccountId",
                table: "Extracts",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountHolders");

            migrationBuilder.DropTable(
                name: "Extracts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
