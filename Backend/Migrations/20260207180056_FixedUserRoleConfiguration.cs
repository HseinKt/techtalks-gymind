using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYMIND.API.Migrations
{
    /// <inheritdoc />
    public partial class FixedUserRoleConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userrole_roles_RoleID",
                table: "userrole");

            migrationBuilder.DropForeignKey(
                name: "FK_userrole_users_UserID",
                table: "userrole");

            migrationBuilder.RenameColumn(
                name: "UserRoleID",
                table: "userrole",
                newName: "userroleid");

            migrationBuilder.RenameColumn(
                name: "AssignedAt",
                table: "userrole",
                newName: "assignedat");

            migrationBuilder.RenameColumn(
                name: "RoleID",
                table: "userrole",
                newName: "roleid");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "userrole",
                newName: "userid");

            migrationBuilder.RenameIndex(
                name: "IX_userrole_RoleID",
                table: "userrole",
                newName: "IX_userrole_roleid");

            migrationBuilder.AddForeignKey(
                name: "FK_userrole_roles_roleid",
                table: "userrole",
                column: "roleid",
                principalTable: "roles",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userrole_users_userid",
                table: "userrole",
                column: "userid",
                principalTable: "users",
                principalColumn: "userid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userrole_roles_roleid",
                table: "userrole");

            migrationBuilder.DropForeignKey(
                name: "FK_userrole_users_userid",
                table: "userrole");

            migrationBuilder.RenameColumn(
                name: "userroleid",
                table: "userrole",
                newName: "UserRoleID");

            migrationBuilder.RenameColumn(
                name: "assignedat",
                table: "userrole",
                newName: "AssignedAt");

            migrationBuilder.RenameColumn(
                name: "roleid",
                table: "userrole",
                newName: "RoleID");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "userrole",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_userrole_roleid",
                table: "userrole",
                newName: "IX_userrole_RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_userrole_roles_RoleID",
                table: "userrole",
                column: "RoleID",
                principalTable: "roles",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userrole_users_UserID",
                table: "userrole",
                column: "UserID",
                principalTable: "users",
                principalColumn: "userid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
