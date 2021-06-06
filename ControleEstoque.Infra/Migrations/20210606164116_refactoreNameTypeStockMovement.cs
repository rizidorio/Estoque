using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleEstoque.Infra.Migrations
{
    public partial class refactoreNameTypeStockMovement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeStokMov",
                table: "StockMovement",
                newName: "TypeMovement");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateMovement",
                table: "StockMovement",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 6, 13, 41, 16, 635, DateTimeKind.Local).AddTicks(7575),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 6, 6, 11, 15, 30, 434, DateTimeKind.Local).AddTicks(7080));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ChangeDate",
                table: "Product",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 6, 13, 41, 16, 629, DateTimeKind.Local).AddTicks(4819),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 6, 6, 11, 15, 30, 428, DateTimeKind.Local).AddTicks(3859));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeMovement",
                table: "StockMovement",
                newName: "TypeStokMov");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateMovement",
                table: "StockMovement",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 6, 11, 15, 30, 434, DateTimeKind.Local).AddTicks(7080),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 6, 6, 13, 41, 16, 635, DateTimeKind.Local).AddTicks(7575));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ChangeDate",
                table: "Product",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 6, 11, 15, 30, 428, DateTimeKind.Local).AddTicks(3859),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 6, 6, 13, 41, 16, 629, DateTimeKind.Local).AddTicks(4819));
        }
    }
}
