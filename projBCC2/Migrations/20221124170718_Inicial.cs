using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projBCC2.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    idade = table.Column<int>(type: "int", nullable: false),
                    estadoCliente = table.Column<int>(type: "int", nullable: false),
                    cidade = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeEmpresa = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    estadoEmpresa = table.Column<int>(type: "int", nullable: false),
                    cidade = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeFuncionarios = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    idade = table.Column<int>(type: "int", nullable: false),
                    funcao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    funcionarioid = table.Column<int>(type: "int", nullable: false),
                    empresaid = table.Column<int>(type: "int", nullable: false),
                    produto = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    quantidadeCompra = table.Column<int>(type: "int", nullable: false),
                    valorUN = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.id);
                    table.ForeignKey(
                        name: "FK_Compras_Empresas_empresaid",
                        column: x => x.empresaid,
                        principalTable: "Empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compras_Funcionarios_funcionarioid",
                        column: x => x.funcionarioid,
                        principalTable: "Funcionarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    compraid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.id);
                    table.ForeignKey(
                        name: "FK_Produto_Compras_compraid",
                        column: x => x.compraid,
                        principalTable: "Compras",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Revendas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clienteid = table.Column<int>(type: "int", nullable: false),
                    compraid = table.Column<int>(type: "int", nullable: false),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    quantidadeVenda = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revendas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Revendas_Clientes_clienteid",
                        column: x => x.clienteid,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Revendas_Compras_compraid",
                        column: x => x.compraid,
                        principalTable: "Compras",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Balancete",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comprasid = table.Column<int>(type: "int", nullable: true),
                    comprastotal = table.Column<int>(type: "int", nullable: false),
                    revendaid = table.Column<int>(type: "int", nullable: true),
                    revendastotal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balancete", x => x.id);
                    table.ForeignKey(
                        name: "FK_Balancete_Compras_comprasid",
                        column: x => x.comprasid,
                        principalTable: "Compras",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Balancete_Revendas_revendaid",
                        column: x => x.revendaid,
                        principalTable: "Revendas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Balancete_comprasid",
                table: "Balancete",
                column: "comprasid");

            migrationBuilder.CreateIndex(
                name: "IX_Balancete_revendaid",
                table: "Balancete",
                column: "revendaid");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_empresaid",
                table: "Compras",
                column: "empresaid");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_funcionarioid",
                table: "Compras",
                column: "funcionarioid");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_compraid",
                table: "Produto",
                column: "compraid");

            migrationBuilder.CreateIndex(
                name: "IX_Revendas_clienteid",
                table: "Revendas",
                column: "clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_Revendas_compraid",
                table: "Revendas",
                column: "compraid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balancete");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Revendas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
