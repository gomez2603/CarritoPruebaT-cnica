using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopDomain.Migrations
{
    /// <inheritdoc />
    public partial class artTienda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "artTiendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    ArticuloId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artTiendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_artTiendas_articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_artTiendas_tiendas_StoreId",
                        column: x => x.StoreId,
                        principalTable: "tiendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_artTiendas_ArticuloId",
                table: "artTiendas",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_artTiendas_StoreId",
                table: "artTiendas",
                column: "StoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "artTiendas");
        }
    }
}
