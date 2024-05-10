using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACCIONES_BACKEND.Migrations
{
    /// <inheritdoc />
    public partial class fixFavorites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "UserFavorites",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UserFavorites",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "UserFavorites",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "UserFavorites");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "UserFavorites");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "UserFavorites");
        }
    }
}
