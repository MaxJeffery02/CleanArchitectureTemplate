using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Momentum.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SnakeCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_workout_exercises_exercises_exercise_id",
                schema: "exercises",
                table: "workout_exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_workout_exercises_workouts_workout_id",
                schema: "exercises",
                table: "workout_exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_workouts_users_user_id",
                schema: "exercises",
                table: "workouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_workouts",
                schema: "exercises",
                table: "workouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_workout_exercises",
                schema: "exercises",
                table: "workout_exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                schema: "users",
                table: "users");

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
                name: "PK_roles",
                schema: "users",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_role_claims",
                schema: "users",
                table: "role_claims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_refresh_tokens",
                schema: "users",
                table: "refresh_tokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_exercises",
                schema: "exercises",
                table: "exercises");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "exercises",
                table: "workouts",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "exercises",
                table: "workouts",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_workouts_user_id",
                schema: "exercises",
                table: "workouts",
                newName: "ix_workouts_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_workout_exercises_exercise_id",
                schema: "exercises",
                table: "workout_exercises",
                newName: "ix_workout_exercises_exercise_id");

            migrationBuilder.RenameColumn(
                name: "Email",
                schema: "users",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "users",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserName",
                schema: "users",
                table: "users",
                newName: "user_name");

            migrationBuilder.RenameColumn(
                name: "TwoFactorEnabled",
                schema: "users",
                table: "users",
                newName: "two_factor_enabled");

            migrationBuilder.RenameColumn(
                name: "SecurityStamp",
                schema: "users",
                table: "users",
                newName: "security_stamp");

            migrationBuilder.RenameColumn(
                name: "PhoneNumberConfirmed",
                schema: "users",
                table: "users",
                newName: "phone_number_confirmed");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                schema: "users",
                table: "users",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                schema: "users",
                table: "users",
                newName: "password_hash");

            migrationBuilder.RenameColumn(
                name: "NormalizedUserName",
                schema: "users",
                table: "users",
                newName: "normalized_user_name");

            migrationBuilder.RenameColumn(
                name: "NormalizedEmail",
                schema: "users",
                table: "users",
                newName: "normalized_email");

            migrationBuilder.RenameColumn(
                name: "LockoutEnd",
                schema: "users",
                table: "users",
                newName: "lockout_end");

            migrationBuilder.RenameColumn(
                name: "LockoutEnabled",
                schema: "users",
                table: "users",
                newName: "lockout_enabled");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "users",
                table: "users",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "users",
                table: "users",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "EmailConfirmed",
                schema: "users",
                table: "users",
                newName: "email_confirmed");

            migrationBuilder.RenameColumn(
                name: "ConcurrencyStamp",
                schema: "users",
                table: "users",
                newName: "concurrency_stamp");

            migrationBuilder.RenameColumn(
                name: "AccessFailedCount",
                schema: "users",
                table: "users",
                newName: "access_failed_count");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                schema: "users",
                table: "users",
                newName: "date_of_birth_utc");

            migrationBuilder.RenameIndex(
                name: "IX_users_UserName",
                schema: "users",
                table: "users",
                newName: "ix_users_user_name");

            migrationBuilder.RenameColumn(
                name: "Value",
                schema: "users",
                table: "user_tokens",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "users",
                table: "user_tokens",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "LoginProvider",
                schema: "users",
                table: "user_tokens",
                newName: "login_provider");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "users",
                table: "user_tokens",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                schema: "users",
                table: "user_roles",
                newName: "role_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "users",
                table: "user_roles",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_user_roles_RoleId",
                schema: "users",
                table: "user_roles",
                newName: "ix_user_roles_role_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "users",
                table: "user_logins",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "ProviderDisplayName",
                schema: "users",
                table: "user_logins",
                newName: "provider_display_name");

            migrationBuilder.RenameColumn(
                name: "ProviderKey",
                schema: "users",
                table: "user_logins",
                newName: "provider_key");

            migrationBuilder.RenameColumn(
                name: "LoginProvider",
                schema: "users",
                table: "user_logins",
                newName: "login_provider");

            migrationBuilder.RenameIndex(
                name: "IX_user_logins_UserId",
                schema: "users",
                table: "user_logins",
                newName: "ix_user_logins_user_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "users",
                table: "user_claims",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "users",
                table: "user_claims",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "ClaimValue",
                schema: "users",
                table: "user_claims",
                newName: "claim_value");

            migrationBuilder.RenameColumn(
                name: "ClaimType",
                schema: "users",
                table: "user_claims",
                newName: "claim_type");

            migrationBuilder.RenameIndex(
                name: "IX_user_claims_UserId",
                schema: "users",
                table: "user_claims",
                newName: "ix_user_claims_user_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "users",
                table: "roles",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "users",
                table: "roles",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "NormalizedName",
                schema: "users",
                table: "roles",
                newName: "normalized_name");

            migrationBuilder.RenameColumn(
                name: "ConcurrencyStamp",
                schema: "users",
                table: "roles",
                newName: "concurrency_stamp");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "users",
                table: "role_claims",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                schema: "users",
                table: "role_claims",
                newName: "role_id");

            migrationBuilder.RenameColumn(
                name: "ClaimValue",
                schema: "users",
                table: "role_claims",
                newName: "claim_value");

            migrationBuilder.RenameColumn(
                name: "ClaimType",
                schema: "users",
                table: "role_claims",
                newName: "claim_type");

            migrationBuilder.RenameIndex(
                name: "IX_role_claims_RoleId",
                schema: "users",
                table: "role_claims",
                newName: "ix_role_claims_role_id");

            migrationBuilder.RenameColumn(
                name: "Value",
                schema: "users",
                table: "refresh_tokens",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "users",
                table: "refresh_tokens",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RevokedAt",
                schema: "users",
                table: "refresh_tokens",
                newName: "revoked_at");

            migrationBuilder.RenameColumn(
                name: "ExpiresAt",
                schema: "users",
                table: "refresh_tokens",
                newName: "expires_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "users",
                table: "refresh_tokens",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_refresh_tokens_user_id",
                schema: "users",
                table: "refresh_tokens",
                newName: "ix_refresh_tokens_user_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "exercises",
                table: "exercises",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "exercises",
                table: "exercises",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "exercises",
                table: "exercises",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_workouts",
                schema: "exercises",
                table: "workouts",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_workout_exercises",
                schema: "exercises",
                table: "workout_exercises",
                columns: new[] { "workout_id", "exercise_id" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_users",
                schema: "users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_tokens",
                schema: "users",
                table: "user_tokens",
                columns: new[] { "user_id", "login_provider", "name" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_roles",
                schema: "users",
                table: "user_roles",
                columns: new[] { "user_id", "role_id" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_logins",
                schema: "users",
                table: "user_logins",
                columns: new[] { "login_provider", "provider_key" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_claims",
                schema: "users",
                table: "user_claims",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_roles",
                schema: "users",
                table: "roles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_role_claims",
                schema: "users",
                table: "role_claims",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_refresh_tokens",
                schema: "users",
                table: "refresh_tokens",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_exercises",
                schema: "exercises",
                table: "exercises",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_refresh_tokens_asp_net_users_user_id",
                schema: "users",
                table: "refresh_tokens",
                column: "user_id",
                principalSchema: "users",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_role_claims_asp_net_roles_role_id",
                schema: "users",
                table: "role_claims",
                column: "role_id",
                principalSchema: "users",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_claims_asp_net_users_user_id",
                schema: "users",
                table: "user_claims",
                column: "user_id",
                principalSchema: "users",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_logins_users_user_id",
                schema: "users",
                table: "user_logins",
                column: "user_id",
                principalSchema: "users",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_roles_roles_role_id",
                schema: "users",
                table: "user_roles",
                column: "role_id",
                principalSchema: "users",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_roles_users_user_id",
                schema: "users",
                table: "user_roles",
                column: "user_id",
                principalSchema: "users",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_tokens_users_user_id",
                schema: "users",
                table: "user_tokens",
                column: "user_id",
                principalSchema: "users",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_workout_exercises_exercises_exercise_id",
                schema: "exercises",
                table: "workout_exercises",
                column: "exercise_id",
                principalSchema: "exercises",
                principalTable: "exercises",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_workout_exercises_workouts_workout_id",
                schema: "exercises",
                table: "workout_exercises",
                column: "workout_id",
                principalSchema: "exercises",
                principalTable: "workouts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_workouts_asp_net_users_user_id",
                schema: "exercises",
                table: "workouts",
                column: "user_id",
                principalSchema: "users",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_refresh_tokens_asp_net_users_user_id",
                schema: "users",
                table: "refresh_tokens");

            migrationBuilder.DropForeignKey(
                name: "fk_role_claims_asp_net_roles_role_id",
                schema: "users",
                table: "role_claims");

            migrationBuilder.DropForeignKey(
                name: "fk_user_claims_asp_net_users_user_id",
                schema: "users",
                table: "user_claims");

            migrationBuilder.DropForeignKey(
                name: "fk_user_logins_users_user_id",
                schema: "users",
                table: "user_logins");

            migrationBuilder.DropForeignKey(
                name: "fk_user_roles_roles_role_id",
                schema: "users",
                table: "user_roles");

            migrationBuilder.DropForeignKey(
                name: "fk_user_roles_users_user_id",
                schema: "users",
                table: "user_roles");

            migrationBuilder.DropForeignKey(
                name: "fk_user_tokens_users_user_id",
                schema: "users",
                table: "user_tokens");

            migrationBuilder.DropForeignKey(
                name: "fk_workout_exercises_exercises_exercise_id",
                schema: "exercises",
                table: "workout_exercises");

            migrationBuilder.DropForeignKey(
                name: "fk_workout_exercises_workouts_workout_id",
                schema: "exercises",
                table: "workout_exercises");

            migrationBuilder.DropForeignKey(
                name: "fk_workouts_asp_net_users_user_id",
                schema: "exercises",
                table: "workouts");

            migrationBuilder.DropPrimaryKey(
                name: "pk_workouts",
                schema: "exercises",
                table: "workouts");

            migrationBuilder.DropPrimaryKey(
                name: "pk_workout_exercises",
                schema: "exercises",
                table: "workout_exercises");

            migrationBuilder.DropPrimaryKey(
                name: "pk_users",
                schema: "users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_tokens",
                schema: "users",
                table: "user_tokens");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_roles",
                schema: "users",
                table: "user_roles");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_logins",
                schema: "users",
                table: "user_logins");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_claims",
                schema: "users",
                table: "user_claims");

            migrationBuilder.DropPrimaryKey(
                name: "pk_roles",
                schema: "users",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "pk_role_claims",
                schema: "users",
                table: "role_claims");

            migrationBuilder.DropPrimaryKey(
                name: "pk_refresh_tokens",
                schema: "users",
                table: "refresh_tokens");

            migrationBuilder.DropPrimaryKey(
                name: "pk_exercises",
                schema: "exercises",
                table: "exercises");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "exercises",
                table: "workouts",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "exercises",
                table: "workouts",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "ix_workouts_user_id",
                schema: "exercises",
                table: "workouts",
                newName: "IX_workouts_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_workout_exercises_exercise_id",
                schema: "exercises",
                table: "workout_exercises",
                newName: "IX_workout_exercises_exercise_id");

            migrationBuilder.RenameColumn(
                name: "email",
                schema: "users",
                table: "users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "users",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_name",
                schema: "users",
                table: "users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "two_factor_enabled",
                schema: "users",
                table: "users",
                newName: "TwoFactorEnabled");

            migrationBuilder.RenameColumn(
                name: "security_stamp",
                schema: "users",
                table: "users",
                newName: "SecurityStamp");

            migrationBuilder.RenameColumn(
                name: "phone_number_confirmed",
                schema: "users",
                table: "users",
                newName: "PhoneNumberConfirmed");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                schema: "users",
                table: "users",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "password_hash",
                schema: "users",
                table: "users",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "normalized_user_name",
                schema: "users",
                table: "users",
                newName: "NormalizedUserName");

            migrationBuilder.RenameColumn(
                name: "normalized_email",
                schema: "users",
                table: "users",
                newName: "NormalizedEmail");

            migrationBuilder.RenameColumn(
                name: "lockout_end",
                schema: "users",
                table: "users",
                newName: "LockoutEnd");

            migrationBuilder.RenameColumn(
                name: "lockout_enabled",
                schema: "users",
                table: "users",
                newName: "LockoutEnabled");

            migrationBuilder.RenameColumn(
                name: "last_name",
                schema: "users",
                table: "users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                schema: "users",
                table: "users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "email_confirmed",
                schema: "users",
                table: "users",
                newName: "EmailConfirmed");

            migrationBuilder.RenameColumn(
                name: "concurrency_stamp",
                schema: "users",
                table: "users",
                newName: "ConcurrencyStamp");

            migrationBuilder.RenameColumn(
                name: "access_failed_count",
                schema: "users",
                table: "users",
                newName: "AccessFailedCount");

            migrationBuilder.RenameColumn(
                name: "date_of_birth_utc",
                schema: "users",
                table: "users",
                newName: "DateOfBirth");

            migrationBuilder.RenameIndex(
                name: "ix_users_user_name",
                schema: "users",
                table: "users",
                newName: "IX_users_UserName");

            migrationBuilder.RenameColumn(
                name: "value",
                schema: "users",
                table: "user_tokens",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "users",
                table: "user_tokens",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "login_provider",
                schema: "users",
                table: "user_tokens",
                newName: "LoginProvider");

            migrationBuilder.RenameColumn(
                name: "user_id",
                schema: "users",
                table: "user_tokens",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "role_id",
                schema: "users",
                table: "user_roles",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                schema: "users",
                table: "user_roles",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "ix_user_roles_role_id",
                schema: "users",
                table: "user_roles",
                newName: "IX_user_roles_RoleId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                schema: "users",
                table: "user_logins",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "provider_display_name",
                schema: "users",
                table: "user_logins",
                newName: "ProviderDisplayName");

            migrationBuilder.RenameColumn(
                name: "provider_key",
                schema: "users",
                table: "user_logins",
                newName: "ProviderKey");

            migrationBuilder.RenameColumn(
                name: "login_provider",
                schema: "users",
                table: "user_logins",
                newName: "LoginProvider");

            migrationBuilder.RenameIndex(
                name: "ix_user_logins_user_id",
                schema: "users",
                table: "user_logins",
                newName: "IX_user_logins_UserId");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "users",
                table: "user_claims",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                schema: "users",
                table: "user_claims",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "claim_value",
                schema: "users",
                table: "user_claims",
                newName: "ClaimValue");

            migrationBuilder.RenameColumn(
                name: "claim_type",
                schema: "users",
                table: "user_claims",
                newName: "ClaimType");

            migrationBuilder.RenameIndex(
                name: "ix_user_claims_user_id",
                schema: "users",
                table: "user_claims",
                newName: "IX_user_claims_UserId");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "users",
                table: "roles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "users",
                table: "roles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "normalized_name",
                schema: "users",
                table: "roles",
                newName: "NormalizedName");

            migrationBuilder.RenameColumn(
                name: "concurrency_stamp",
                schema: "users",
                table: "roles",
                newName: "ConcurrencyStamp");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "users",
                table: "role_claims",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "role_id",
                schema: "users",
                table: "role_claims",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "claim_value",
                schema: "users",
                table: "role_claims",
                newName: "ClaimValue");

            migrationBuilder.RenameColumn(
                name: "claim_type",
                schema: "users",
                table: "role_claims",
                newName: "ClaimType");

            migrationBuilder.RenameIndex(
                name: "ix_role_claims_role_id",
                schema: "users",
                table: "role_claims",
                newName: "IX_role_claims_RoleId");

            migrationBuilder.RenameColumn(
                name: "value",
                schema: "users",
                table: "refresh_tokens",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "users",
                table: "refresh_tokens",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "revoked_at",
                schema: "users",
                table: "refresh_tokens",
                newName: "RevokedAt");

            migrationBuilder.RenameColumn(
                name: "expires_at",
                schema: "users",
                table: "refresh_tokens",
                newName: "ExpiresAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "users",
                table: "refresh_tokens",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "ix_refresh_tokens_user_id",
                schema: "users",
                table: "refresh_tokens",
                newName: "IX_refresh_tokens_user_id");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "exercises",
                table: "exercises",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                schema: "exercises",
                table: "exercises",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "exercises",
                table: "exercises",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_workouts",
                schema: "exercises",
                table: "workouts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_workout_exercises",
                schema: "exercises",
                table: "workout_exercises",
                columns: new[] { "workout_id", "exercise_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                schema: "users",
                table: "users",
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
                name: "PK_roles",
                schema: "users",
                table: "roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_role_claims",
                schema: "users",
                table: "role_claims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_refresh_tokens",
                schema: "users",
                table: "refresh_tokens",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_exercises",
                schema: "exercises",
                table: "exercises",
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
                name: "FK_workout_exercises_exercises_exercise_id",
                schema: "exercises",
                table: "workout_exercises",
                column: "exercise_id",
                principalSchema: "exercises",
                principalTable: "exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_workout_exercises_workouts_workout_id",
                schema: "exercises",
                table: "workout_exercises",
                column: "workout_id",
                principalSchema: "exercises",
                principalTable: "workouts",
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
    }
}
