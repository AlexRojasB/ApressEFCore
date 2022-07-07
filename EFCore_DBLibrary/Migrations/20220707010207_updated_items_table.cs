using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_DBLibrary.Migrations
{
    public partial class updated_items_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CurrentOrFinalPrice",
                table: "Items",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Items",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsOnSale",
                table: "Items",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Items",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "PurchasePrice",
                table: "Items",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchasedDate",
                table: "Items",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Items",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SoldDate",
                table: "Items",
                type: "timestamp with time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentOrFinalPrice",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IsOnSale",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PurchasePrice",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PurchasedDate",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SoldDate",
                table: "Items");
        }
    }
}
