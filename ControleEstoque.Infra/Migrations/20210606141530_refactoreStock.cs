using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleEstoque.Infra.Migrations
{
    public partial class refactoreStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockMovement_Stock_StockId",
                table: "StockMovement");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_StockMovement_StockId",
                table: "StockMovement");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "StockMovement");

            migrationBuilder.RenameColumn(
                name: "StokId",
                table: "StockMovement",
                newName: "ProductId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateMovement",
                table: "StockMovement",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 6, 11, 15, 30, 434, DateTimeKind.Local).AddTicks(7080),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 6, 6, 10, 15, 20, 411, DateTimeKind.Local).AddTicks(6666));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ChangeDate",
                table: "Product",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 6, 11, 15, 30, 428, DateTimeKind.Local).AddTicks(3859),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 6, 6, 10, 15, 20, 405, DateTimeKind.Local).AddTicks(5401));

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "Product",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_StockMovement_ProductId",
                table: "StockMovement",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovement_Product_ProductId",
                table: "StockMovement",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockMovement_Product_ProductId",
                table: "StockMovement");

            migrationBuilder.DropIndex(
                name: "IX_StockMovement_ProductId",
                table: "StockMovement");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "StockMovement",
                newName: "StokId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateMovement",
                table: "StockMovement",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 6, 10, 15, 20, 411, DateTimeKind.Local).AddTicks(6666),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 6, 6, 11, 15, 30, 434, DateTimeKind.Local).AddTicks(7080));

            migrationBuilder.AddColumn<int>(
                name: "StockId",
                table: "StockMovement",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ChangeDate",
                table: "Product",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 6, 10, 15, 20, 405, DateTimeKind.Local).AddTicks(5401),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 6, 6, 11, 15, 30, 428, DateTimeKind.Local).AddTicks(3859));

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_StockMovement_StockId",
                table: "StockMovement",
                column: "StockId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovement_Stock_StockId",
                table: "StockMovement",
                column: "StockId",
                principalTable: "Stock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
