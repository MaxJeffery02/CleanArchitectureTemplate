using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Momentum.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "revoked_at",
                schema: "users",
                table: "refresh_tokens",
                newName: "revoked_at_utc");

            migrationBuilder.RenameColumn(
                name: "expires_at",
                schema: "users",
                table: "refresh_tokens",
                newName: "expires_at_utc");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "users",
                table: "refresh_tokens",
                newName: "created_at_utc");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "exercises",
                table: "exercises",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "exercises",
                table: "exercises",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "revoked_at_utc",
                schema: "users",
                table: "refresh_tokens",
                newName: "revoked_at");

            migrationBuilder.RenameColumn(
                name: "expires_at_utc",
                schema: "users",
                table: "refresh_tokens",
                newName: "expires_at");

            migrationBuilder.RenameColumn(
                name: "created_at_utc",
                schema: "users",
                table: "refresh_tokens",
                newName: "created_at");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "exercises",
                table: "exercises",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "exercises",
                table: "exercises",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);
        }
    }
}
