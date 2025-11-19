using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Momentum.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_refresh_tokens_Users_user_id",
                schema: "users",
                table: "refresh_tokens");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                schema: "users",
                table: "RoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_Users_UserId",
                schema: "users",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_Users_UserId",
                schema: "users",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                schema: "users",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                schema: "users",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_Users_UserId",
                schema: "users",
                table: "UserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_workouts_Users_user_id",
                schema: "exercises",
                table: "workouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                schema: "users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                schema: "users",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTokens",
                schema: "users",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                schema: "users",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLogins",
                schema: "users",
                table: "UserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserClaims",
                schema: "users",
                table: "UserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleClaims",
                schema: "users",
                table: "RoleClaims");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "users",
                newName: "users",
                newSchema: "users");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "users",
                newName: "roles",
                newSchema: "users");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                schema: "users",
                newName: "user_tokens",
                newSchema: "users");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                schema: "users",
                newName: "user_roles",
                newSchema: "users");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                schema: "users",
                newName: "user_logins",
                newSchema: "users");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                schema: "users",
                newName: "user_claims",
                newSchema: "users");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                schema: "users",
                newName: "role_claims",
                newSchema: "users");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserName",
                schema: "users",
                table: "users",
                newName: "IX_users_UserName");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_RoleId",
                schema: "users",
                table: "user_roles",
                newName: "IX_user_roles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLogins_UserId",
                schema: "users",
                table: "user_logins",
                newName: "IX_user_logins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserClaims_UserId",
                schema: "users",
                table: "user_claims",
                newName: "IX_user_claims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "users",
                table: "role_claims",
                newName: "IX_role_claims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                schema: "users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                schema: "users",
                table: "roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_tokens",
                schema: "users",
                table: "user_tokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_roles",
                schema: "users",
                table: "user_roles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_logins",
                schema: "users",
                table: "user_logins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_claims",
                schema: "users",
                table: "user_claims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_role_claims",
                schema: "users",
                table: "role_claims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_refresh_tokens_users_user_id",
                schema: "users",
                table: "refresh_tokens",
                column: "user_id",
                principalSchema: "users",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_role_claims_roles_RoleId",
                schema: "users",
                table: "role_claims",
                column: "RoleId",
                principalSchema: "users",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_claims_users_UserId",
                schema: "users",
                table: "user_claims",
                column: "UserId",
                principalSchema: "users",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_logins_users_UserId",
                schema: "users",
                table: "user_logins",
                column: "UserId",
                principalSchema: "users",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_roles_roles_RoleId",
                schema: "users",
                table: "user_roles",
                column: "RoleId",
                principalSchema: "users",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_roles_users_UserId",
                schema: "users",
                table: "user_roles",
                column: "UserId",
                principalSchema: "users",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_tokens_users_UserId",
                schema: "users",
                table: "user_tokens",
                column: "UserId",
                principalSchema: "users",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_workouts_users_user_id",
                schema: "exercises",
                table: "workouts",
                column: "user_id",
                principalSchema: "users",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_refresh_tokens_users_user_id",
                schema: "users",
                table: "refresh_tokens");

            migrationBuilder.DropForeignKey(
                name: "FK_role_claims_roles_RoleId",
                schema: "users",
                table: "role_claims");

            migrationBuilder.DropForeignKey(
                name: "FK_user_claims_users_UserId",
                schema: "users",
                table: "user_claims");

            migrationBuilder.DropForeignKey(
                name: "FK_user_logins_users_UserId",
                schema: "users",
                table: "user_logins");

            migrationBuilder.DropForeignKey(
                name: "FK_user_roles_roles_RoleId",
                schema: "users",
                table: "user_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_user_roles_users_UserId",
                schema: "users",
                table: "user_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_user_tokens_users_UserId",
                schema: "users",
                table: "user_tokens");

            migrationBuilder.DropForeignKey(
                name: "FK_workouts_users_user_id",
                schema: "exercises",
                table: "workouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                schema: "users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                schema: "users",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_tokens",
                schema: "users",
                table: "user_tokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_roles",
                schema: "users",
                table: "user_roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_logins",
                schema: "users",
                table: "user_logins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_claims",
                schema: "users",
                table: "user_claims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_role_claims",
                schema: "users",
                table: "role_claims");

            migrationBuilder.RenameTable(
                name: "users",
                schema: "users",
                newName: "Users",
                newSchema: "users");

            migrationBuilder.RenameTable(
                name: "roles",
                schema: "users",
                newName: "Roles",
                newSchema: "users");

            migrationBuilder.RenameTable(
                name: "user_tokens",
                schema: "users",
                newName: "UserTokens",
                newSchema: "users");

            migrationBuilder.RenameTable(
                name: "user_roles",
                schema: "users",
                newName: "UserRoles",
                newSchema: "users");

            migrationBuilder.RenameTable(
                name: "user_logins",
                schema: "users",
                newName: "UserLogins",
                newSchema: "users");

            migrationBuilder.RenameTable(
                name: "user_claims",
                schema: "users",
                newName: "UserClaims",
                newSchema: "users");

            migrationBuilder.RenameTable(
                name: "role_claims",
                schema: "users",
                newName: "RoleClaims",
                newSchema: "users");

            migrationBuilder.RenameIndex(
                name: "IX_users_UserName",
                schema: "users",
                table: "Users",
                newName: "IX_Users_UserName");

            migrationBuilder.RenameIndex(
                name: "IX_user_roles_RoleId",
                schema: "users",
                table: "UserRoles",
                newName: "IX_UserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_user_logins_UserId",
                schema: "users",
                table: "UserLogins",
                newName: "IX_UserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_user_claims_UserId",
                schema: "users",
                table: "UserClaims",
                newName: "IX_UserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_role_claims_RoleId",
                schema: "users",
                table: "RoleClaims",
                newName: "IX_RoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                schema: "users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                schema: "users",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTokens",
                schema: "users",
                table: "UserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                schema: "users",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLogins",
                schema: "users",
                table: "UserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserClaims",
                schema: "users",
                table: "UserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleClaims",
                schema: "users",
                table: "RoleClaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_refresh_tokens_Users_user_id",
                schema: "users",
                table: "refresh_tokens",
                column: "user_id",
                principalSchema: "users",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                schema: "users",
                table: "RoleClaims",
                column: "RoleId",
                principalSchema: "users",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_Users_UserId",
                schema: "users",
                table: "UserClaims",
                column: "UserId",
                principalSchema: "users",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_Users_UserId",
                schema: "users",
                table: "UserLogins",
                column: "UserId",
                principalSchema: "users",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                schema: "users",
                table: "UserRoles",
                column: "RoleId",
                principalSchema: "users",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                schema: "users",
                table: "UserRoles",
                column: "UserId",
                principalSchema: "users",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_Users_UserId",
                schema: "users",
                table: "UserTokens",
                column: "UserId",
                principalSchema: "users",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_workouts_Users_user_id",
                schema: "exercises",
                table: "workouts",
                column: "user_id",
                principalSchema: "users",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
