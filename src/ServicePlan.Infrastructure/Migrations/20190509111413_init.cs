using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServicePlan.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoadShowWeekScheduler",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    User_UserId = table.Column<Guid>(nullable: false),
                    User_FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    User_LastName = table.Column<string>(maxLength: 100, nullable: true),
                    User_GroupName = table.Column<string>(maxLength: 200, nullable: true),
                    User_TeamName = table.Column<string>(maxLength: 200, nullable: true),
                    User_Email = table.Column<string>(maxLength: 200, nullable: true),
                    BeginTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    KeyIdeaAndTopic = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadShowWeekScheduler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServicePlan",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    Product_ProductId = table.Column<Guid>(nullable: false),
                    Product_Name = table.Column<string>(maxLength: 200, nullable: true),
                    Product_Type = table.Column<byte>(nullable: false),
                    RoadShow_Address = table.Column<string>(maxLength: 500, nullable: true),
                    DataReport_ReportTitle = table.Column<string>(maxLength: 200, nullable: true),
                    DataReport_Abstract = table.Column<string>(maxLength: 2000, nullable: true),
                    QcUser_UserId = table.Column<Guid>(nullable: false),
                    QcUser_FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    QcUser_LastName = table.Column<string>(maxLength: 100, nullable: true),
                    QcUser_GroupName = table.Column<string>(maxLength: 200, nullable: true),
                    QcUser_TeamName = table.Column<string>(maxLength: 200, nullable: true),
                    QcUser_Email = table.Column<string>(maxLength: 200, nullable: true),
                    User_UserId = table.Column<Guid>(nullable: false),
                    User_FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    User_LastName = table.Column<string>(maxLength: 100, nullable: true),
                    User_GroupName = table.Column<string>(maxLength: 200, nullable: true),
                    User_TeamName = table.Column<string>(maxLength: 200, nullable: true),
                    User_Email = table.Column<string>(maxLength: 200, nullable: true),
                    Creator_UserId = table.Column<Guid>(nullable: false),
                    Creator_FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    Creator_LastName = table.Column<string>(maxLength: 100, nullable: true),
                    Creator_GroupName = table.Column<string>(maxLength: 200, nullable: true),
                    Creator_TeamName = table.Column<string>(maxLength: 200, nullable: true),
                    Creator_Email = table.Column<string>(maxLength: 200, nullable: true),
                    AuditUser_UserId = table.Column<Guid>(nullable: false),
                    AuditUser_FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    AuditUser_LastName = table.Column<string>(maxLength: 100, nullable: true),
                    AuditUser_GroupName = table.Column<string>(maxLength: 200, nullable: true),
                    AuditUser_TeamName = table.Column<string>(maxLength: 200, nullable: true),
                    AuditUser_Email = table.Column<string>(maxLength: 200, nullable: true),
                    AuditStateId = table.Column<int>(nullable: false),
                    BeginTime = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false, defaultValue: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    PlanStateId = table.Column<int>(nullable: false),
                    PlanTypeId = table.Column<int>(nullable: false),
                    ValidationStateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePlan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PlanId = table.Column<Guid>(nullable: true),
                    Booked = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    BeginTime = table.Column<DateTime>(nullable: false),
                    BookTime = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    RoadShowWeekSchedulerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_RoadShowWeekScheduler_RoadShowWeekSchedulerId",
                        column: x => x.RoadShowWeekSchedulerId,
                        principalTable: "RoadShowWeekScheduler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Creation = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Path = table.Column<string>(nullable: false),
                    ServicePlanId = table.Column<Guid>(nullable: true),
                    Type = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachment_ServicePlan_ServicePlanId",
                        column: x => x.ServicePlanId,
                        principalTable: "ServicePlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuditHistory",
                columns: table => new
                {
                    _id = table.Column<Guid>(nullable: false),
                    User_UserId = table.Column<Guid>(nullable: false),
                    User_FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    User_LastName = table.Column<string>(maxLength: 100, nullable: true),
                    User_GroupName = table.Column<string>(maxLength: 100, nullable: true),
                    User_TeamName = table.Column<string>(maxLength: 100, nullable: true),
                    User_Email = table.Column<string>(maxLength: 200, nullable: true),
                    Operation = table.Column<string>(maxLength: 100, nullable: true),
                    Result = table.Column<string>(maxLength: 300, nullable: true),
                    ServicePlanId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditHistory", x => x._id);
                    table.ForeignKey(
                        name: "FK_AuditHistory_ServicePlan_ServicePlanId",
                        column: x => x.ServicePlanId,
                        principalTable: "ServicePlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailRecord",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Success = table.Column<bool>(nullable: true),
                    ResponseTime = table.Column<DateTime>(nullable: true),
                    ClientUser_ClientId = table.Column<Guid>(nullable: false),
                    ClientUser_ClientName = table.Column<string>(maxLength: 200, nullable: true),
                    ClientUser_ClientShortName = table.Column<string>(maxLength: 200, nullable: true),
                    ClientUser_ClientUserId = table.Column<Guid>(nullable: false),
                    ClientUser_FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    ClientUser_LastName = table.Column<string>(maxLength: 100, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    ServicePlanId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailRecord_ServicePlan_ServicePlanId",
                        column: x => x.ServicePlanId,
                        principalTable: "ServicePlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServicePlan_ClientUsers",
                columns: table => new
                {
                    _id = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    ClientName = table.Column<string>(maxLength: 200, nullable: true),
                    ClientShortName = table.Column<string>(maxLength: 200, nullable: true),
                    ClientUserId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    RoadShowServicePlanId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePlan_ClientUsers", x => x._id);
                    table.ForeignKey(
                        name: "FK_ServicePlan_ClientUsers_ServicePlan_RoadShowServicePlanId",
                        column: x => x.RoadShowServicePlanId,
                        principalTable: "ServicePlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicePlan_Subscriber",
                columns: table => new
                {
                    _id = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    ClientName = table.Column<string>(maxLength: 200, nullable: true),
                    ClientShortName = table.Column<string>(maxLength: 200, nullable: true),
                    ClientUserId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    ProductServicePlanId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePlan_Subscriber", x => x._id);
                    table.ForeignKey(
                        name: "FK_ServicePlan_Subscriber_ServicePlan_ProductServicePlanId",
                        column: x => x.ProductServicePlanId,
                        principalTable: "ServicePlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRecord",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClientFocusKeyPoint = table.Column<string>(nullable: true),
                    Continue = table.Column<bool>(nullable: true),
                    Feedback = table.Column<string>(nullable: true),
                    IndustryId = table.Column<string>(nullable: true),
                    ModificationRequirement = table.Column<string>(nullable: true),
                    NewRequirement = table.Column<string>(nullable: true),
                    PlanTypeId = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: true),
                    ServicePlanId = table.Column<Guid>(nullable: true),
                    ServiceTime = table.Column<DateTime>(nullable: false),
                    Subject = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceRecord_ServicePlan_ServicePlanId",
                        column: x => x.ServicePlanId,
                        principalTable: "ServicePlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointment_ClientUsers",
                columns: table => new
                {
                    _id = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    ClientName = table.Column<string>(maxLength: 200, nullable: true),
                    ClientShortName = table.Column<string>(maxLength: 200, nullable: true),
                    ClientUserId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    AppointmentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment_ClientUsers", x => x._id);
                    table.ForeignKey(
                        name: "FK_Appointment_ClientUsers_Appointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRecord_ClientUsers",
                columns: table => new
                {
                    _id = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    ClientName = table.Column<string>(maxLength: 200, nullable: true),
                    ClientShortName = table.Column<string>(maxLength: 200, nullable: true),
                    ClientUserId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    ServiceRecordId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRecord_ClientUsers", x => x._id);
                    table.ForeignKey(
                        name: "FK_ServiceRecord_ClientUsers_ServiceRecord_ServiceRecordId",
                        column: x => x.ServiceRecordId,
                        principalTable: "ServiceRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_RoadShowWeekSchedulerId",
                table: "Appointment",
                column: "RoadShowWeekSchedulerId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_ClientUsers_AppointmentId",
                table: "Appointment_ClientUsers",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_ServicePlanId",
                table: "Attachment",
                column: "ServicePlanId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditHistory_ServicePlanId",
                table: "AuditHistory",
                column: "ServicePlanId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailRecord_ServicePlanId",
                table: "EmailRecord",
                column: "ServicePlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePlan_ClientUsers_RoadShowServicePlanId",
                table: "ServicePlan_ClientUsers",
                column: "RoadShowServicePlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePlan_Subscriber_ProductServicePlanId",
                table: "ServicePlan_Subscriber",
                column: "ProductServicePlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRecord_ServicePlanId",
                table: "ServiceRecord",
                column: "ServicePlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRecord_ClientUsers_ServiceRecordId",
                table: "ServiceRecord_ClientUsers",
                column: "ServiceRecordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment_ClientUsers");

            migrationBuilder.DropTable(
                name: "Attachment");

            migrationBuilder.DropTable(
                name: "AuditHistory");

            migrationBuilder.DropTable(
                name: "EmailRecord");

            migrationBuilder.DropTable(
                name: "ServicePlan_ClientUsers");

            migrationBuilder.DropTable(
                name: "ServicePlan_Subscriber");

            migrationBuilder.DropTable(
                name: "ServiceRecord_ClientUsers");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "ServiceRecord");

            migrationBuilder.DropTable(
                name: "RoadShowWeekScheduler");

            migrationBuilder.DropTable(
                name: "ServicePlan");
        }
    }
}
