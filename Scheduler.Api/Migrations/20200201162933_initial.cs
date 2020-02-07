using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Scheduler.Api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "User",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100),
                    Avatar = table.Column<string>(nullable: true),
                    Profession = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_User", x => x.Id); });

            migrationBuilder.CreateTable(
                "Schedule",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TimeStart = table.Column<DateTime>(),
                    TimeEnd = table.Column<DateTime>(),
                    Location = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false, defaultValue: 1),
                    Status = table.Column<int>(nullable: false, defaultValue: 1),
                    DateCreated = table.Column<DateTime>(nullable: false,
                        defaultValue: new DateTime(2020, 2, 1, 16, 29, 33, 134, DateTimeKind.Local).AddTicks(2601)),
                    DateUpdated = table.Column<DateTime>(nullable: false,
                        defaultValue: new DateTime(2020, 2, 1, 16, 29, 33, 140, DateTimeKind.Local).AddTicks(8118)),
                    CreatorId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        "FK_Schedule_User_CreatorId",
                        x => x.CreatorId,
                        "User",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Attendee",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(),
                    ScheduleId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendee", x => x.Id);
                    table.ForeignKey(
                        "FK_Attendee_Schedule_ScheduleId",
                        x => x.ScheduleId,
                        "Schedule",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Attendee_User_UserId",
                        x => x.UserId,
                        "User",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Attendee_ScheduleId",
                "Attendee",
                "ScheduleId");

            migrationBuilder.CreateIndex(
                "IX_Attendee_UserId",
                "Attendee",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_Schedule_CreatorId",
                "Schedule",
                "CreatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Attendee");

            migrationBuilder.DropTable(
                "Schedule");

            migrationBuilder.DropTable(
                "User");
        }
    }
}