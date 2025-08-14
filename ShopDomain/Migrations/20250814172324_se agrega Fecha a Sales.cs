using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopDomain.Migrations
{
    /// <inheritdoc />
    public partial class seagregaFechaaSales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "sales",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "sales");
        }
    }
}
