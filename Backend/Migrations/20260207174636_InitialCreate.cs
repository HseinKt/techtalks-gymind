using System;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GYMIND.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "Gyms",
                columns: table => new
                {
                    GymId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gyms", x => x.GymId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<Guid>(type: "uuid", nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "GymBranches",
                columns: table => new
                {
                    GymBranchID = table.Column<Guid>(type: "uuid", nullable: false),
                    GymID = table.Column<Guid>(type: "uuid", nullable: false),
                    LocationID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    OperatingHours = table.Column<JsonDocument>(type: "jsonb", nullable: false),
                    ServiceDescription = table.Column<string>(type: "text", nullable: true),
                    CoverImageUrl = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymBranches", x => x.GymBranchID);
                    table.ForeignKey(
                        name: "FK_GymBranches_Gyms_GymID",
                        column: x => x.GymID,
                        principalTable: "Gyms",
                        principalColumn: "GymId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GymBranches_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userid = table.Column<Guid>(type: "uuid", nullable: false),
                    fullname = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: true),
                    passwordhash = table.Column<string>(type: "text", nullable: false),
                    location = table.Column<string>(type: "text", nullable: true),
                    dateofbirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    membershipid = table.Column<Guid>(type: "uuid", nullable: true),
                    gender = table.Column<string>(type: "text", nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    RoleID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userid);
                    table.ForeignKey(
                        name: "FK_users_roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "roles",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    AnnouncementID = table.Column<Guid>(type: "uuid", nullable: false),
                    GymBranchID = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.AnnouncementID);
                    table.ForeignKey(
                        name: "FK_Announcements_GymBranches_GymBranchID",
                        column: x => x.GymBranchID,
                        principalTable: "GymBranches",
                        principalColumn: "GymBranchID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrafficTracks",
                columns: table => new
                {
                    TrafficTrackID = table.Column<Guid>(type: "uuid", nullable: false),
                    GymBranchID = table.Column<Guid>(type: "uuid", nullable: false),
                    TrafficTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CapacityPercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    EntryCount = table.Column<int>(type: "integer", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrafficTracks", x => x.TrafficTrackID);
                    table.ForeignKey(
                        name: "FK_TrafficTracks_GymBranches_GymBranchID",
                        column: x => x.GymBranchID,
                        principalTable: "GymBranches",
                        principalColumn: "GymBranchID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GymAdminActions",
                columns: table => new
                {
                    GymAdminActionID = table.Column<Guid>(type: "uuid", nullable: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    GymBranchID = table.Column<Guid>(type: "uuid", nullable: false),
                    ActionType = table.Column<string>(type: "text", nullable: false),
                    TargetEntity = table.Column<string>(type: "text", nullable: false),
                    TargetID = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Outcome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymAdminActions", x => x.GymAdminActionID);
                    table.ForeignKey(
                        name: "FK_GymAdminActions_GymBranches_GymBranchID",
                        column: x => x.GymBranchID,
                        principalTable: "GymBranches",
                        principalColumn: "GymBranchID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GymAdminActions_users_UserID",
                        column: x => x.UserID,
                        principalTable: "users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GymSessions",
                columns: table => new
                {
                    GymSessionID = table.Column<Guid>(type: "uuid", nullable: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    GymBranchID = table.Column<Guid>(type: "uuid", nullable: false),
                    CheckInTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CheckOutTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SessionDuration = table.Column<int>(type: "integer", nullable: true),
                    CheckInLat = table.Column<decimal>(type: "numeric", nullable: false),
                    CheckInLong = table.Column<decimal>(type: "numeric", nullable: false),
                    IsVerifiedLocation = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymSessions", x => x.GymSessionID);
                    table.ForeignKey(
                        name: "FK_GymSessions_GymBranches_GymBranchID",
                        column: x => x.GymBranchID,
                        principalTable: "GymBranches",
                        principalColumn: "GymBranchID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GymSessions_users_UserID",
                        column: x => x.UserID,
                        principalTable: "users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    MembershipID = table.Column<Guid>(type: "uuid", nullable: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    GymID = table.Column<Guid>(type: "uuid", nullable: false),
                    IsMember = table.Column<bool>(type: "boolean", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    JoinedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RemovedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    UserID1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.MembershipID);
                    table.ForeignKey(
                        name: "FK_Memberships_Gyms_GymID",
                        column: x => x.GymID,
                        principalTable: "Gyms",
                        principalColumn: "GymId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Memberships_users_UserID1",
                        column: x => x.UserID1,
                        principalTable: "users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationID = table.Column<Guid>(type: "uuid", nullable: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: true),
                    GymBranchID = table.Column<Guid>(type: "uuid", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    SentAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationID);
                    table.ForeignKey(
                        name: "FK_Notifications_GymBranches_GymBranchID",
                        column: x => x.GymBranchID,
                        principalTable: "GymBranches",
                        principalColumn: "GymBranchID");
                    table.ForeignKey(
                        name: "FK_Notifications_users_UserID",
                        column: x => x.UserID,
                        principalTable: "users",
                        principalColumn: "userid");
                });

            migrationBuilder.CreateTable(
                name: "SystemAdminActions",
                columns: table => new
                {
                    SystemAdminActionID = table.Column<Guid>(type: "uuid", nullable: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    ActionType = table.Column<string>(type: "text", nullable: false),
                    TargetEntity = table.Column<string>(type: "text", nullable: false),
                    TargetID = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Outcome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemAdminActions", x => x.SystemAdminActionID);
                    table.ForeignKey(
                        name: "FK_SystemAdminActions_users_UserID",
                        column: x => x.UserID,
                        principalTable: "users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userrole",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleID = table.Column<int>(type: "integer", nullable: false),
                    UserRoleID = table.Column<int>(type: "integer", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userrole", x => new { x.UserID, x.RoleID });
                    table.ForeignKey(
                        name: "FK_userrole_roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userrole_users_UserID",
                        column: x => x.UserID,
                        principalTable: "users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserNotifications",
                columns: table => new
                {
                    UserNotificationID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    NotificationID = table.Column<Guid>(type: "uuid", nullable: false),
                    ReadStatus = table.Column<bool>(type: "boolean", nullable: false),
                    ReadAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotifications", x => x.UserNotificationID);
                    table.ForeignKey(
                        name: "FK_UserNotifications_Notifications_NotificationID",
                        column: x => x.NotificationID,
                        principalTable: "Notifications",
                        principalColumn: "NotificationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserNotifications_users_UserID",
                        column: x => x.UserID,
                        principalTable: "users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_GymBranchID",
                table: "Announcements",
                column: "GymBranchID");

            migrationBuilder.CreateIndex(
                name: "IX_GymAdminActions_GymBranchID",
                table: "GymAdminActions",
                column: "GymBranchID");

            migrationBuilder.CreateIndex(
                name: "IX_GymAdminActions_UserID",
                table: "GymAdminActions",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_GymBranches_GymID",
                table: "GymBranches",
                column: "GymID");

            migrationBuilder.CreateIndex(
                name: "IX_GymBranches_LocationID",
                table: "GymBranches",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_GymSessions_GymBranchID",
                table: "GymSessions",
                column: "GymBranchID");

            migrationBuilder.CreateIndex(
                name: "IX_GymSessions_UserID",
                table: "GymSessions",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_GymID",
                table: "Memberships",
                column: "GymID");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_UserID1",
                table: "Memberships",
                column: "UserID1");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_GymBranchID",
                table: "Notifications",
                column: "GymBranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserID",
                table: "Notifications",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_SystemAdminActions_UserID",
                table: "SystemAdminActions",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_TrafficTracks_GymBranchID",
                table: "TrafficTracks",
                column: "GymBranchID");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_NotificationID",
                table: "UserNotifications",
                column: "NotificationID");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_UserID",
                table: "UserNotifications",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_userrole_RoleID",
                table: "userrole",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_users_RoleID",
                table: "users",
                column: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "GymAdminActions");

            migrationBuilder.DropTable(
                name: "GymSessions");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "SystemAdminActions");

            migrationBuilder.DropTable(
                name: "TrafficTracks");

            migrationBuilder.DropTable(
                name: "UserNotifications");

            migrationBuilder.DropTable(
                name: "userrole");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "GymBranches");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "Gyms");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
