using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto.Infra.Data.Migrations
{
    public partial class Projeto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FUNCAO",
                columns: table => new
                {
                    IDFUNCAO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DESCRICAO = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FUNCAO", x => x.IDFUNCAO);
                });

            migrationBuilder.CreateTable(
                name: "FUNCIONARIO",
                columns: table => new
                {
                    IDFUNCIONARIO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(maxLength: 150, nullable: false),
                    SALARIO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DATAADMISSAO = table.Column<DateTime>(type: "date", nullable: false),
                    IDFUNCAO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FUNCIONARIO", x => x.IDFUNCIONARIO);
                    table.ForeignKey(
                        name: "FK_FUNCIONARIO_FUNCAO_IDFUNCAO",
                        column: x => x.IDFUNCAO,
                        principalTable: "FUNCAO",
                        principalColumn: "IDFUNCAO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_IDFUNCAO",
                table: "FUNCIONARIO",
                column: "IDFUNCAO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FUNCIONARIO");

            migrationBuilder.DropTable(
                name: "FUNCAO");
        }
    }
}
