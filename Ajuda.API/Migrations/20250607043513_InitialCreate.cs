using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ajuda.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_TIPO_AJUDA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TIPO_AJUDA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TELEFONE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EH_VOLUNTARIO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_PEDIDO_AJUDA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USUARIO_ID = table.Column<int>(type: "int", nullable: false),
                    TIPO_AJUDA_ID = table.Column<int>(type: "int", nullable: false),
                    ENDERECO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QUANTIDADE_PESSOAS = table.Column<int>(type: "int", nullable: false),
                    NIVEL_URGENCIA = table.Column<int>(type: "int", nullable: false),
                    DATA_HORA_PEDIDO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PEDIDO_AJUDA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_PEDIDO_AJUDA_TB_TIPO_AJUDA_TIPO_AJUDA_ID",
                        column: x => x.TIPO_AJUDA_ID,
                        principalTable: "TB_TIPO_AJUDA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PEDIDO_AJUDA_TB_USUARIO_USUARIO_ID",
                        column: x => x.USUARIO_ID,
                        principalTable: "TB_USUARIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PEDIDO_AJUDA_TIPO_AJUDA_ID",
                table: "TB_PEDIDO_AJUDA",
                column: "TIPO_AJUDA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PEDIDO_AJUDA_USUARIO_ID",
                table: "TB_PEDIDO_AJUDA",
                column: "USUARIO_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PEDIDO_AJUDA");

            migrationBuilder.DropTable(
                name: "TB_TIPO_AJUDA");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");
        }
    }
}
