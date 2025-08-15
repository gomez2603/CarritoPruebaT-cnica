using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopDomain.Migrations
{
    /// <inheritdoc />
    public partial class seagreganreglasderelacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sales_clientes_clienteId",
                table: "sales");

            migrationBuilder.DropIndex(
                name: "IX_sales_clienteId",
                table: "sales");

            migrationBuilder.DropIndex(
                name: "IX_artTiendas_StoreId",
                table: "artTiendas");

            migrationBuilder.DropColumn(
                name: "clienteId",
                table: "sales");

            migrationBuilder.UpdateData(
                table: "clientes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 187, 6, 14, 251, 110, 7, 182, 175, 180, 87, 44, 68, 96, 223, 244, 229, 245, 58, 109, 239, 221, 241, 154, 49, 233, 102, 247, 224, 16, 139, 18, 118, 233, 195, 142, 153, 53, 238, 188, 60, 79, 135, 103, 123, 177, 113, 164, 20, 52, 194, 119, 116, 173, 67, 247, 207, 145, 70, 11, 4, 212, 55, 213, 221 }, new byte[] { 220, 180, 129, 85, 230, 89, 206, 45, 4, 157, 11, 90, 199, 17, 77, 38, 186, 90, 12, 194, 146, 136, 52, 45, 181, 251, 122, 124, 61, 139, 110, 251, 10, 107, 171, 209, 176, 77, 146, 218, 213, 210, 128, 47, 90, 225, 203, 33, 40, 230, 130, 4, 60, 251, 25, 248, 151, 242, 188, 163, 18, 180, 91, 34, 240, 112, 251, 216, 247, 170, 175, 101, 159, 15, 153, 72, 81, 165, 237, 16, 41, 166, 165, 6, 173, 0, 130, 72, 44, 163, 43, 111, 255, 127, 185, 255, 106, 220, 45, 86, 51, 212, 104, 153, 193, 162, 146, 221, 250, 165, 138, 255, 14, 101, 18, 195, 130, 237, 228, 242, 31, 24, 226, 39, 10, 113, 33, 109 } });

            migrationBuilder.CreateIndex(
                name: "IX_sales_ClientId_ArticuloId",
                table: "sales",
                columns: new[] { "ClientId", "ArticuloId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_artTiendas_StoreId_ArticuloId",
                table: "artTiendas",
                columns: new[] { "StoreId", "ArticuloId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_clientes_ClientId",
                table: "sales",
                column: "ClientId",
                principalTable: "clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sales_clientes_ClientId",
                table: "sales");

            migrationBuilder.DropIndex(
                name: "IX_sales_ClientId_ArticuloId",
                table: "sales");

            migrationBuilder.DropIndex(
                name: "IX_artTiendas_StoreId_ArticuloId",
                table: "artTiendas");

            migrationBuilder.AddColumn<int>(
                name: "clienteId",
                table: "sales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "clientes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 51, 36, 204, 228, 40, 69, 93, 143, 58, 104, 134, 245, 1, 199, 26, 71, 88, 163, 182, 59, 151, 34, 246, 66, 115, 11, 230, 224, 212, 249, 85, 114, 189, 4, 122, 86, 239, 164, 71, 87, 165, 103, 46, 172, 194, 179, 70, 3, 249, 226, 172, 116, 50, 61, 59, 141, 187, 148, 202, 198, 135, 37, 194, 13 }, new byte[] { 86, 19, 165, 54, 220, 30, 66, 210, 178, 255, 3, 135, 218, 228, 118, 124, 161, 227, 66, 78, 246, 209, 137, 143, 131, 165, 59, 223, 66, 14, 248, 195, 84, 108, 75, 30, 246, 218, 192, 233, 255, 151, 42, 82, 146, 112, 109, 114, 76, 141, 201, 33, 218, 174, 62, 206, 231, 128, 193, 178, 13, 213, 29, 171, 190, 249, 2, 13, 114, 194, 93, 134, 1, 173, 117, 186, 183, 181, 58, 82, 153, 94, 142, 44, 44, 71, 54, 21, 71, 59, 63, 135, 29, 84, 197, 243, 251, 221, 31, 15, 158, 11, 21, 51, 134, 195, 157, 22, 182, 88, 11, 162, 241, 218, 121, 224, 162, 41, 212, 160, 50, 163, 69, 168, 231, 240, 167, 177 } });

            migrationBuilder.CreateIndex(
                name: "IX_sales_clienteId",
                table: "sales",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_artTiendas_StoreId",
                table: "artTiendas",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_sales_clientes_clienteId",
                table: "sales",
                column: "clienteId",
                principalTable: "clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
