using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShopping.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class sdsad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSelectedCalculations_Calculations_CalculationId1",
                table: "ProductSelectedCalculations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSelectedCalculations_Products_ProductId1",
                table: "ProductSelectedCalculations");

            migrationBuilder.DropIndex(
                name: "IX_ProductSelectedCalculations_CalculationId1",
                table: "ProductSelectedCalculations");

            migrationBuilder.DropIndex(
                name: "IX_ProductSelectedCalculations_ProductId1",
                table: "ProductSelectedCalculations");

            migrationBuilder.DropColumn(
                name: "CalculationId1",
                table: "ProductSelectedCalculations");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "ProductSelectedCalculations");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductSelectedCalculations",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "CalculationId",
                table: "ProductSelectedCalculations",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSelectedCalculations_CalculationId",
                table: "ProductSelectedCalculations",
                column: "CalculationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSelectedCalculations_ProductId",
                table: "ProductSelectedCalculations",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSelectedCalculations_Calculations_CalculationId",
                table: "ProductSelectedCalculations",
                column: "CalculationId",
                principalTable: "Calculations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSelectedCalculations_Products_ProductId",
                table: "ProductSelectedCalculations",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSelectedCalculations_Calculations_CalculationId",
                table: "ProductSelectedCalculations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSelectedCalculations_Products_ProductId",
                table: "ProductSelectedCalculations");

            migrationBuilder.DropIndex(
                name: "IX_ProductSelectedCalculations_CalculationId",
                table: "ProductSelectedCalculations");

            migrationBuilder.DropIndex(
                name: "IX_ProductSelectedCalculations_ProductId",
                table: "ProductSelectedCalculations");

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "ProductSelectedCalculations",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "CalculationId",
                table: "ProductSelectedCalculations",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CalculationId1",
                table: "ProductSelectedCalculations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "ProductSelectedCalculations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductSelectedCalculations_CalculationId1",
                table: "ProductSelectedCalculations",
                column: "CalculationId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSelectedCalculations_ProductId1",
                table: "ProductSelectedCalculations",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSelectedCalculations_Calculations_CalculationId1",
                table: "ProductSelectedCalculations",
                column: "CalculationId1",
                principalTable: "Calculations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSelectedCalculations_Products_ProductId1",
                table: "ProductSelectedCalculations",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
