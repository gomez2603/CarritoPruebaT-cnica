using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopDomain.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articulos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tiendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Branch = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tiendas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ArticuloId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sales_articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sales_clientes_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "clientes",
                columns: new[] { "Id", "Address", "LastName", "Name", "PasswordHash", "PasswordSalt", "Rol", "Username" },
                values: new object[] { 1, "Av Candiles 315 169", "Admin", "Super", new byte[] { 169, 223, 84, 87, 194, 84, 41, 250, 121, 102, 171, 14, 77, 9, 223, 15, 174, 212, 80, 71, 12, 61, 203, 85, 231, 167, 185, 207, 2, 113, 147, 180, 255, 238, 61, 111, 11, 74, 139, 133, 43, 241, 7, 249, 182, 131, 196, 96, 5, 78, 37, 90, 73, 160, 114, 188, 97, 8, 206, 226, 152, 98, 34, 65 }, new byte[] { 252, 60, 212, 136, 103, 33, 226, 206, 166, 38, 227, 217, 254, 211, 195, 70, 101, 87, 20, 11, 3, 244, 1, 210, 170, 29, 223, 109, 139, 169, 90, 165, 127, 72, 98, 128, 24, 60, 171, 184, 214, 234, 211, 61, 86, 103, 242, 100, 167, 18, 119, 86, 181, 70, 141, 60, 235, 255, 144, 153, 211, 254, 185, 244, 55, 156, 138, 77, 37, 132, 173, 92, 129, 186, 185, 25, 70, 72, 219, 27, 238, 180, 225, 106, 87, 115, 32, 160, 247, 134, 131, 164, 171, 151, 190, 12, 175, 204, 122, 121, 32, 33, 121, 133, 238, 133, 152, 133, 120, 193, 239, 112, 194, 152, 196, 214, 206, 172, 225, 165, 7, 104, 26, 17, 209, 201, 212, 33 }, 0, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_artTiendas_ArticuloId",
                table: "artTiendas",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_artTiendas_StoreId_ArticuloId",
                table: "artTiendas",
                columns: new[] { "StoreId", "ArticuloId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_clientes_Username",
                table: "clientes",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sales_ArticuloId",
                table: "sales",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_ClientId",
                table: "sales",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "artTiendas");

            migrationBuilder.DropTable(
                name: "sales");

            migrationBuilder.DropTable(
                name: "tiendas");

            migrationBuilder.DropTable(
                name: "articulos");

            migrationBuilder.DropTable(
                name: "clientes");
        }
    }
}
