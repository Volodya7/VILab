using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbModel.Migrations
{
    public partial class removedUnitIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Subcategories_UnitId",
                table: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_Cases_UnitId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Cases");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_SubcategoryId",
                table: "Cases",
                column: "SubcategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Subcategories_SubcategoryId",
                table: "Cases",
                column: "SubcategoryId",
                principalTable: "Subcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Subcategories_SubcategoryId",
                table: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_Cases_SubcategoryId",
                table: "Cases");

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "Cases",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cases_UnitId",
                table: "Cases",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Subcategories_UnitId",
                table: "Cases",
                column: "UnitId",
                principalTable: "Subcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
