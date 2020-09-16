using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Yet.Infrastructure.Data.Migrations
{
    public partial class CatalogoIncial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Yet-Shop");

            migrationBuilder.CreateSequence(
                name: "catalogo_hilo",
                schema: "Yet-Shop",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "catalogo_marca_hilo",
                schema: "Yet-Shop",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "catalogo_tipo_hilo",
                schema: "Yet-Shop",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "CatalogoMarcas",
                schema: "Yet-Shop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Marca = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogoMarcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogoTipos",
                schema: "Yet-Shop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Tipo = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogoTipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cestas",
                schema: "Yet-Shop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompradorId = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cestas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                schema: "Yet-Shop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompradorId = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    EnderecoEntrega_Rua = table.Column<string>(maxLength: 180, nullable: true),
                    EnderecoEntrega_Cidade = table.Column<string>(maxLength: 100, nullable: true),
                    EnderecoEntrega_Estado = table.Column<string>(maxLength: 60, nullable: true),
                    EnderecoEntrega_Pais = table.Column<string>(maxLength: 90, nullable: true),
                    EnderecoEntrega_Cep = table.Column<string>(maxLength: 18, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalogo",
                schema: "Yet-Shop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImagemUri = table.Column<string>(nullable: true),
                    CatalogoTipoId = table.Column<int>(nullable: false),
                    CatalogoMarcaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalogo_CatalogoMarcas_CatalogoMarcaId",
                        column: x => x.CatalogoMarcaId,
                        principalSchema: "Yet-Shop",
                        principalTable: "CatalogoMarcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Catalogo_CatalogoTipos_CatalogoTipoId",
                        column: x => x.CatalogoTipoId,
                        principalSchema: "Yet-Shop",
                        principalTable: "CatalogoTipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CestaItens",
                schema: "Yet-Shop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecoUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    CatalogoItemId = table.Column<int>(nullable: false),
                    CestaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CestaItens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CestaItens_Cestas_CestaId",
                        column: x => x.CestaId,
                        principalSchema: "Yet-Shop",
                        principalTable: "Cestas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoItens",
                schema: "Yet-Shop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemPedido_CatalogoItemId = table.Column<int>(nullable: true),
                    ItemPedido_ProdutoNome = table.Column<string>(maxLength: 50, nullable: true),
                    PrecoUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Unidades = table.Column<int>(nullable: false),
                    PedidoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoItens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoItens_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalSchema: "Yet-Shop",
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalogo_CatalogoMarcaId",
                schema: "Yet-Shop",
                table: "Catalogo",
                column: "CatalogoMarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogo_CatalogoTipoId",
                schema: "Yet-Shop",
                table: "Catalogo",
                column: "CatalogoTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_CestaItens_CestaId",
                schema: "Yet-Shop",
                table: "CestaItens",
                column: "CestaId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItens_PedidoId",
                schema: "Yet-Shop",
                table: "PedidoItens",
                column: "PedidoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalogo",
                schema: "Yet-Shop");

            migrationBuilder.DropTable(
                name: "CestaItens",
                schema: "Yet-Shop");

            migrationBuilder.DropTable(
                name: "PedidoItens",
                schema: "Yet-Shop");

            migrationBuilder.DropTable(
                name: "CatalogoMarcas",
                schema: "Yet-Shop");

            migrationBuilder.DropTable(
                name: "CatalogoTipos",
                schema: "Yet-Shop");

            migrationBuilder.DropTable(
                name: "Cestas",
                schema: "Yet-Shop");

            migrationBuilder.DropTable(
                name: "Pedidos",
                schema: "Yet-Shop");

            migrationBuilder.DropSequence(
                name: "catalogo_hilo",
                schema: "Yet-Shop");

            migrationBuilder.DropSequence(
                name: "catalogo_marca_hilo",
                schema: "Yet-Shop");

            migrationBuilder.DropSequence(
                name: "catalogo_tipo_hilo",
                schema: "Yet-Shop");
        }
    }
}
