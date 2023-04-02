using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SquaresAPI.Migrations
{
    /// <inheritdoc />
    public partial class entityrelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Points",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Points",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "PlaneId",
                table: "Points",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SquareId",
                table: "Points",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Processed = table.Column<bool>(type: "boolean", nullable: false),
                    TotalSquares = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Squares",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlaneId = table.Column<Guid>(type: "uuid", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plane_Square",
                        column: x => x.PlaneId,
                        principalTable: "Planes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Points_PlaneId",
                table: "Points",
                column: "PlaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_SquareId",
                table: "Points",
                column: "SquareId");

            migrationBuilder.CreateIndex(
                name: "IX_Squares_PlaneId",
                table: "Squares",
                column: "PlaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plane_Point",
                table: "Points",
                column: "PlaneId",
                principalTable: "Planes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Square_Point",
                table: "Points",
                column: "SquareId",
                principalTable: "Squares",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plane_Point",
                table: "Points");

            migrationBuilder.DropForeignKey(
                name: "FK_Square_Point",
                table: "Points");

            migrationBuilder.DropTable(
                name: "Squares");

            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropIndex(
                name: "IX_Points_PlaneId",
                table: "Points");

            migrationBuilder.DropIndex(
                name: "IX_Points_SquareId",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "PlaneId",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "SquareId",
                table: "Points");
        }
    }
}
