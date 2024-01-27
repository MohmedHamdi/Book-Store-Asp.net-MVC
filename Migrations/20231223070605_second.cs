using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookstore1.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_books_BookId",
                table: "carts");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "carts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_carts_books_BookId",
                table: "carts",
                column: "BookId",
                principalTable: "books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_books_BookId",
                table: "carts");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "carts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_carts_books_BookId",
                table: "carts",
                column: "BookId",
                principalTable: "books",
                principalColumn: "BookId");
        }
    }
}
