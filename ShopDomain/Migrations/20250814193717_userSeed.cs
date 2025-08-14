using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopDomain.Migrations
{
    /// <inheritdoc />
    public partial class userSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "clientes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "clientes",
                columns: new[] { "Id", "Address", "LastName", "Name", "PasswordHash", "PasswordSalt", "Rol", "Username" },
                values: new object[] { 1, "Av Candiles 315 169", "Admin", "Super", new byte[] { 51, 36, 204, 228, 40, 69, 93, 143, 58, 104, 134, 245, 1, 199, 26, 71, 88, 163, 182, 59, 151, 34, 246, 66, 115, 11, 230, 224, 212, 249, 85, 114, 189, 4, 122, 86, 239, 164, 71, 87, 165, 103, 46, 172, 194, 179, 70, 3, 249, 226, 172, 116, 50, 61, 59, 141, 187, 148, 202, 198, 135, 37, 194, 13 }, new byte[] { 86, 19, 165, 54, 220, 30, 66, 210, 178, 255, 3, 135, 218, 228, 118, 124, 161, 227, 66, 78, 246, 209, 137, 143, 131, 165, 59, 223, 66, 14, 248, 195, 84, 108, 75, 30, 246, 218, 192, 233, 255, 151, 42, 82, 146, 112, 109, 114, 76, 141, 201, 33, 218, 174, 62, 206, 231, 128, 193, 178, 13, 213, 29, 171, 190, 249, 2, 13, 114, 194, 93, 134, 1, 173, 117, 186, 183, 181, 58, 82, 153, 94, 142, 44, 44, 71, 54, 21, 71, 59, 63, 135, 29, 84, 197, 243, 251, 221, 31, 15, 158, 11, 21, 51, 134, 195, 157, 22, 182, 88, 11, 162, 241, 218, 121, 224, 162, 41, 212, 160, 50, 163, 69, 168, 231, 240, 167, 177 }, 0, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_clientes_Username",
                table: "clientes",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_clientes_Username",
                table: "clientes");

            migrationBuilder.DeleteData(
                table: "clientes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "clientes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
