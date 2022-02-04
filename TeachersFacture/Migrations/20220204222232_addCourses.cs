using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeachersFacture.Migrations
{
    public partial class addCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourse_Courses_CourseId",
                table: "TeacherCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourse_TeachersInfo_TeacherId",
                table: "TeacherCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherCourse",
                table: "TeacherCourse");

            migrationBuilder.RenameTable(
                name: "TeacherCourse",
                newName: "TeacherCourses");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherCourse_CourseId",
                table: "TeacherCourses",
                newName: "IX_TeacherCourses_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherCourses",
                table: "TeacherCourses",
                columns: new[] { "TeacherId", "CourseId" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "ISIS2601" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "IMEC1021" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "IPAT5081" });

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourses_Courses_CourseId",
                table: "TeacherCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourses_TeachersInfo_TeacherId",
                table: "TeacherCourses",
                column: "TeacherId",
                principalTable: "TeachersInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourses_Courses_CourseId",
                table: "TeacherCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourses_TeachersInfo_TeacherId",
                table: "TeacherCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherCourses",
                table: "TeacherCourses");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "TeacherCourses",
                newName: "TeacherCourse");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherCourses_CourseId",
                table: "TeacherCourse",
                newName: "IX_TeacherCourse_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherCourse",
                table: "TeacherCourse",
                columns: new[] { "TeacherId", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourse_Courses_CourseId",
                table: "TeacherCourse",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourse_TeachersInfo_TeacherId",
                table: "TeacherCourse",
                column: "TeacherId",
                principalTable: "TeachersInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
