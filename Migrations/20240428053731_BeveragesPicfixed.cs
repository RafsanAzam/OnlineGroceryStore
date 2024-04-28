using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineGroceryStore.Migrations
{
    /// <inheritdoc />
    public partial class BeveragesPicfixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "ImageUrl",
                value: "/images/beverages.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "ImageUrl",
                value: "/images/cat-4.png");
        }
    }
}
