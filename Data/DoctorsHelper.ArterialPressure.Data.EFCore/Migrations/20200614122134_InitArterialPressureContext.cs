using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorsHelper.ArterialPressure.Data.EFCore.Migrations
{
    public partial class InitArterialPressureContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArterialPressureRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArterialPressureRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArterialPressureUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    IsMen = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArterialPressureUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArterialPressureRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArterialPressureRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArterialPressureRoleClaims_ArterialPressureRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ArterialPressureRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArterialPressureDiaryRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    SystolicBloodPressure = table.Column<int>(nullable: false),
                    DiastolicBloodPressure = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    AmbulanceDrugsNumber = table.Column<int>(nullable: false),
                    Pulse = table.Column<int>(nullable: false),
                    GlucoseLevel = table.Column<double>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    IsMorning = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArterialPressureDiaryRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArterialPressureDiaryRecords_ArterialPressureUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ArterialPressureUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArterialPressureUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArterialPressureUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArterialPressureUserClaims_ArterialPressureUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ArterialPressureUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArterialPressureUserJwtTokens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    ExpirationDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArterialPressureUserJwtTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArterialPressureUserJwtTokens_ArterialPressureUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ArterialPressureUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArterialPressureUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArterialPressureUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_ArterialPressureUserLogins_ArterialPressureUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ArterialPressureUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArterialPressureUserResetPasswordTokens",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    ValidTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArterialPressureUserResetPasswordTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArterialPressureUserResetPasswordTokens_ArterialPressureUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ArterialPressureUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArterialPressureUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArterialPressureUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_ArterialPressureUserRoles_ArterialPressureRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ArterialPressureRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArterialPressureUserRoles_ArterialPressureUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ArterialPressureUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArterialPressureUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArterialPressureUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_ArterialPressureUserTokens_ArterialPressureUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ArterialPressureUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArterialPressureDiaryRecords_UserId",
                table: "ArterialPressureDiaryRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArterialPressureRoleClaims_RoleId",
                table: "ArterialPressureRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "ArterialPressureRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ArterialPressureUserClaims_UserId",
                table: "ArterialPressureUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArterialPressureUserJwtTokens_UserId",
                table: "ArterialPressureUserJwtTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArterialPressureUserLogins_UserId",
                table: "ArterialPressureUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArterialPressureUserResetPasswordTokens_UserId",
                table: "ArterialPressureUserResetPasswordTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArterialPressureUserRoles_RoleId",
                table: "ArterialPressureUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "ArterialPressureUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "ArterialPressureUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArterialPressureDiaryRecords");

            migrationBuilder.DropTable(
                name: "ArterialPressureRoleClaims");

            migrationBuilder.DropTable(
                name: "ArterialPressureUserClaims");

            migrationBuilder.DropTable(
                name: "ArterialPressureUserJwtTokens");

            migrationBuilder.DropTable(
                name: "ArterialPressureUserLogins");

            migrationBuilder.DropTable(
                name: "ArterialPressureUserResetPasswordTokens");

            migrationBuilder.DropTable(
                name: "ArterialPressureUserRoles");

            migrationBuilder.DropTable(
                name: "ArterialPressureUserTokens");

            migrationBuilder.DropTable(
                name: "ArterialPressureRoles");

            migrationBuilder.DropTable(
                name: "ArterialPressureUsers");
        }
    }
}
