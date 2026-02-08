using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYMIND.API.Migrations
{
    /// <inheritdoc />
    public partial class FixUserRoleGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_roles_RoleID",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_RoleID",
                table: "users");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "users");

            migrationBuilder.DropColumn(
                name: "assignedat",
                table: "userrole");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "roles",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "roles",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "RoleID",
                table: "roles",
                newName: "roleid");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "roles",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "roles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "roles",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "roleid",
                table: "roles",
                newName: "RoleID");

            migrationBuilder.AddColumn<int>(
                name: "RoleID",
                table: "users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "assignedat",
                table: "userrole",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "roles",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_users_RoleID",
                table: "users",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_users_roles_RoleID",
                table: "users",
                column: "RoleID",
                principalTable: "roles",
                principalColumn: "RoleID");
        }
    }
}
