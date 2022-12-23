using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstructorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentDTOSubjectDTO",
                columns: table => new
                {
                    StudentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDTOSubjectDTO", x => new { x.StudentsId, x.SubjectsId });
                    table.ForeignKey(
                        name: "FK_StudentDTOSubjectDTO_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentDTOSubjectDTO_Subjects_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("2294bc1b-cb1a-4db6-aaf7-bbed27c2ed49"), "John Instructor" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Course", "Grade", "Name", "Year" },
                values: new object[] { new Guid("7841bc1b-cb1a-4db6-aaf7-bbed27c2ed49"), "BSIT", null, "Jane Student", 4 });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "InstructorId", "Name" },
                values: new object[,]
                {
                    { new Guid("3441bc1b-cb1a-4db6-aaf7-bbed27c2ed49"), new Guid("2294bc1b-cb1a-4db6-aaf7-bbed27c2ed49"), "Platform Technologies" },
                    { new Guid("5641bc1b-cb1a-4db6-aaf7-bbed27c2ed49"), new Guid("2294bc1b-cb1a-4db6-aaf7-bbed27c2ed49"), "Capstone 1" },
                    { new Guid("7541c1bc-cb1a-4db6-aaf7-bbed27c2ed49"), new Guid("2294bc1b-cb1a-4db6-aaf7-bbed27c2ed49"), "Intro to Computing" }
                });

            migrationBuilder.InsertData(
                table: "StudentDTOSubjectDTO",
                columns: new[] { "StudentsId", "SubjectsId" },
                values: new object[,]
                {
                    { new Guid("7841bc1b-cb1a-4db6-aaf7-bbed27c2ed49"), new Guid("3441bc1b-cb1a-4db6-aaf7-bbed27c2ed49") },
                    { new Guid("7841bc1b-cb1a-4db6-aaf7-bbed27c2ed49"), new Guid("7541c1bc-cb1a-4db6-aaf7-bbed27c2ed49") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentDTOSubjectDTO_SubjectsId",
                table: "StudentDTOSubjectDTO",
                column: "SubjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_InstructorId",
                table: "Subjects",
                column: "InstructorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentDTOSubjectDTO");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Instructors");
        }
    }
}
