using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleEstoque.Infra.Migrations
{
    public partial class AlterTiptColumnRoleInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "User",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateMovement",
                table: "StockMovement",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 3, 19, 39, 19, 397, DateTimeKind.Local).AddTicks(9021),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 6, 3, 8, 45, 4, 767, DateTimeKind.Local).AddTicks(5985));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ChangeDate",
                table: "Product",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 3, 19, 39, 19, 396, DateTimeKind.Local).AddTicks(7639),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 6, 3, 8, 45, 4, 765, DateTimeKind.Local).AddTicks(4540));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateMovement",
                table: "StockMovement",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 3, 8, 45, 4, 767, DateTimeKind.Local).AddTicks(5985),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 6, 3, 19, 39, 19, 397, DateTimeKind.Local).AddTicks(9021));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ChangeDate",
                table: "Product",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 3, 8, 45, 4, 765, DateTimeKind.Local).AddTicks(4540),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 6, 3, 19, 39, 19, 396, DateTimeKind.Local).AddTicks(7639));
        }
    }
}
