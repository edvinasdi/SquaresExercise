using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SquaresAPI.Migrations
{
    /// <inheritdoc />
    public partial class changedsquaresentitydeletebehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Square_Point",
                table: "Points");

            migrationBuilder.AddForeignKey(
                name: "FK_Square_Point",
                table: "Points",
                column: "SquareId",
                principalTable: "Squares",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Square_Point",
                table: "Points");

            migrationBuilder.AddForeignKey(
                name: "FK_Square_Point",
                table: "Points",
                column: "SquareId",
                principalTable: "Squares",
                principalColumn: "Id");
        }
    }
}
