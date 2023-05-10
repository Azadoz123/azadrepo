using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AskedQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionNumber = table.Column<int>(type: "int", nullable: false),
                    QuestionContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DegreeOfDifficulty = table.Column<int>(type: "int", nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AskedQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AskedQuestions_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AskedQuestionOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionOptionContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChoiceOption = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    ResponseStatus = table.Column<bool>(type: "bit", nullable: false),
                    AskedQuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AskedQuestionOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AskedQuestionOptions_AskedQuestions_AskedQuestionId",
                        column: x => x.AskedQuestionId,
                        principalTable: "AskedQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AskedQuestionOptions_AskedQuestionId",
                table: "AskedQuestionOptions",
                column: "AskedQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AskedQuestions_ExamId",
                table: "AskedQuestions",
                column: "ExamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AskedQuestionOptions");

            migrationBuilder.DropTable(
                name: "AskedQuestions");
        }
    }
}
