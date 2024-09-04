using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFeApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NFes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Numero = table.Column<string>(type: "TEXT", nullable: false),
                    DataEmissao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NFes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emitentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    CNPJ = table.Column<string>(type: "TEXT", nullable: false),
                    NFeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emitentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emitentes_NFes_NFeId",
                        column: x => x.NFeId,
                        principalTable: "NFes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensNFe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    NFeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensNFe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensNFe_NFes_NFeId",
                        column: x => x.NFeId,
                        principalTable: "NFes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emitentes_NFeId",
                table: "Emitentes",
                column: "NFeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItensNFe_NFeId",
                table: "ItensNFe",
                column: "NFeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emitentes");

            migrationBuilder.DropTable(
                name: "ItensNFe");

            migrationBuilder.DropTable(
                name: "NFes");
        }
    }
}
