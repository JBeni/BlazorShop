using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorShop.Infrastructure.Migrations
{
    public partial class Migration_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ListPrice",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SalePrice",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Orders",
                newName: "UserEmail");

            migrationBuilder.AddColumn<int>(
                name: "AmountTotal",
                table: "Orders",
                type: "int",
                maxLength: 200,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LineItems",
                table: "Orders",
                type: "nvarchar(max)",
                maxLength: 10000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AmountSubTotal = table.Column<int>(type: "int", nullable: false),
                    AmountTotal = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceiptName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ReceiptUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropColumn(
                name: "AmountTotal",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LineItems",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Orders",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "Discount",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ListPrice",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SalePrice",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tax",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Total",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
