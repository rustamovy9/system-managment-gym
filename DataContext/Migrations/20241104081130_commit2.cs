using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemManagmentGym.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class commit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_FitnessClasses_FitnessClassId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Trainers_TrainerId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSchedules_Schedule_ScheduleId",
                table: "UserSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule");

            migrationBuilder.RenameTable(
                name: "Schedule",
                newName: "Schedules");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_TrainerId",
                table: "Schedules",
                newName: "IX_Schedules_TrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_FitnessClassId",
                table: "Schedules",
                newName: "IX_Schedules_FitnessClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_FitnessClasses_FitnessClassId",
                table: "Schedules",
                column: "FitnessClassId",
                principalTable: "FitnessClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Trainers_TrainerId",
                table: "Schedules",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSchedules_Schedules_ScheduleId",
                table: "UserSchedules",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_FitnessClasses_FitnessClassId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Trainers_TrainerId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSchedules_Schedules_ScheduleId",
                table: "UserSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules");

            migrationBuilder.RenameTable(
                name: "Schedules",
                newName: "Schedule");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_TrainerId",
                table: "Schedule",
                newName: "IX_Schedule_TrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_FitnessClassId",
                table: "Schedule",
                newName: "IX_Schedule_FitnessClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_FitnessClasses_FitnessClassId",
                table: "Schedule",
                column: "FitnessClassId",
                principalTable: "FitnessClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Trainers_TrainerId",
                table: "Schedule",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSchedules_Schedule_ScheduleId",
                table: "UserSchedules",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
