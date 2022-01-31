using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConnectaSummer.Data.Migrations
{
    public partial class Connecta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateHolderAccount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeleteHolderAccount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdateHolderAccount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreateCustomer",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "DeleteCustomer",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "UpdateCustomer",
                table: "Accounts");

            migrationBuilder.AlterColumn<int>(
                name: "Nature",
                table: "Extracts",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "Extracts",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "AccountHolders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Extracts_AccountId",
                table: "Extracts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountHolders_AccountId",
                table: "AccountHolders",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountHolders_Accounts_AccountId",
                table: "AccountHolders",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Extracts_Accounts_AccountId",
                table: "Extracts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountHolders_Accounts_AccountId",
                table: "AccountHolders");

            migrationBuilder.DropForeignKey(
                name: "FK_Extracts_Accounts_AccountId",
                table: "Extracts");

            migrationBuilder.DropIndex(
                name: "IX_Extracts_AccountId",
                table: "Extracts");

            migrationBuilder.DropIndex(
                name: "IX_AccountHolders_AccountId",
                table: "AccountHolders");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "AccountHolders");

            migrationBuilder.AddColumn<bool>(
                name: "CreateHolderAccount",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DeleteHolderAccount",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UpdateHolderAccount",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<long>(
                name: "Nature",
                table: "Extracts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "AccountId",
                table: "Extracts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<bool>(
                name: "CreateCustomer",
                table: "Accounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DeleteCustomer",
                table: "Accounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UpdateCustomer",
                table: "Accounts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
