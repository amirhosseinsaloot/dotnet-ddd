using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DomainDrivenDesign.Infrastructure.Data.Migrations;

/// <inheritdoc />
public partial class Init : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.EnsureSchema(
            name: "ddd");

        migrationBuilder.CreateTable(
            name: "roles",
            schema: "ddd",
            columns: table => new
            {
                id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                createdon = table.Column<DateTime>(name: "created_on", type: "timestamp with time zone", nullable: false),
                name = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                normalizedname = table.Column<string>(name: "normalized_name", type: "text", nullable: true),
                concurrencystamp = table.Column<string>(name: "concurrency_stamp", type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_roles", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "teams",
            schema: "ddd",
            columns: table => new
            {
                id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                parentteamid = table.Column<long>(name: "parent_team_id", type: "bigint", nullable: true),
                createdon = table.Column<DateTime>(name: "created_on", type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_teams", x => x.id);
                table.ForeignKey(
                    name: "fk_teams_teams_parent_team_id",
                    column: x => x.parentteamid,
                    principalSchema: "ddd",
                    principalTable: "teams",
                    principalColumn: "id");
            });

        migrationBuilder.CreateTable(
            name: "users",
            schema: "ddd",
            columns: table => new
            {
                id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                firstname = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: false),
                lastname = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: false),
                birthdate = table.Column<DateTime>(type: "date", nullable: false),
                gender = table.Column<byte>(type: "smallint", nullable: false),
                isactive = table.Column<bool>(name: "is_active", type: "boolean", nullable: false),
                lastlogindate = table.Column<DateTime>(name: "last_login_date", type: "timestamp with time zone", nullable: true),
                refreshtoken = table.Column<string>(name: "refresh_token", type: "character varying(50)", maxLength: 50, nullable: true),
                refreshtokenexpirationtime = table.Column<DateTime>(name: "refresh_token_expiration_time", type: "timestamp with time zone", nullable: true),
                teamid = table.Column<long>(name: "team_id", type: "bigint", nullable: false),
                createdon = table.Column<DateTime>(name: "created_on", type: "timestamp with time zone", nullable: false),
                username = table.Column<string>(name: "user_name", type: "character varying(40)", maxLength: 40, nullable: false),
                normalizedusername = table.Column<string>(name: "normalized_user_name", type: "text", nullable: true),
                email = table.Column<string>(type: "character varying(320)", maxLength: 320, nullable: false),
                normalizedemail = table.Column<string>(name: "normalized_email", type: "text", nullable: true),
                emailconfirmed = table.Column<bool>(name: "email_confirmed", type: "boolean", nullable: false),
                passwordhash = table.Column<string>(name: "password_hash", type: "text", nullable: true),
                securitystamp = table.Column<string>(name: "security_stamp", type: "text", nullable: true),
                concurrencystamp = table.Column<string>(name: "concurrency_stamp", type: "text", nullable: true),
                phonenumber = table.Column<string>(name: "phone_number", type: "text", nullable: true),
                phonenumberconfirmed = table.Column<bool>(name: "phone_number_confirmed", type: "boolean", nullable: false),
                twofactorenabled = table.Column<bool>(name: "two_factor_enabled", type: "boolean", nullable: false),
                lockoutend = table.Column<DateTimeOffset>(name: "lockout_end", type: "timestamp with time zone", nullable: true),
                lockoutenabled = table.Column<bool>(name: "lockout_enabled", type: "boolean", nullable: false),
                accessfailedcount = table.Column<int>(name: "access_failed_count", type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_users", x => x.id);
                table.ForeignKey(
                    name: "fk_users_team_team_id",
                    column: x => x.teamid,
                    principalSchema: "ddd",
                    principalTable: "teams",
                    principalColumn: "id");
            });

        migrationBuilder.CreateTable(
            name: "user_roles",
            schema: "ddd",
            columns: table => new
            {
                userid = table.Column<long>(name: "user_id", type: "bigint", nullable: false),
                roleid = table.Column<long>(name: "role_id", type: "bigint", nullable: false),
                createdon = table.Column<DateTime>(name: "created_on", type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_user_roles", x => new { x.userid, x.roleid });
                table.ForeignKey(
                    name: "fk_user_roles_roles_role_id",
                    column: x => x.roleid,
                    principalSchema: "ddd",
                    principalTable: "roles",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "fk_user_roles_users_user_id",
                    column: x => x.userid,
                    principalSchema: "ddd",
                    principalTable: "users",
                    principalColumn: "id");
            });

        migrationBuilder.CreateIndex(
            name: "ix_teams_parent_team_id",
            schema: "ddd",
            table: "teams",
            column: "parent_team_id");

        migrationBuilder.CreateIndex(
            name: "ix_user_roles_role_id",
            schema: "ddd",
            table: "user_roles",
            column: "role_id");

        migrationBuilder.CreateIndex(
            name: "ix_users_team_id",
            schema: "ddd",
            table: "users",
            column: "team_id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "user_roles",
            schema: "ddd");

        migrationBuilder.DropTable(
            name: "roles",
            schema: "ddd");

        migrationBuilder.DropTable(
            name: "users",
            schema: "ddd");

        migrationBuilder.DropTable(
            name: "teams",
            schema: "ddd");
    }
}
