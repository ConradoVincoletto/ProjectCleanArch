using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiIdentity.Migrations
{
    public partial class Inicial_Aluno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Curso = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.AlunoId);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "AlunoId", "Curso", "Email", "Idade", "Nome" },
                values: new object[] { 1, "Math", "conrado@example.com", 32, "Conrado" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");
        }
    }
}
