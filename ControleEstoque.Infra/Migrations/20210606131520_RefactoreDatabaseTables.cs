using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleEstoque.Infra.Migrations
{
    public partial class RefactoreDatabaseTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Measures_MeasureId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_User_UserChangeId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMovement_User_UserMovementId",
                table: "StockMovement");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Measures");

            migrationBuilder.DropIndex(
                name: "IX_StockMovement_UserMovementId",
                table: "StockMovement");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_MeasureId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_UserChangeId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UserMovementId",
                table: "StockMovement");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "MeasureId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UserChangeId",
                table: "Product");

            migrationBuilder.AlterColumn<string>(
                name: "TypeStokMov",
                table: "StockMovement",
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
                defaultValue: new DateTime(2021, 6, 6, 10, 15, 20, 411, DateTimeKind.Local).AddTicks(6666),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 6, 3, 19, 39, 19, 397, DateTimeKind.Local).AddTicks(9021));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ChangeDate",
                table: "Product",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 6, 10, 15, 20, 405, DateTimeKind.Local).AddTicks(5401),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 6, 3, 19, 39, 19, 396, DateTimeKind.Local).AddTicks(7639));

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Product",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "TypeStokMov",
                table: "StockMovement",
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
                defaultValue: new DateTime(2021, 6, 3, 19, 39, 19, 397, DateTimeKind.Local).AddTicks(9021),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 6, 6, 10, 15, 20, 411, DateTimeKind.Local).AddTicks(6666));

            migrationBuilder.AddColumn<int>(
                name: "UserMovementId",
                table: "StockMovement",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ChangeDate",
                table: "Product",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 3, 19, 39, 19, 396, DateTimeKind.Local).AddTicks(7639),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 6, 6, 10, 15, 20, 405, DateTimeKind.Local).AddTicks(5401));

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MeasureId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserChangeId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Inactive = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Measures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Inactive = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    Initials = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measures", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_StockMovement_UserMovementId",
                table: "StockMovement",
                column: "UserMovementId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_MeasureId",
                table: "Product",
                column: "MeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UserChangeId",
                table: "Product",
                column: "UserChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_Code",
                table: "Category",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Measures_Code",
                table: "Measures",
                column: "Code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Measures_MeasureId",
                table: "Product",
                column: "MeasureId",
                principalTable: "Measures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_User_UserChangeId",
                table: "Product",
                column: "UserChangeId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovement_User_UserMovementId",
                table: "StockMovement",
                column: "UserMovementId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
