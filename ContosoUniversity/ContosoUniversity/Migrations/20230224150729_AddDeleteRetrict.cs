using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContosoUniversity.Migrations
{
    /// <inheritdoc />
    public partial class AddDeleteRetrict : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Instructor_InstructorID",
                table: "Department");

            migrationBuilder.AlterColumn<int>(
                name: "InstructorID",
                table: "Department",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Instructor_InstructorID",
                table: "Department",
                column: "InstructorID",
                principalTable: "Instructor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Instructor_InstructorID",
                table: "Department");

            migrationBuilder.AlterColumn<int>(
                name: "InstructorID",
                table: "Department",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Instructor_InstructorID",
                table: "Department",
                column: "InstructorID",
                principalTable: "Instructor",
                principalColumn: "ID");
        }
    }
}
