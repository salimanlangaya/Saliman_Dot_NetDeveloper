using Microsoft.EntityFrameworkCore.Migrations;

namespace Saliman_Dot_NetDeveloper.Migrations
{
    public partial class CreateDBstruct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "ClassMaster",
                schema: "dbo",
                columns: table => new
                {
                    ClassID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassMaster", x => x.ClassID);
                });

            migrationBuilder.CreateTable(
                name: "SubjectMaster",
                schema: "dbo",
                columns: table => new
                {
                    SubjectID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectMaster", x => x.SubjectID);
                });

            migrationBuilder.CreateTable(
                name: "StudentMaster",
                schema: "dbo",
                columns: table => new
                {
                    StudentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(500)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(500)", nullable: false),
                    ClassID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentMaster", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_StudentMaster_ClassMaster_ClassID",
                        column: x => x.ClassID,
                        principalSchema: "dbo",
                        principalTable: "ClassMaster",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubjectRef",
                schema: "dbo",
                columns: table => new
                {
                    StudentSubjectRefID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(nullable: false),
                    SubjectID = table.Column<int>(nullable: false),
                    Marks = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubjectRef", x => x.StudentSubjectRefID);
                    table.ForeignKey(
                        name: "FK_StudentSubjectRef_StudentMaster_StudentID",
                        column: x => x.StudentID,
                        principalSchema: "dbo",
                        principalTable: "StudentMaster",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubjectRef_SubjectMaster_SubjectID",
                        column: x => x.SubjectID,
                        principalSchema: "dbo",
                        principalTable: "SubjectMaster",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentMaster_ClassID",
                schema: "dbo",
                table: "StudentMaster",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectRef_StudentID",
                schema: "dbo",
                table: "StudentSubjectRef",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectRef_SubjectID",
                schema: "dbo",
                table: "StudentSubjectRef",
                column: "SubjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSubjectRef",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "StudentMaster",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SubjectMaster",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ClassMaster",
                schema: "dbo");
        }
    }
}
